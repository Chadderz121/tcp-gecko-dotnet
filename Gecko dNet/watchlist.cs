using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Threading;
using AMS.Profile;

using FTDIUSBGecko;
using System.Windows.Forms;

namespace GeckoApp
{
    public enum WatchDataSize
    {
        Bit8,
        Bit16,
        Bit32,
        SingleFp
    }

    public class WatchEntry 
    {
        private String PName;
        private UInt32[] PAddress;
        private WatchDataSize PDataSize;
        private UInt32 PUPAddress;
        private bool PAddressAvail;
        private UInt32 PLastValue;

        public String name { get { return PName; } }
        public UInt32[] address { get { return PAddress; } }
        public WatchDataSize dataSize { get { return PDataSize; } }
        public UInt32 updatedAddress
        {
            get
            {
                return PUPAddress;
            }
            set
            {
                PUPAddress = value;
            }
        }
        public bool addressAvail
        {
            get
            {
                return PAddressAvail;
            }
            set
            {
                PAddressAvail = value;
            }
        }
        public UInt32 lastValue
        {
            get
            {
                return PLastValue;
            }
            set
            {
                PLastValue = value;
            }
        }
        

        public WatchEntry(String name,UInt32[] address,WatchDataSize dataSize)
        {
            PName = name;
            PAddress = address;
            PDataSize = dataSize;
            PUPAddress = 0;
            PAddressAvail = false;
            PLastValue = 0;
        }
    } 

    public class WatchList
    {
        private static bool HardcoreConvert(String input,out UInt32 value)
        {
            String parsedCode = "";
            int i;

            value = 0;

            for (i = 0; i < input.Length; i++)
            {
                Char analyze = input.ToUpper()[i];

                if (Char.IsDigit(analyze) || ((analyze >= 'A') && (analyze <= 'F')))
                    parsedCode += analyze;

                else if (!(analyze == '[' || analyze == ']' || analyze == ')'
                    || analyze == '(' || analyze == ']' || analyze == '}'
                    || analyze == '{' || analyze == ' '))
                    return false;
            }
            if(parsedCode.Length > 8)
                return false;
            if (parsedCode.Length == 0)
                value = 0;
            else
                value = Convert.ToUInt32(parsedCode, 16);
            return true;
        }

        private static bool MinusSplit(String input, out UInt32[] splitted)
        {
            String[] minussplit = input.Split(new char[] { '-' });
            splitted = null;
            List<UInt32> LAddress = new List<UInt32>();
            UInt32 convert;
            bool hcconvert;
            for (int i = 0; i < minussplit.Length; i++)
            {
                hcconvert = HardcoreConvert(minussplit[i], out convert);
                if (!hcconvert)
                    return false;
                LAddress.Add(convert);
            }
            splitted = LAddress.ToArray();
            return true;
        }

        public static bool TryStrToAddressList(String input, out UInt32[] address)
        {
            List<UInt32> LAddress = new List<UInt32>();
            String[] plussplit = input.Split(new char[] { '+' },
                StringSplitOptions.RemoveEmptyEntries);

            address = null;

            bool hcConvert;
            UInt32[] splitted;
            UInt32 add;
            for (int i = 0; i < plussplit.Length; i++)
            {
                hcConvert = MinusSplit(plussplit[i], out splitted);
                if (!hcConvert)
                    return false;
                LAddress.Add(splitted[0]);
                for (int j = 1; j < splitted.Length; j++)
                {
                    if (splitted[j] == 0)
                    {
                        LAddress.Add(0);
                        continue;
                    }
                    add = (UInt32)((long)0x100000000 - (long)splitted[j]);
                    LAddress.Add(add);
                }
            }
            address = LAddress.ToArray();
            return true;
        }

        public static String addressToString(UInt32[] address)
        {
            if (address.Length == 0)
                return "";
            String output = GlobalFunctions.toHex(address[0]);
            UInt32 cv;
            char op;
            for (int i = 1; i < address.Length; i++)
            {
                output = "[" + output + "]";
                cv = address[i];
                if (address[i] > 0x80000000)
                {
                    op = '-';
                    cv = (UInt32)((long)0x100000000 - (long)cv);
                }
                else
                    op = '+';
                output += op + GlobalFunctions.shortHex(cv);
            }
            return output;
        }

