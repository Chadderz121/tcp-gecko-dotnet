using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp
{
    public partial class InputBox : Form
    {
        public static bool Show(String title, String text, String defaultValue,
            out String value)
        {
            InputBox ib = new InputBox();
            value = "";

            ib.Text = title;
            ib.InputBoxText.Text = text;
            ib.textField.Text = defaultValue;

            DialogResult result = ib.ShowDialog();

            if (result == DialogResult.OK)
            {
                value = ib.textField.Text;
                return true;
            }

            return false;
        }

        public InputBox()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void InputBox_Load(object sender, EventArgs e)
        {
            textField.Focus();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btn_OK_Click(sender, e);
            }
            if (e.KeyChar == 27)
            {
                e.Handled = true;
                btn_Cancel_Click(sender, e);
            }
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                btn_Cancel_Click(sender, e);
        }

        private void textField_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
