using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp.external
{
    public partial class AddressTextBox : TextBox
    {
        private Color colorAddressGood, colorAddressBad;

        private bool autoHistory;
        private bool endingAddress;
        private bool multiPokeAddress;

        [Browsable(true)]
        public bool AutoHistory
        {
            get { return autoHistory; }
            set { autoHistory = value; }
        }

        [Browsable(true)]
        public bool EndingAddress
        {
            get { return endingAddress; }
            set { endingAddress = value; }
        }

        [Browsable(true)]
        public bool MultiPokeAddress
        {
            get { return multiPokeAddress; }
            set { multiPokeAddress = value; }
        }

        public AddressTextBox()
        {
            InitializeComponent();
            this.Width = 62;
            this.MaxLength = 8;
            CharacterCasing = CharacterCasing.Upper;
            this.Font = new Font("Courier New", (float)8.25);
            comboBoxHistory.Parent = this.Parent;
            comboBoxHistory.Location = this.Location;
            comboBoxHistory.Width = this.Width;
            comboBoxHistory.MaxLength = this.MaxLength;
            comboBoxHistory.Font = this.Font;

            colorAddressBad = Color.FromArgb(255, 200, 200);
            colorAddressGood = this.BackColor;
        }

        private void AddressTextBox_Layout(object sender, LayoutEventArgs e)
        {
            comboBoxHistory.Parent = this.Parent;
            comboBoxHistory.Location = this.Location;
            comboBoxHistory.Width = this.Width;
            comboBoxHistory.DropDownWidth = comboBoxHistory.Width + 15;
        }

        private void AddressTextBox_LocationChanged(object sender, EventArgs e)
        {
            comboBoxHistory.Location = this.Location;
        }
        
        private void AddressTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //SendToBack();
            //comboBoxHistory.BringToFront();
            if (!comboBoxHistory.DroppedDown)
            {
                comboBoxHistory.SelectedIndex = comboBoxHistory.Items.IndexOf(this.Text);
            }
             ShowHistory(true);
       }

        private void comboBoxHistory_DropDownClosed(object sender, EventArgs e)
        {
            ShowHistory(false);
            //BringToFront();
            //comboBoxHistory.SendToBack();
        }

        private void comboBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHistory.SelectedItem != null)
            {
                this.Text = comboBoxHistory.SelectedItem.ToString();
            }
        }

        public void SendKeyCode(KeyEventArgs keyCode)
        {
            AddressTextBox_KeyDown(null, keyCode);
        }

        private void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Show history if user presses down or up
            //if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            //{
            //    ShowHistory(true);
            //}
            //else
            //{
            //    ShowHistory(false);
            //}

            bool HistoryShown = false, handled = false;

            if (e.KeyCode == Keys.Down)
            {
                // If there are any items...
                if (comboBoxHistory.Items.Count > 0)
                {
                    int index;
                    // if showing, and current text is in the history, start with that index
                    if (!comboBoxHistory.DroppedDown)
                    {
                        index = comboBoxHistory.Items.IndexOf(this.Text);
                    }
                    else
                    {
                        index = comboBoxHistory.SelectedIndex + 1;
                    }

                    // select the next one, and wrap around if necessary
                    // note this doesn't have to worry about selectedIndex == -1 (i.e. no item)
                    if (index == comboBoxHistory.Items.Count)
                    {
                        index = 0;
                    }


                    string oldItem = this.Text;
                    comboBoxHistory.SelectedIndex = index;
                    this.Text = oldItem;
                }
                handled = true;
                HistoryShown = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                // If there are any items...
                if (comboBoxHistory.Items.Count > 0)
                {
                    int index = comboBoxHistory.SelectedIndex;
                    // select the next one, and wrap around if necessary
                    // This tests both against 0, and against none
                    if (index < 1)
                    {
                        index = comboBoxHistory.Items.Count;
                    }
                    if (!comboBoxHistory.DroppedDown)
                    {
                        index = comboBoxHistory.Items.IndexOf(this.Text);
                    }
                    else
                    {
                        index--;
                    }
                    string oldItem = this.Text;
                    comboBoxHistory.SelectedIndex = index;
                    this.Text = oldItem;
                }
                handled = true;
                HistoryShown = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (comboBoxHistory.Items.Count > 0)
                {
                    object selectedString = comboBoxHistory.SelectedItem;
                    int index = Math.Min(comboBoxHistory.SelectedIndex, comboBoxHistory.Items.Count - 2);
                    if (selectedString != null && comboBoxHistory.DroppedDown)
                    {
                        RemoveAddressFromHistory(selectedString.ToString());
                        comboBoxHistory.SelectedIndex = index;
                    }
                }
                handled = true;
                HistoryShown = true;
            }

            if (e.KeyCode == Keys.Enter && comboBoxHistory.DroppedDown && comboBoxHistory.Items.Count > 0)
            {
                if (comboBoxHistory.SelectedItem != null)
                {
                    this.Text = comboBoxHistory.SelectedItem.ToString();
                }
            }

            if (e.Control)
            {
                if (e.Shift)
                {
                    // ctrl + shift to affect all history - copy, cut, paste, delete
                    if (e.KeyCode == Keys.C)
                    {
                        CopyHistoryToClipboard();
                        // Prevent the normal ctrl+c that gets handled by KeyPress from replacing our clipboard
                        this.DeselectAll();
                        handled = true;
                        HistoryShown = true;
                    }
                    else if (e.KeyCode == Keys.X)
                    {
                        CopyHistoryToClipboard();
                        ClearHistory();
                        this.DeselectAll();
                        handled = true;
                        HistoryShown = true;
                    }
                    else if (e.KeyCode == Keys.V)
                    {
                        CopyClipboardToHistory();
                        handled = true;
                        HistoryShown = true;
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        ClearHistory();
                        handled = true;
                        HistoryShown = true;
                    }
                }
                // ctrl + keys to affect current
                else if (e.KeyCode == Keys.Enter)
                {
                    AddAddressToHistory();
                    handled = true;
                    HistoryShown = true;
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    RemoveAddressFromHistory();
                    handled = true;
                    HistoryShown = true;
                }
            }

            // Don't let control or shift close an opened history
            if ((e.Control || e.Shift) && comboBoxHistory.DroppedDown)
            {
                HistoryShown = true;
            }

            ShowHistory(HistoryShown);
            e.Handled = handled;
        }

        private void AddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
            {
                // This is a control-enter, I believe
                // We shut it up because it makes beepy sounds
                e.Handled = true;
            }
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            String text = this.Text;
            if (multiPokeAddress)
            {
                text = System.Text.RegularExpressions.Regex.Replace(text, "[^A-FMP0-9]", String.Empty);
            }
            else
            {
                text = System.Text.RegularExpressions.Regex.Replace(text, "[^A-F0-9]", String.Empty);
            }
            this.Text = text;

            // color address text box background according to validity
            if ((multiPokeAddress && this.Text.Equals("MP")) || IsValid())
            {
                this.BackColor = colorAddressGood;
            }
            else
            {
                this.BackColor = colorAddressBad;
            }
        }

        public void AddAddressToHistory(string addMe)
        {
            if (IsValid(addMe) && !comboBoxHistory.Items.Contains(addMe))
            {
                comboBoxHistory.Items.Add(addMe);
            }

            if (comboBoxHistory.Items.Contains(String.Empty))
            {
                comboBoxHistory.Items.Remove(String.Empty);
            }
        }

        public void AddAddressToHistory(uint address)
        {
            AddAddressToHistory(GlobalFunctions.toHex(address));
        }

        public void AddAddressToHistory()
        {
            AddAddressToHistory(this.Text);
        }

        public void RemoveAddressFromHistory(string removeMe)
        {
            if (comboBoxHistory.Items.Contains(removeMe))
            {
                comboBoxHistory.Items.Remove(removeMe);
            }
        }

        public void RemoveAddressFromHistory()
        {
            RemoveAddressFromHistory(this.Text);
        }

        public void ClearHistory()
        {
            comboBoxHistory.Items.Clear();
        }

        public int GetHistoryCount()
        {
            return comboBoxHistory.Items.Count;
        }

        public string GetHistoryString(int index)
        {
            return comboBoxHistory.Items[index].ToString();
        }

        public uint GetHistoryuint(int index)
        {
            uint foo = 0x80000000;
            GlobalFunctions.tryToHex(comboBoxHistory.Items[index].ToString(), out foo);
            return foo;
        }

        public void CopyStringToHistory(String newHistory)
        {
            String[] sep = newHistory.Split(new char[] { '\r', '\n' });
            foreach (String entry in sep)
            {
                AddAddressToHistory(entry);
            }
        }

        public String GetStringFromHistory()
        {
            String result = String.Empty;

            foreach (Object entry in comboBoxHistory.Items)
            {
                result += entry.ToString();
                if (entry != comboBoxHistory.Items[comboBoxHistory.Items.Count-1])
                {
                    result += "\r\n";
                }
            }
            return result;
        }

        public void CopyHistoryToClipboard()
        {
            Clipboard.SetText(GetStringFromHistory());
        }

        public void CopyClipboardToHistory()
        {
            CopyStringToHistory(Clipboard.GetText());
        }

        public bool IsValidGet(string checkMe, bool showMessages, out uint value)
        {
            uint newValue;
            if (GlobalFunctions.tryToHex(checkMe, out newValue))
            {
                if (ValidMemory.validAddress(newValue))
                {
                    value = newValue;
                    return true;
                }
                else if (endingAddress && ValidMemory.validAddress(newValue - 1))
                {
                    value = newValue;
                    return true;
                }
                else
                {
                    if (showMessages)
                    {
                        MessageBox.Show("Address is not a valid 32-bit hex string");
                    }
                }
            }
            else
            {
                if (showMessages)
                {
                    MessageBox.Show("Address is not in valid range of Wii memory");
                }
            }

            value = 0x80000000;
            return false;
        }

        public bool IsValidGet(bool showErrorMessages, out uint value)
        {
            return IsValidGet(this.Text, showErrorMessages, out value);
        }

        public bool IsValidGet(out uint value)
        {
            return IsValidGet(this.Text, false, out value);
        }

        public bool IsValid(string checkMe, bool showErrorMessages)
        {
            uint newValue;
            return IsValidGet(checkMe, showErrorMessages, out newValue);
        }

        public bool IsValid(string checkMe)
        {
            return IsValid(checkMe, false);
        }

        public bool IsValid()
        {
            return IsValid(this.Text);
        }

        public void ShowHistory(bool shown)
        {
            comboBoxHistory.Visible = shown;
            if (comboBoxHistory.Items.Count == 0)
            {
                comboBoxHistory.Items.Add(String.Empty);
            }
            comboBoxHistory.DroppedDown = shown;
            if (shown)
            {
                comboBoxHistory.BringToFront();
                BringToFront();
            }
            else
            {
                comboBoxHistory.SendToBack();
            }
        }

        private void AddressTextBox_Leave(object sender, EventArgs e)
        {
            if (AutoHistory)
            {
                AddAddressToHistory();
            }
        }

        private void AddressTextBox_ContextMenuStripChanged(object sender, EventArgs e)
        {
            comboBoxHistory.ContextMenuStrip = this.ContextMenuStrip;
        }

        public void AddOffsetToAddress(String offset)
        {
                try
                {
                    bool negative = false;
                    if (offset.Contains("-"))
                    {
                        offset = offset.Replace("-", String.Empty);
                        negative = true;
                    }
                    int casted = Convert.ToInt32(offset, 16);
                    if (negative) casted *= -1;
                    AddOffsetToAddress(casted);
                }
                catch (FormatException)
                {
                }
        }

        public void AddOffsetToAddress(int offset)
        {
            uint address;
            IsValidGet(out address);
            address = (uint)(address + offset);
            this.Text = String.Format("{0:X}", address);
        }
    }
}
