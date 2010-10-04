using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

using FTDIUSBGecko;

namespace GeckoApp
{
    public struct CodeLine
    {
        public bool enabled;
        public UInt32 left;
        public UInt32 right;
    }

    public class CodeContent
    {
        public List<CodeLine> lines;

        public CodeContent()
        {
            lines = new List<CodeLine>();
        }
        public void addLine(UInt32 left,UInt32 right)
        {
            addLine(left, right, true);
        }
        public void addLine(UInt32 left, UInt32 right,bool enabled)
        {
            CodeLine newLine;
            newLine.left = left;
            newLine.right = right;
            newLine.enabled = enabled;
            lines.Add(newLine);
        }
    }

    public delegate void CodesModified();

    public class CodeController
    {
        private ListView codeOutput;
        private TextBox codeValues;

        private CodesModified PCodesModified;
        private bool activated;

        public CodeContent this[int i]
        {
            get
            {
                return (CodeContent)(codeOutput.Items[i].Tag);
            }

            set
            {
                codeOutput.Items[i].Tag = value;
            }
        }

        public String GetCodeName(int index)
        {
            return codeOutput.Items[index].Text;
        }

        public event CodesModified codesModified {
            add
            {
                PCodesModified += value;
            }
            remove
            {
                PCodesModified -= value;
            }
        }

        public int Count
        {
            get { return codeOutput.Items.Count; }
        }

        private int PSelectedIndex;
        public int SelectedIndex
        {
            get
            {
                return PSelectedIndex;
            }
            set
            {
                PSelectedIndex = value;
            }
        }


        public CodeController(ListView PCodeOutput,TextBox PCodeValues)
        {
            PSelectedIndex = -1;

            codeOutput = PCodeOutput;

            activated = false;

            codeOutput.Items.Clear();
            codeOutput.DragDrop += codeOutput_DragDrop;
            codeOutput.DragEnter += codeOutput_DragEnter;
            codeOutput.ItemDrag += codeOutput_ItemDrag;
            codeOutput.Click += codeOutput_SelectedIndexChanged;
            codeOutput.SelectedIndexChanged += codeOutput_SelectedIndexChanged;
            codeOutput.ItemChecked += codeOutput_ItemChecked;
            codeOutput.AfterLabelEdit += codeOutput_LabelChanged;
            codeOutput.VisibleChanged += codeOutput_Activate;
            codeOutput.LabelEdit = true;
            codeOutput.AllowDrop = true;
            codeOutput.MultiSelect = false;
            codeOutput.View = View.Details;

            codeValues = PCodeValues;
            codeValues.CharacterCasing = CharacterCasing.Upper;
            codeValues.Multiline = true;
            codeValues.AcceptsReturn = true;
        }

        private void SendModified()
        {
            if (PCodesModified != null && activated)
                PCodesModified();
        }

        public static CodeContent CodeTextBoxToCodeContent(String codeInput)
        {
            String parsedCode = "";
            String stripedUnknown = "";
            int i;

            // Check the text for a valid code
            for (i = 0; i < codeInput.Length; i++)
            {
                Char analyze = codeInput.ToUpper()[i];

                if (Char.IsDigit(analyze) || (analyze == '-' || analyze == '/') || ((analyze >= 'A') && (analyze <= 'F')))
                    stripedUnknown += analyze;
            }

            // Deactivating codes?
            int deactSigns = 0;
            List<int> deactCodes = new List<int>();
            for (i = 0; i < stripedUnknown.Length; i++)
            {
                Char analyze = stripedUnknown[i];

                if (analyze == '-' || analyze == '/')
                {
                    int pos = (i - deactSigns) / 16;
                    if (!deactCodes.Contains(pos))
                        deactCodes.Add(pos);
                    deactSigns++;
                }
                else
                    parsedCode += analyze;
            }

             CodeContent ncode = new CodeContent();

            // Make sure it's the right size too
            if (parsedCode.Length % 16 != 0)
            {
                MessageBox.Show("Adding 0s to fill up the code");
                int loopCount = 16 - parsedCode.Length % 16;
                for (int j = 0; j < loopCount; j++) parsedCode += "0";
            }

            String hexString;
            UInt32 left, right;
            bool enabled;

            for (i = 0; i < parsedCode.Length / 16; i++)
            {
                hexString = parsedCode.Substring(i * 16, 8);
                left = Convert.ToUInt32(hexString, 16);

                hexString = parsedCode.Substring(i * 16 + 8, 8);
                right = Convert.ToUInt32(hexString, 16);

                enabled = !deactCodes.Contains(i);

                ncode.addLine(left, right, enabled);
            }

            return ncode;
        }