        private List<WatchEntry> addressWatchList;
        private USBGecko gecko;
        private DataGridView watchOut;
        private Thread listManager;
        private NumericUpDown watchUpDown;
        private ExceptionHandler exceptionHandling;

        private bool listEnabled;
        private bool listActive;

        private bool PAddressDebug;
        public bool addressDebug
        {
            set
            {
                PAddressDebug = value;
            }
            get
            {
                return PAddressDebug;
            }
        }

        private bool enableDebug
        {
            get { return PAddressDebug && ValidMemory.addressDebug; }
        }

        public bool hasContent { get { return addressWatchList.Count > 0; } }

        private String ParseValue(UInt32 peekValue,WatchDataSize dataSize, UInt32 add, WatchEntry entry)
        {
            String pOutput="";
            UInt32 val;
            Single floatV;
            switch (dataSize)
            {
                case WatchDataSize.Bit8:
                    switch (add)
                    {
                         case 0: val = ((UInt32)(peekValue & 0xFF000000) >> 24);
                            break;
                         case 1: val = ((UInt32)(peekValue & 0x00FF0000) >> 16);
                            break;
                         case 2: val = ((UInt32)(peekValue & 0x0000FF00) >> 8);
                            break;
                        default: val = ((UInt32)(peekValue & 0x000000FF) >> 0);
                            break;
                    }
                    entry.lastValue = val;
                    pOutput = GlobalFunctions.toHex(val, 2);
                    break;
                case WatchDataSize.Bit16:
                    switch (add)
                    {
                        case 0: val = ((UInt32)(peekValue & 0xFFFF0000) >> 16);
                            break;
                        default: val = ((UInt32)(peekValue & 0x0000FFFF) >> 0);
                            break;                        
                    }
                    entry.lastValue = val;
                    pOutput = GlobalFunctions.toHex(val, 4);
                    break;
                case WatchDataSize.Bit32:
                    entry.lastValue = peekValue;
                    pOutput = GlobalFunctions.toHex(peekValue);
                    break;
                default:
                    entry.lastValue = peekValue;
                    floatV = GlobalFunctions.UIntToSingle(peekValue);
                    pOutput = floatV.ToString("G6");
                    break;
            }
            return pOutput;
        }

        private struct DoubleString
        {
            public String address;
            public String value;
        }

        public static bool isRowDisplayed(DataGridView varControl, int index)
        {
            bool foo = false;
            if (varControl.InvokeRequired)
            {
                varControl.Invoke((MethodInvoker)delegate
                {
                    foo = varControl.Rows[index].Displayed;
                });
                return foo;
            }
            else
            {
                return varControl.Rows[index].Displayed;
            }
        }

