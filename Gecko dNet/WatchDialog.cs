using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp
{
    public partial class WatchDialog : Form
    {
        public WatchDialog()
        {
            InitializeComponent();
        }

        public UInt32[] WAddress;
        public String WName;
        public WatchDataSize WDataSize;

        private void btn_OK_Click(object sender, EventArgs e)
        {
            UInt32[] address;
            if (inputName.Text == "")
            {
                MessageBox.Show("Please type in a code name!");
                return;
            }
            bool okay = WatchList.TryStrToAddressList(inputAddress.Text, out address);
            if (!okay)
            {
                MessageBox.Show("Unable to parse address");
            }
            else
            {
                WAddress = address;
                WName = inputName.Text;
                switch (DType.SelectedIndex)
                {
                    case 0:
                        WDataSize = WatchDataSize.Bit8;
                        break;
                    case 1:
                        WDataSize = WatchDataSize.Bit16;
                        break;
                    case 3:
                        WDataSize = WatchDataSize.SingleFp;
                        break;
                    default:
                        WDataSize = WatchDataSize.Bit32;
                        break;
                }
                DialogResult = DialogResult.OK;
            }
        }

        public bool AddCodeDialog()
        {
            DialogResult dr;

            this.inputAddress.Text = "";
            this.inputName.Text = "New watch";
            this.DType.SelectedIndex = 2;
            
            dr = this.ShowDialog();
            return (dr == DialogResult.OK);
        }

        public bool EditWatchDialog(WatchEntry entry)
        {
            DialogResult dr;

            this.inputAddress.Text = WatchList.addressToString(entry.address);
            this.inputName.Text = entry.name;
            switch (entry.dataSize)
            {
                case WatchDataSize.Bit8:
                    this.DType.SelectedIndex = 0;
                    break;
                case WatchDataSize.Bit16:
                    this.DType.SelectedIndex = 1;
                    break;
                case WatchDataSize.SingleFp:
                    this.DType.SelectedIndex = 3;
                    break;
                default:
                    this.DType.SelectedIndex = 2;
                    break;
            }
            
            dr = this.ShowDialog();
            return (dr == DialogResult.OK);
        }

        private void WatchDialog_Shown(object sender, EventArgs e)
        {
            inputName.Focus();
        }
    }
}