        public bool UpdateCode(int index, String codeInput)
        {
            // If there aren't any codes, index will be -1
            // so don't do anything
            if (index == -1)
                return true;

            // Turn the text box into a code content
            CodeContent ncode = CodeTextBoxToCodeContent(codeInput);

            CodeContent oldContent = (CodeContent)codeOutput.Items[index].Tag;

            // No codes = must have been invalid!
            if (ncode.lines.Count != 0)
            {
                codeOutput.Items[index].Tag = ncode;
                SendModified();
            }

            return true;
            
        }

        public bool UpdateCode()
        {
            return UpdateCode(PSelectedIndex, codeValues.Text);
        }

        public void AddCode(String name) 
        {
            CodeContent newCode = new CodeContent();
            //newCode.name = name;            
            ListViewItem addCode = codeOutput.Items.Add(name);
            addCode.Tag = newCode;
            SendModified();
        }

        public void AddCode(CodeContent content,String name)
        {            
            ListViewItem addCode = codeOutput.Items.Add(name);
            addCode.Tag = content;
            SendModified();
        }

                        //codeOutput.Items[i].Tag = value;


        // Adds a Code to the indexed code
        public void AddCode(CodeContent content, int index)
        {
            if (index > -1 && index < codeOutput.Items.Count)
            {
                //CodeContent oldCode = (CodeContent)(codeOutput.Items[index].Tag);
                CodeContent newCode = new CodeContent();
                //foreach (CodeLine line in oldCode.lines)
                //{
                //    newCode.addLine(line.left, line.right);
                //}
                foreach (CodeLine line in content.lines)
                {
                    newCode.addLine(line.left, line.right);
                }
                codeOutput.Items[index].Tag = newCode;
            }
            SendModified();
        }

        public void Remove(int index)
        {
            if (index < codeOutput.Items.Count)
            {
                codeOutput.Items[index].Selected = false;
                codeOutput.Items.RemoveAt(index);
                SendModified();
            }
            PSelectedIndex = -1;
            codeValues.Text = "";
            codeValues.Enabled = false;
        }

        public void Clear()
        {
            bool mod = false;
            while (codeOutput.Items.Count > 0)
            {
                Remove(0);
                mod = true;
            }
            if (mod)
                SendModified();
        }