        private void UpdateList()
        {
            try
            {
                int i, j;
                UInt32[] address;
                UInt32 peekAddress, actAddress, peekValue;
                WatchDataSize dataSize;
                UInt32 dumpAnd;
                String aOutput, vOutput;
                UInt32 add;
                bool pointer, vPointer, vAddress;
                int maxCount = Math.Min(addressWatchList.Count, watchOut.RowCount);
                DoubleString[] oUp =
                    new DoubleString[maxCount];
                for (i = 0; i < maxCount; i++)
                {
                    // Skip over any rows that aren't displayed
                    if (!isRowDisplayed(watchOut, i))
                    {
                        continue;
                    }
                    address = addressWatchList[i].address;
                    pointer = address.Length > 1;
                    dataSize = addressWatchList[i].dataSize;
                    switch (dataSize)
                    {
                        case WatchDataSize.Bit8:
                            dumpAnd = 0xFFFFFFFF;
                            break;
                        case WatchDataSize.Bit16:
                            dumpAnd = 0xFFFFFFFE;
                            break;
                        default:
                            dumpAnd = 0xFFFFFFFC;
                            break;
                    }
                    vPointer = true;
                    peekAddress = address[0];

                    for (j = 1; j < address.Length; j++)
                    {
                        if (ValidMemory.validAddress(peekAddress, enableDebug))
                        {
                            peekAddress &= 0xFFFFFFFC;
                            peekAddress = gecko.peek(peekAddress);
                            peekAddress += address[j];
                        }
                        else
                        {
                            vPointer = false;
                            break;
                        }
                    }

                    vAddress = vPointer && ValidMemory.validAddress(peekAddress, enableDebug);
                    if (pointer)
                    {
                        aOutput = "P->";
                        if (vPointer)
                            aOutput += GlobalFunctions.toHex(peekAddress);
                        else
                            aOutput += "????????";
                    }
                    else
                    {
                        aOutput = GlobalFunctions.toHex(peekAddress);
                    }

                    if (vAddress)
                    {
                        actAddress = peekAddress;
                        peekAddress &= 0xFFFFFFFC;
                        add = actAddress - peekAddress;
                        add &= dumpAnd;
                        peekValue = gecko.peek(peekAddress);
                        vOutput = ParseValue(peekValue, dataSize, add, addressWatchList[i]);

                        addressWatchList[i].addressAvail = true;
                        addressWatchList[i].updatedAddress = peekAddress + add;
                    }
                    else
                    {
                        vOutput = "????????";
                        addressWatchList[i].addressAvail = false;
                    }
                    oUp[i].address = aOutput;
                    oUp[i].value = vOutput;
                    watchOut.Invoke((MethodInvoker)delegate
                     {
                         watchOut.Rows[i].Cells[1].Value = oUp[i].address;
                         watchOut.Rows[i].Cells[3].Value = oUp[i].value;
                     });
                }

                //watchOut.Invoke((MethodInvoker)delegate
                // {
                //     for (i = 0; i < maxCount; i++)
                //     {
                //         watchOut.Rows[i].Cells[1].Value = oUp[i].address;
                //         watchOut.Rows[i].Cells[3].Value = oUp[i].value;
                //     }
                // });
            }
            catch (EUSBGeckoException e)
            {
                listEnabled = false;
                exceptionHandling.HandleException(e);
            }
            catch
            {
            }
        }

        // Thread created to periodically update the list
        // TODO: make a timer from the main form call this instead?
        private void UpdateListThread()
        {
            while (listEnabled)
            {
                if (listActive && watchOut.Visible)
                {
                    UpdateList();                    
                }

                //Decimal sleepTime;
                //watchUpDown.Invoke((MethodInvoker)delegate
                //{
                //    return watchUpDown.Value;
                //});
                Decimal SleepTime = readNumericUpDownDecimal(watchUpDown);
                Thread.Sleep((int)Math.Floor((SleepTime)));
                //Thread.Sleep((int)Math.Floor((watchUpDown.Value)));
            }
        }

        public static Decimal readNumericUpDownDecimal(NumericUpDown varControl)
        {
            Decimal foo = 0;
            if (varControl.InvokeRequired)
            {
                varControl.Invoke((MethodInvoker)delegate
                {
                    foo = varControl.Value;
                    //return varControl.Value;
                });
                return foo;
            }
            else
            {
                Decimal varDecimal = varControl.Value;
                return varDecimal;
            }
        }

        public WatchList(USBGecko UGecko,DataGridView UWatchOut,NumericUpDown UWatchUpDown,ExceptionHandler UEXCHandler)
        {
            exceptionHandling = UEXCHandler;
            PAddressDebug = false;

            addressWatchList = new List<WatchEntry>();
            gecko = UGecko;
            watchOut = UWatchOut;
            watchUpDown = UWatchUpDown;
            listEnabled = true;
            listActive = true;
            listManager = new Thread(UpdateListThread);
            listManager.Start();
        }

        public void SuspendThread()
        {
            listActive = false;
        }

        public void ResumeThread()
        {
            listActive = true;
        }

        public void StopThread()
        {
            listEnabled = false;
            listManager.Abort();
            //listManager.Join();
        }

        public void AddWatch(String name, UInt32[] address, WatchDataSize dataSize)
        {
            String dType;
            switch (dataSize)
            {
                case WatchDataSize.Bit8:
                    dType = "8 bit";
                    break;
                case WatchDataSize.Bit16:
                    dType = "16 bit";
                    break;
                case WatchDataSize.Bit32:
                    dType = "32 bit";
                    break;
                default:
                    dType = "Single";
                    break;
            }
            watchOut.Rows.Add(1);
            int row = watchOut.Rows.Count - 1;            
            watchOut.Rows[row].Cells[0].Value = name;
            watchOut.Rows[row].Cells[1].Value = "????????";
            watchOut.Rows[row].Cells[2].Value = dType;
            watchOut.Rows[row].Cells[3].Value = "????????";

            addressWatchList.Add(new WatchEntry(name, address, dataSize));
        }

