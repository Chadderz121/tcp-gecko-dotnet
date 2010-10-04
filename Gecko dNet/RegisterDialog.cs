using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp
{
    public partial class RegisterDialog : Form
    {
        private UInt32 setValue;

        public RegisterDialog()
        {
            InitializeComponent();
        }

        private void RegisterDialog_Load(object sender, EventArgs e)
        {

        }

        public bool SetRegister(String name, ref UInt32 value)
        {
            InstLab.Text = "You are about to change the value stored in the register " + name +
                           ". Please type in the new value and click OK to set it or Cancel to abort.";
            RegVal.Text = "Value of register " + name + ":";
            RValue.Text = GlobalFunctions.toHex(value);
            setValue = value;

            if (this.ShowDialog() == DialogResult.OK)
            {
                value = setValue;
                return true;
            }

            return false;
        }

        private void CheckInput_Click(object sender, EventArgs e)
        {
            UInt32 tryHex;
            if (GlobalFunctions.tryToHex(RValue.Text, out tryHex))
            {
                setValue = tryHex;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Invalid value!");
        }

        private void RegisterDialog_Shown(object sender, EventArgs e)
        {
            RValue.Focus();
        }
    }
}