        //Drag and drop code stolen from Microsoft.com ^^
        private void codeOutput_DragEnter(object sender, DragEventArgs e)
        {
            UpdateCode();
            codeOutput.Click -= codeOutput_SelectedIndexChanged;
            int len = e.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    //The data from the drag source is moved to the target.	
                    e.Effect = DragDropEffects.Move;
                }
            }

        }

        private void codeOutput_DragDrop(object sender, DragEventArgs e)
        {
            //Return if the items are not selected in the ListView control.
            if (codeOutput.SelectedItems.Count == 0)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            System.Drawing.Point cp = codeOutput.PointToClient(new System.Drawing.Point(e.X, e.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewItem dragToItem = codeOutput.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragToIndex = dragToItem.Index;
            ListViewItem[] sel = new ListViewItem[codeOutput.SelectedItems.Count];
            for (int i = 0; i <= codeOutput.SelectedItems.Count - 1; i++)
            {
                sel[i] = codeOutput.SelectedItems[i];
            }
            bool modified = false;
            for (int i = 0; i < sel.GetLength(0); i++)
            {
                //Obtain the ListViewItem to be dragged to the target location.
                ListViewItem dragItem = sel[i];
                int itemIndex = dragToIndex;
                if (itemIndex == dragItem.Index)
                {
                    return;
                }
                if (dragItem.Index < itemIndex)
                    itemIndex++;
                else
                    itemIndex = dragToIndex + i;
                //Insert the item at the mouse pointer.
                int dragPosition = dragItem.Index;
                ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                codeOutput.SelectedItems.Clear();
                codeOutput.Items.Insert(itemIndex, insertItem);                
                //Removes the item from the initial location while 
                //the item is moved to the new location.
                codeOutput.Items.Remove(dragItem);
                modified = true;
            }
            if (modified)
                SendModified();
            //PSelectedIndex = -1;         
            codeOutput.Items[dragToIndex].Selected = true;
            codeOutput.FocusedItem = codeOutput.SelectedItems[0];
            //codeOutput_SelectedIndexChanged(sender, e);
            //codeValues.Text = "";
            //codeValues.Enabled = false;
            codeOutput.Click += codeOutput_SelectedIndexChanged;
        }

        private void codeOutput_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //Begins a drag-and-drop operation in the ListView control.
            codeOutput.DoDragDrop(codeOutput.SelectedItems, DragDropEffects.Move);
        }

        public void codeOutput_Activate(object sender, EventArgs e)
        {
            activated = codeOutput.Visible;
        }

        private void codeOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newIndex;
            if (codeOutput.SelectedIndices.Count == 0)
                newIndex = -1;
            else
                newIndex = codeOutput.SelectedIndices[0];

            if (newIndex == PSelectedIndex)
                return;

            if (!UpdateCode())
            {
                codeOutput.Items[PSelectedIndex].Selected = true;
                return;
            }

            codeValues.Clear();
            if (newIndex == -1 || newIndex >= codeOutput.Items.Count)
            {
                PSelectedIndex = -1;
                codeValues.Enabled = false;
            }
            else
            {
                PSelectedIndex = newIndex;
                CodeContent codeData;
                if (codeOutput.Items[newIndex].Tag == null)
                    codeData = new CodeContent();
                else
                    codeData = (CodeContent)codeOutput.Items[newIndex].Tag;
                codeValues.Enabled = true;
                //String output = "";
                //for (int i = 0; i < codeData.lines.Count; i++)
                //{
                //    if (!codeData.lines[i].enabled)
                //        output += "--";
                //    output += String.Format("{0:X8} ", codeData.lines[i].left);
                //    output += String.Format("{0:X8}\r\n", codeData.lines[i].right);
                //}
                codeValues.Text = CodeContentToCodeTextBox(codeData);
            }
        }

        public static String CodeContentToCodeTextBox(CodeContent codeData)
        {
            String output = "";
            for (int i = 0; i < codeData.lines.Count; i++)
            {
                if (!codeData.lines[i].enabled)
                    output += "--";
                output += String.Format("{0:X8} ", codeData.lines[i].left);
                output += String.Format("{0:X8}\r\n", codeData.lines[i].right);
            }
            return output;
        }

        private void codeOutput_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            SendModified();
        }

        private void codeOutput_LabelChanged(object sender, LabelEditEventArgs e)
        {
            //if (codes[e.Item].name != e.Label)
            //{
            //    codes[e.Item].name = e.Label;
                SendModified();
            //}
        }

        private Byte[] toStream(UInt32 value)
        {
            return BitConverter.GetBytes(ByteSwap.Swap(value));
        }

        public void GenerateCheatStream(Stream output)
        {
            if (output.CanWrite) 
            {
                output.SetLength(0);
                output.Seek(0, SeekOrigin.Begin);
                output.Write(toStream(0x00D0C0DE),0,4);
                output.Write(toStream(0x00D0C0DE),0,4);

                CodeContent cCode;
                foreach (ListViewItem li in codeOutput.Items)
                    if (li.Checked)
                    {
                        if (li.Tag == null)
                            cCode = new CodeContent();
                        else
                            cCode = (CodeContent)li.Tag;
                        foreach (CodeLine line in cCode.lines)
                        {
                            if (line.enabled)
                            {
                                output.Write(toStream(line.left), 0, 4);
                                output.Write(toStream(line.right), 0, 4);
                            }
                        }
                    }

                //output.Write(toStream(0xF0000000), 0, 4);
                //output.Write(toStream(0x00000000), 0, 4);
                // Testing!  WiiRD uses all F's instead of F0
                output.Write(toStream(0xFFFFFFFF), 0, 4);
                output.Write(toStream(0xFFFFFFFF), 0, 4);
            }
        }

        public void toWGCFile(String output)
        {
            StreamWriter textFile;
            textFile = new StreamWriter(output, false, Encoding.UTF8);
            String prepend;

            for(int i = 0;i<codeOutput.Items.Count;i++) 
            {
                CodeContent cCode;
                if (codeOutput.Items[i].Tag == null)
                    cCode = new CodeContent();
                else
                    cCode = (CodeContent)codeOutput.Items[i].Tag;

                textFile.WriteLine("[" + codeOutput.Items[i].Text + "]");
                prepend = (codeOutput.Items[i].Checked ? "* ":"  ");                
                foreach(CodeLine line in cCode.lines) {
                    if (line.enabled)
                        textFile.Write(prepend);
                    else
                        textFile.Write("- ");
                    textFile.Write(String.Format("{0:X8} ",line.left));
                    textFile.WriteLine(String.Format("{0:X8}",line.right));
                }
                textFile.WriteLine("");
            }

            textFile.Close();
        }

        public void fromWGCFile(String input)
        {
            if (!File.Exists(input))
                return;

            //codes.Clear();
            //codeOutput.Clear();
            //codeValues.Enabled = false;

            StreamReader reader = new StreamReader(input,true);
            String line, cName;
            CodeContent nCode = null;
            ListViewItem nLI = null;
            String parsedCode;
            UInt32 left, right;
            bool lEnabled = true;

            int i;
            bool cCEnabled = false;

            codeOutput.ItemChecked -= codeOutput_ItemChecked;
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                if (line.Length == 0)
                    continue;

                if (line[0] == '[')
                {
                    cName = line.Substring(1, line.Length - 2);
                    if (nCode != null)
                    {
                        nLI.Checked = cCEnabled;
                    }
                    nCode = new CodeContent();
                    //nCode.name = cName;
                    nLI = codeOutput.Items.Add(cName);
                    nLI.Tag = nCode;
                    cCEnabled = false;
                    continue;
                }
                lEnabled = true;
                if (nCode == null)
                    continue;
                if (line[0] == '*')
                    cCEnabled = true;
                else if (line[0] == '-')
                    lEnabled = false;
                parsedCode = "";

                for (i = 0; i < line.Length; i++)
                {
                    Char analyze = line.ToUpper()[i];

                    if (Char.IsDigit(analyze) || ((analyze >= 'A') && (analyze <= 'F')))
                        parsedCode += analyze;
                }
                if (parsedCode.Length != 16)
                    continue;

                left = Convert.ToUInt32(parsedCode.Substring(0, 8), 16);
                right = Convert.ToUInt32(parsedCode.Substring(8, 8), 16);
                nCode.addLine(left, right, lEnabled);
            }
            reader.Close();
            if (cCEnabled && nCode != null)
            {
                nLI.Checked = cCEnabled;
            }
            codeOutput.Update();
            codeOutput.ItemChecked += codeOutput_ItemChecked;
        }
    }
}
