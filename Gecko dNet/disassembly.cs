using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using FTDIUSBGecko;

namespace GeckoApp
{
    class Disassembly
    {
        private String vdappPath;
        private USBGecko gecko;
        private ListBox mainBox;
        private VScrollBar scrollbar;
        private TextBox adressInput;

        private ExceptionHandler exceptionHandling;

        private TextBox asAddress;
        private TextBox asText;

        private UInt32 cAddress;
        private UInt32 selAddress = 0;

        public UInt32 disAddress { get { return selAddress; } }

        private String GAs, GLd, GOc;

        public Disassembly(USBGecko UGecko, String UVdappPath, ListBox UMainBox,
            VScrollBar UScroll,TextBox UAInput,TextBox UASAddress,TextBox UASText,ExceptionHandler UEXCHandler)
        {
            gecko = UGecko;
            exceptionHandling = UEXCHandler;
            vdappPath = UVdappPath;
            if (!GlobalFunctions.tryToHex(GeckoApp.Properties.Settings.Default.MemViewAddr, out cAddress))
            {
                // If the restored value is corrupt, use this instead
                cAddress = 0x80003100;
            }
            scrollbar = UScroll;
            mainBox = UMainBox;
            adressInput = UAInput;
            asAddress = UASAddress;
            asText = UASText;

            mainBox.SelectedIndexChanged += MainBoxClick;
            mainBox.DoubleClick += MainBoxDoubleClick;
            mainBox.KeyDown += MainBoxKeyDown;
            scrollbar.Scroll += Scrolling;
            
#if MONO
			GAs = "powerpc-eabi-as";
			GLd = "powerpc-eabi-ld";
			GOc = "powerpc-eabi-objcopy";
#else
            GAs = "powerpc-gekko-as.exe";
            GLd = "powerpc-gekko-ld.exe";
            GOc = "powerpc-gekko-objcopy.exe";
#endif
        }

        private void ChangeBy(int offset)
        {
            UInt32 oAddress = cAddress;
            cAddress = (UInt32)((long)cAddress + offset);
            if (!ValidMemory.validAddress(cAddress))
            {
                cAddress = oAddress;
                return;
            }
            DissToBox();

            // Force control to re-paint with the new disassembly
            mainBox.Update();
        }

        private void MainBoxKeyDown(object sender, KeyEventArgs e)
        {
            int index = mainBox.SelectedIndex;

            // Watch for edge cases; at the top and user presses up
            if (index == 0 && e.KeyCode == Keys.Up)
            {
                ChangeBy(-4);
                if (mainBox.Items.Count > 0)
                    mainBox.SelectedIndex = 0;
            }

            // at the bottom and user presses down
            if (index == (mainBox.Items.Count - 1) && e.KeyCode == Keys.Down)
            {
                ChangeBy(4);
                mainBox.SelectedIndex = mainBox.Items.Count - 1;
            }

            // 0x40 is the amount of code we can see in the smallest window
            // Maybe in the future we should see how many lines are visible
            // and adjust pageup and pagedown based on that value instead
            if (e.KeyCode == Keys.PageUp)
            {
                ChangeBy(-0x40);
            }

            if (e.KeyCode == Keys.PageDown)
            {
                ChangeBy(0x40);
            }

            //if (index == -1)
            //{
            //    asAddress.Text = GlobalFunctions.toHex(cAddress);
            //    asText.Text = "";
            //    return;
            //}

            //UInt32 address = cAddress + (UInt32)index * 4;
            //asAddress.Text = GlobalFunctions.toHex(address);
            //selAddress = address;

            //String assembly = mainBox.Items[index].ToString();
            //assembly = assembly.Substring(20, assembly.Length - 20);
            //String[] sep = assembly.Split(new char[1] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            //assembly = "";
            //for (int i = 0; i < sep.Length; i++)
            //    assembly += sep[i] + " ";
            ////assembly = assembly.Trim();
            //asText.Text = assembly;
        }

