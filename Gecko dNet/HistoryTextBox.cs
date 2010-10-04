using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp.external
{
    public partial class HistoryTextBox : TextBox
    {
        private bool autoHistory;

        [Browsable(true)]
        public bool AutoHistory
        {
            get { return autoHistory; }
            set { autoHistory = value; }
        }

        public HistoryTextBox()
        {
            InitializeComponent();

            comboBoxHistory.Parent = this.Parent;
            comboBoxHistory.Location = this.Location;
            comboBoxHistory.Width = this.Width;
            comboBoxHistory.MaxLength = this.MaxLength;
            comboBoxHistory.Font = this.Font;
        }

        private void HistoryTextBox_Layout(object sender, LayoutEventArgs e)
        {
            comboBoxHistory.Parent = this.Parent;
            comboBoxHistory.Location = this.Location;
            comboBoxHistory.Width = this.Width;
            comboBoxHistory.DropDownWidth = comboBoxHistory.Width + 15;
        }

        private void HistoryTextBox_LocationChanged(object sender, EventArgs e)
        {
            comboBoxHistory.Location = this.Location;
        }
        
        private void HistoryTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!comboBoxHistory.DroppedDown)
            {
                comboBoxHistory.SelectedIndex = comboBoxHistory.Items.IndexOf(this.Text);
            }
            ShowHistory(true);
       }

        private void comboBoxHistory_DropDownClosed(object sender, EventArgs e)
        {
            ShowHistory(false);
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
            HistoryTextBox_KeyDown(null, keyCode);
        }

        private void HistoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
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
                        RemoveTextFromHistory(selectedString.ToString());
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
                    AddTextToHistory();
                    handled = true;
                    HistoryShown = true;
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    RemoveTextFromHistory();
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

        private void HistoryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\n')
            {
                // This is a control-enter, I believe
                // We shut it up because it makes beepy sounds
                e.Handled = true;
            }
        }

        public void AddTextToHistory(string addMe)
        {
            if (!comboBoxHistory.Items.Contains(addMe))
            {
                comboBoxHistory.Items.Add(addMe);
            }

            if (comboBoxHistory.Items.Contains(String.Empty))
            {
                comboBoxHistory.Items.Remove(String.Empty);
            }
        }

        public void AddTextToHistory()
        {
            AddTextToHistory(this.Text);
        }

        public void RemoveTextFromHistory(string removeMe)
        {
            if (comboBoxHistory.Items.Contains(removeMe))
            {
                comboBoxHistory.Items.Remove(removeMe);
            }
        }

        public void RemoveTextFromHistory()
        {
            RemoveTextFromHistory(this.Text);
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

        public void CopyStringToHistory(String newHistory)
        {
            String[] sep = newHistory.Split(new char[] { '\r', '\n' });
            foreach (String entry in sep)
            {
                AddTextToHistory(entry);
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

        private void HistoryTextBox_Leave(object sender, EventArgs e)
        {
            if (AutoHistory)
            {
                AddTextToHistory();
            }
        }

        private void HistoryTextBox_ContextMenuStripChanged(object sender, EventArgs e)
        {
            comboBoxHistory.ContextMenuStrip = this.ContextMenuStrip;
        }
    }
}