        public void DeleteSelected()
        {
            for (int i = watchOut.SelectedRows.Count - 1; i >= 0; i--)
            {
                int index = watchOut.SelectedRows[i].Index;
                addressWatchList.RemoveAt(index);
                watchOut.Rows.RemoveAt(index);
            }
        }

        public bool GetSelected(out WatchEntry entry)
        {
            entry = null;
            if (watchOut.SelectedRows.Count == 0)
                return false;
            entry = addressWatchList[watchOut.SelectedRows[0].Index];
            return entry.addressAvail;
        }

        public void UpdateEntry(String name, UInt32[] address, WatchDataSize dataSize)
        {
            if (watchOut.SelectedRows.Count == 0)
                return;

            int index = watchOut.SelectedRows[0].Index;
            
            String dType;
            switch (dataSize)
            {
                case WatchDataSize.Bit8:
                    dType = "8 bit";
                    break;
                case WatchDataSize.Bit16:
                    dType = "16 bit";
                    break;
                case WatchDataSize.Bit32:
                    dType = "32 bit";
                    break;
                default:
                    dType = "Single";
                    break;
            }

            watchOut.Rows[index].Cells[0].Value = name;
            watchOut.Rows[index].Cells[1].Value = "????????";
            watchOut.Rows[index].Cells[2].Value = dType;
            watchOut.Rows[index].Cells[3].Value = "????????";

            addressWatchList[index] = new WatchEntry(name, address, dataSize);
        }

        public void Clear()
        {
            addressWatchList.Clear();
            watchOut.Rows.Clear();
        }

        public bool LoadFromFile(String fileName,bool merge)
        {
            if (!File.Exists(fileName))
                return false;

            Xml watchList = new Xml(fileName);
            watchList.RootName = "watchlist";
            String[] sections = watchList.GetSectionNames();

            if (sections.Length == 0)
                return false;

            if(!merge)
                Clear();

            Array.Sort(sections);
            String sectionName, name, addressString;
            int sizeInt;
            WatchDataSize dataSize;
            UInt32[] address;

            for (int i = 0; i < sections.Length; i++)
            {
                sectionName = sections[i];
                if(!watchList.HasEntry(sections[i],"name"))
                    continue;
                if(!watchList.HasEntry(sections[i],"address"))
                    continue;

                name = watchList.GetValue(sections[i], "name", "Name");
                addressString = watchList.GetValue(sections[i], "address", "80000000");
                if (!TryStrToAddressList(addressString, out address))
                    continue;

                sizeInt = watchList.GetValue(sections[i], "size", 2);
                switch (sizeInt)
                {
                    case 0:
                        dataSize = WatchDataSize.Bit8;
                        break;
                    case 1:
                        dataSize = WatchDataSize.Bit16;
                        break;
                    case 3:
                        dataSize = WatchDataSize.SingleFp;
                        break;
                    default:
                        dataSize = WatchDataSize.Bit32;
                        break;
                }

                AddWatch(name, address, dataSize);
            }

            return true;
        }
        
        public void SaveToFile(String fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            Xml watchList = new Xml(fileName);
            watchList.RootName = "watchlist";

            WatchEntry current;
            String section;
            for (int i = 0; i < addressWatchList.Count; i++)
            {
                current = addressWatchList[i];
                section = "watch" + String.Format("{0:000}", i);
                watchList.SetValue(section, "name", current.name);
                watchList.SetValue(section, "address", 
                    addressToString(current.address));
                switch (current.dataSize)
                {
                    case WatchDataSize.Bit8:
                        watchList.SetValue(section, "size", 0);
                        break;
                    case WatchDataSize.Bit16:
                        watchList.SetValue(section, "size", 1);
                        break;
                    case WatchDataSize.SingleFp:
                        watchList.SetValue(section, "size", 3);
                        break;
                    default:
                        watchList.SetValue(section, "size", 2);
                        break;
                }                
            }
        }
    }
}