        private void MainBoxDoubleClick(object sender, EventArgs e)
        {
            int index = mainBox.SelectedIndex;

            // If index is negative, bail out
            if (index == -1)
            {
                return;
            }

            // Grab the instruction that they selected
            String assembly = mainBox.Items[index].ToString();
            assembly = assembly.Substring(20, assembly.Length - 20);
            String[] sep = assembly.Split(new char[1] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Is it some sort of branch?  Does it have an address parameter?
            sep[0] = sep[0].ToLower();
            if (sep[0].StartsWith("b") && sep.Length > 1)
            {
                // Most of the time, this won't matter
                // However, some branches specify the cr (e.g. bge- cr6,0x802e583c)
                // So parse out anything before the 0x
                sep[1] = sep[1].Substring(sep[1].IndexOf("0x"));

                // Does it have a valid address after it?
                UInt32 bAddress;
                if (GlobalFunctions.tryToHex(sep[1], out bAddress) && ValidMemory.validAddress(bAddress))
                {
                    // tell the disassembly window to jump there
                    DissToBox(bAddress);
                }
            }
        }

        private void MainBoxClick(object sender, EventArgs e)
        {
            int index = mainBox.SelectedIndex;

            // If index is negative, bail out
            if (index == -1)
            {
                asAddress.Text = GlobalFunctions.toHex(cAddress);
                asText.Text = "";
                return;
            }

            // When user clicks, update the selected address
            UInt32 address = cAddress + (UInt32)index * 4;
            asAddress.Text = GlobalFunctions.toHex(address);
            selAddress = address;

            // Split the assembly instruction along tabs and put it in the "one-line assembler"
            String assembly = mainBox.Items[index].ToString();
            assembly = assembly.Substring(20, assembly.Length - 20);
            String[] sep = assembly.Split(new char[1] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
            assembly = "";
            for (int i = 0; i < sep.Length; i++)
                assembly += sep[i] + " ";
            //assembly = assembly.Trim();
            asText.Text = assembly;
        }

        private void Scrolling(object sender, ScrollEventArgs e)
        {
            ScrollEventType t = e.Type;
            if (t == ScrollEventType.SmallIncrement)
            {
                ChangeBy(4);
            }
            else if (t == ScrollEventType.LargeIncrement)
            {
                ChangeBy(0x20);
            }
            else if (t == ScrollEventType.SmallDecrement)
            {
                ChangeBy(-4);
            }
            else if (t == ScrollEventType.LargeDecrement)
            {
                ChangeBy(-0x20);
            }            
            scrollbar.Value = 1;            
        }

        public String[] Disassemble(UInt32 address, int commands)
        {
            List<String> result = new List<String>();
            
            address = address & 0xFFFFFFFC;
            UInt32 eAddress = address + (UInt32)commands * 4;

            if (!File.Exists(vdappPath))
            {
#if MONO
				return new String[] { "vdappc not found!" };
#else
                return new String[] { "vdappc.exe not found!" };
#endif
            }

            // TODO: who is leaving this file open?
            FileStream values;
            string filename = System.IO.Path.GetTempFileName();
            try
            {
                values = new FileStream(filename, FileMode.Create);
            }
            catch (Exception e)
            {
                return new String[] { "Couldn't open diss.bin!" };
            }

            try
            {
                gecko.Dump(address, eAddress, values);
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
                return result.ToArray();
            }
            finally
            {
                // This will always close the FileStream, even if the exception is handled
                values.Close();
            }
            
            Process proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.FileName = vdappPath;
            proc.StartInfo.Arguments = "\"" + filename + "\" 0x" + GlobalFunctions.toHex(address);
            proc.StartInfo.CreateNoWindow = true;
            //proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //proc.StartInfo.CreateNoWindow = false;
            proc.Start();
               
            // Must read from the standard output before waiting on the process to close!
            // Otherwise, the standard output buffer will be full and vdappc will lock up
            // and we would never read from the buffer
            while (!proc.StandardOutput.EndOfStream)
                result.Add(proc.StandardOutput.ReadLine());
            proc.WaitForExit(/*2000*/);

            //int exitCode = proc.ExitCode;
            //if (exitCode == 0)
            //{
            //    while (!proc.StandardOutput.EndOfStream)
            //        result.Add(proc.StandardOutput.ReadLine());
            //}
            proc.Close();

            File.Delete(filename);

            return result.ToArray();
        }

        public String[] DissToBox(UInt32 address)
        {
            cAddress = address & 0xFFFFFFFC;
            String[] assembly = Disassemble(address, 60);
            
            mainBox.Items.Clear();
            for (int i = 0; i < assembly.Length; i++)
                mainBox.Items.Add(assembly[i]);

            adressInput.Text = GlobalFunctions.toHex(cAddress);

            if (mainBox.Items.Count > 0)
            {
                mainBox.SelectedIndex = 0;
            }

            return assembly;
        }

        public String[] DissToBox()
        {
            return DissToBox(cAddress);
        }

        public void Increase()
        {
            ChangeBy(0x10);
        }

        public void Decrease()
        {
            ChangeBy(-0x10);
        }

        private bool isBranch(String command)
        {
            return (command.ToLower()[0] == 'b');
        }

        private bool extractTargetAddress(UInt32 address,ref String command)
        {
            if (command.ToLower().Contains("lr") || command.Contains("ctr"))
                return true;
            String[] parts = command.ToLower().Split(new char[1] { ' ' });
            String[] orgparts = command.Split(new char[1] { ' ' });
            String numeric = parts[parts.Length - 1];
            String number;
            bool hex;
            if (numeric.Substring(0, 2) == "0x")
            {
                number = numeric.Substring(2, numeric.Length - 2);
                hex = true;
            }
            else
            {
                number = numeric;
                hex = false;
            }

            UInt32 tAddress;
            bool result;
            if (hex)
                result = GlobalFunctions.tryToHex(number, out tAddress);
            else
                result = UInt32.TryParse(number, out tAddress);
           
            if(result)
            {
                Int32 offset = (Int32)((long)tAddress - (long)address);
                orgparts[orgparts.Length-1] = "0x" + GlobalFunctions.toHex(offset);
                command = "";
                for (int i = 0; i < orgparts.Length; i++)
                    command += orgparts[i] + " ";
                command = command.Trim();
            }

            return result;
        }

        public void Assemble(UInt32 address,String command)
        {
            if (!File.Exists(GAs))
            {
                MessageBox.Show(GAs + " not found! Cannot assemble!");
                return;
            }

            if (!File.Exists(GLd))
            {
                MessageBox.Show(GLd + " not found! Cannot assemble!");
                return;
            }

            if (!File.Exists(GOc))
            {
                MessageBox.Show(GOc + " not found! Cannot assemble!");
                return;
            }

            command = command.Trim();
            
            if (isBranch(command))
            {
                if (!extractTargetAddress(address,ref command))
                {
                    MessageBox.Show("Command parsing error!");
                    return;
                }
            }

            StreamWriter sw = new StreamWriter("ass.txt");
            sw.WriteLine(command);
            sw.Close();

            Process proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = GAs;
            proc.StartInfo.Arguments = "-mgekko -mregnames -o ass.o ass.txt";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
            String output = String.Empty;
            while (!proc.StandardError.EndOfStream)
                output += proc.StandardError.ReadLine() + "\n";
            proc.WaitForExit(/*2000*/);
            int exitCode = proc.ExitCode;
            proc.Close();
            File.Delete("ass.txt");
            if (exitCode != 0 || !File.Exists("ass.o"))
            {
                if (File.Exists("ass.o"))
                    File.Delete("ass.o");
                MessageBox.Show(output);
                return;
            }

            proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = GLd;
            proc.StartInfo.Arguments = " -Ttext 0x80000000 -o ass2.o ass.o";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
            output = String.Empty;
            while (!proc.StandardError.EndOfStream)
                output += proc.StandardError.ReadLine() + "\n";
            proc.WaitForExit();

            exitCode = proc.ExitCode;
            proc.Close();
            File.Delete("ass.o");
            if (exitCode != 0 || !File.Exists("ass2.o"))
            {
                if (File.Exists("ass2.o"))
                    File.Delete("ass2.o");
                MessageBox.Show(output);
                return;
            }

            proc = new Process();
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.FileName = GOc;
            proc.StartInfo.Arguments = " -O binary ass2.o ass.bin";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.Start();
            output = String.Empty;
            while (!proc.StandardError.EndOfStream)
                output += proc.StandardError.ReadLine() + "\n";
            proc.WaitForExit();

            exitCode = proc.ExitCode;
            proc.Close();
            File.Delete("ass2.o");
            if (exitCode != 0)
            {
                if (File.Exists("ass.bin"))
                    File.Delete("ass.bin");
                MessageBox.Show(output);
                return;
            }

            UInt32 machineCode;
            FileStream sr = new FileStream("ass.bin",FileMode.Open);
            machineCode = GlobalFunctions.ReadStream(sr);
            sr.Close();
            File.Delete("ass.bin");

            try
            {
                gecko.poke(address, machineCode);

                System.Threading.Thread.Sleep(100);
                DissToBox(address);
            }
            catch (EUSBGeckoException e)
            {
                exceptionHandling.HandleException(e);
            }
        }
    }
}
