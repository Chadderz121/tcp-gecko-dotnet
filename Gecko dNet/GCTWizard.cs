using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp
{
    public partial class GCTWizard : Form
    {
        private object[] RAMWriteCollection;
        private object[] IfThenCollection;
        private object[] BasePointerCollection;
        private int indexToSelect;

        private CodeController GCTCodeContents;

        public int SelectedCodeNameIndex
        {
            get
            {
                return Math.Min(Math.Max(comboBoxCodeName.SelectedIndex, 0), GCTCodeContents.Count);
            }
            set
            {
                if (value <= GCTCodeContents.Count && value >= 0)
                    comboBoxCodeName.SelectedIndex = value;
            }
        }

        public GCTWizard(CodeController codeController)
        {
            InitializeComponent();
            RAMWriteCollection = new String[] {
                "Write",
                "Fill" };
            IfThenCollection = new String[] {
                "equal",
                "not equal",
                "greater",
                "lesser" };
            //BasePointerCollection = new String[] {
            //    "Load into",
            //    "Set to",
            //    "Save to",
            //    "Load Code Address", };

            GCTCodeContents = codeController;
        }

        private void comboBoxCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCodeType.SelectedIndex)
            {
                case 0:
                    comboBoxCodeSubType.Items.Clear();
                    comboBoxCodeSubType.Items.AddRange(RAMWriteCollection);
                    break;
                case 1:
                    comboBoxCodeSubType.Items.Clear();
                    comboBoxCodeSubType.Items.AddRange(IfThenCollection);
                    break;
                //case 2:
                //    comboBoxCodeSubType.Items.Clear();
                //    comboBoxCodeSubType.Items.AddRange(BasePointerCollection);
                //    break;
                default:
                    comboBoxCodeSubType.Items.Clear();
                    comboBoxCodeSubType.Items.AddRange(RAMWriteCollection);
                    break;
            }
            comboBoxCodeSubType.SelectedIndex = 0;
        }

        public void PrepareGCTWizard(int selectedCodeIndex)
        {
            // Select the correct code type
            comboBoxCodeType.SelectedIndex = 0;

            // Populate the code name drop down
            comboBoxCodeName.Items.Clear();
            for (int i = 0; i < GCTCodeContents.Count; i++)
            {
                comboBoxCodeName.Items.Add(GCTCodeContents.GetCodeName(i));
            }
            comboBoxCodeName.Items.Add("New Code");
            indexToSelect = selectedCodeIndex;
            //GCTCodeContents.SelectedIndex;
            //comboBoxCodeName.SelectedIndex = 0;
        }

        private void GCTWizard_Shown(object sender, EventArgs e)
        {
            SelectedCodeNameIndex = indexToSelect;
        }

        private void comboBoxCodeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = SelectedCodeNameIndex;
            if (comboBoxCodeName.SelectedIndex != index)
            {
                comboBoxCodeName.SelectedIndex = index;
            }

            if (comboBoxCodeName.SelectedIndex == comboBoxCodeName.Items.Count - 1)
            {
                textBoxCodeEntries.Text = String.Empty;
            }
            else
            {
                textBoxCodeEntries.Text = CodeController.CodeContentToCodeTextBox(GCTCodeContents[comboBoxCodeName.SelectedIndex]);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private bool ValidUserAddress(out UInt32 address)
        {
            // Is it a valid 32-bit hexadecimal address?
            if (!GlobalFunctions.tryToHex(textBoxAddress.Text, out address) ||
                !ValidMemory.validAddress(address))
            {
                MessageBox.Show("Invalid address");
                textBoxAddress.Focus();
                textBoxAddress.SelectAll();
                return false;
            }

            // Check alignment
            if (radioButton16Bit.Checked && ((address & 1) != 0))
            {
                MessageBox.Show("address must be multiple of 2");
                textBoxAddress.Focus();
                textBoxAddress.SelectAll();
                return false;
            }
            else if (radioButton32Bit.Checked && ((address & 3) != 0))
            {
                MessageBox.Show("address must be multiple of 4");
                textBoxAddress.Focus();
                textBoxAddress.SelectAll();
                return false;
            }

            return true;
        }

        private bool ValidUserValue(out UInt32 value)
        {
            if (!GlobalFunctions.tryToHex(textBoxValue.Text, out value))
            {
                MessageBox.Show("Invalid value");
                textBoxValue.Focus();
                textBoxValue.SelectAll();
                return false;
            }

            // Check size
            if (radioButton16Bit.Checked && value > 0xFFFF)
            {
                MessageBox.Show("value must be <= FFFF");
                textBoxValue.Focus();
                textBoxValue.SelectAll();
                return false;
            }
            else if (radioButton8Bit.Checked && value > 0xFF)
            {
                MessageBox.Show("value must be <= FF");
                textBoxValue.Focus();
                textBoxValue.SelectAll();
                return false;
            }

            return true;
        }

        private bool ValidUserMask(out UInt32 mask)
        {
            if (radioButton32Bit.Checked)
            {
                // Mask is unused by 32-bit if
                mask = 0;
                return true;
            }

            if (!GlobalFunctions.tryToHex(textBoxMask.Text, out mask))
            {
                MessageBox.Show("Invalid mask");
                textBoxMask.Focus();
                textBoxMask.SelectAll();
                return false;
            }

            if (mask > 0xFFFF)
            {
                MessageBox.Show("mask must be <= FFFF");
                textBoxMask.Focus();
                textBoxMask.SelectAll();
                return false;
            }

            return true;
        }

        private bool ValidUserFill(out UInt32 fill)
        {
            if (radioButton32Bit.Checked)
            {
                // fill is unused by 32-bit if
                fill = 0;
                return true;
            }

            if (comboBoxCodeSubType.SelectedIndex == 0)
            {
                // "Write" sub-type is a fill of 0!
                fill = 0;
                return true;
            }

            if (!GlobalFunctions.tryToHex(textBoxFill.Text, out fill))
            {
                MessageBox.Show("Invalid fill");
                textBoxFill.Focus();
                textBoxFill.SelectAll();
                return false;
            }

            if (fill > 0xFFFF)
            {
                MessageBox.Show("fill must be <= FFFF");
                textBoxFill.Focus();
                textBoxFill.SelectAll();
                return false;
            }

            return true;
        }

        private void AddCodeRAMWrite()
        {
            // Validate user inputs
            UInt32 address, value, fill;

            bool addFill = comboBoxCodeSubType.SelectedIndex == 1;

            if (!ValidUserAddress(out address)) return;

            if (!ValidUserValue(out value)) return;

            if (!ValidUserFill(out fill)) return;

            UInt32 add;

            // Get the size
            if (radioButton8Bit.Checked)
            {
                // fill will be 0 if there is no fill to use
                value |= (fill << 16);

                add = 0x00000000;
            }
            else if (radioButton16Bit.Checked)
            {
                value |= (fill << 16);

                add = 0x02000000;
            }
            else
            {
                add = 0x04000000;
            }

            StandardCodeAddressStuff(address, value, add);
        }

        private void AddCodeIfThen()
        {
            // Validate user inputs
            UInt32 address, value, mask;

            if (!ValidUserAddress(out address)) return;

            if (!ValidUserValue(out value)) return;

            if (!ValidUserMask(out mask)) return;
            
            UInt32 add;

            // Get the size
            if (radioButton8Bit.Checked)
            {
                MessageBox.Show("Can't do 8-bit if");
                return;
            }
            else if (radioButton16Bit.Checked)
            {
                add = 0x28000000;
                value = (mask << 16) | value;
            }
            else
            {
                add = 0x20000000;
            }

            // Get the type of comparison
            if (comboBoxCodeSubType.SelectedIndex == 0)    // equals
            {
                add += 0;
            }
            else if (comboBoxCodeSubType.SelectedIndex == 1)    // not equals
            {
                add += 0x02000000;
            }
            else if (comboBoxCodeSubType.SelectedIndex == 2)    // greater
            {
                add += 0x04000000;
            }
            else if (comboBoxCodeSubType.SelectedIndex == 3)    // lesser
            {
                add += 0x06000000;
            }

            // End if?
            if (checkBoxEndIf.Checked)
            {
                add += 0x00000001;
            }

            StandardCodeAddressStuff(address, value, add);
        }

        private void StandardCodeAddressStuff(UInt32 address, UInt32 value, UInt32 add)
        {
            CodeContent nCode = CodeController.CodeTextBoxToCodeContent(textBoxCodeEntries.Text);
            //UInt32 cAddressR = 0x80000000;
            UInt32 rAddressR;
            UInt32 offset;

            // base address is masked differently than pointer offset
            if (radioButtonBA.Checked)
            {
                rAddressR = address & 0xFE000000;
            }
            else
            {
                // TODO the po doesn't actually have this restriction
                // but for now we keep it like the ba
                //rAddressR = address & 0xFEFFFFFF;
                rAddressR = address & 0xFE000000;
                add += 0x10000000;
            }

            // Do we need to change the ba or po?
            bool changeBAorPO = false;
            if ((address & 0xFE000000) != 0x80000000)
            {
                changeBAorPO = true;
            }

            if (changeBAorPO)
            {
                if (radioButtonBA.Checked)
                {
                    nCode.addLine(0x42000000, rAddressR);
                }
                else
                {
                    nCode.addLine(0x4A000000, rAddressR);
                }
            }

            // Add the actual code
            offset = address - rAddressR + add;
            nCode.addLine(offset, value);

            // Add terminator if necessary
            if (changeBAorPO)
            {
                nCode.addLine(0xE0000000, 0x80008000);
            }

            textBoxCodeEntries.Text = CodeController.CodeContentToCodeTextBox(nCode);
        }

        private void buttonAddCode_Click(object sender, EventArgs e)
        {
            switch (comboBoxCodeType.SelectedIndex)
            {
                case 0: AddCodeRAMWrite(); break;
                case 1: AddCodeIfThen(); break;
                default: AddCodeRAMWrite(); break;
            }
        }

        private void buttonStoreCode_Click(object sender, EventArgs e)
        {
            CheckNewCodeName();
            GCTCodeContents.UpdateCode(SelectedCodeNameIndex, textBoxCodeEntries.Text);
        }

        private void comboBoxCodeName_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user hits enter...
            if (e.KeyCode == Keys.Enter)
            {
                CheckNewCodeName();
            }
        }


        private void CheckNewCodeName()
        {
            // And the current text does not exist as a code name...
            if (comboBoxCodeName.FindStringExact(comboBoxCodeName.Text) == -1)
            {
                // Add a new entry
                GCTCodeContents.AddCode(comboBoxCodeName.Text);
                comboBoxCodeName.Items.Remove("New Code");
                comboBoxCodeName.Items.Add(comboBoxCodeName.Text);
                String codeText = textBoxCodeEntries.Text;
                comboBoxCodeName.SelectedIndex = comboBoxCodeName.Items.Count - 1;
                comboBoxCodeName.Items.Add("New Code");
                textBoxCodeEntries.Text = codeText;
            }
        }

        private void buttonAddStoreClose_Click(object sender, EventArgs e)
        {
            buttonAddCode_Click(sender, e);
            buttonStoreCode_Click(sender, e);
            DialogResult = DialogResult.OK;
            Hide();
        }

    }
}
