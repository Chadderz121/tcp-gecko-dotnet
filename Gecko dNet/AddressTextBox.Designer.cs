namespace GeckoApp.external
{
    partial class AddressTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxHistory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxHistory
            // 
            this.comboBoxHistory.FormattingEnabled = true;
            this.comboBoxHistory.Location = new System.Drawing.Point(0, 0);
            this.comboBoxHistory.Name = "comboBoxHistory";
            this.comboBoxHistory.Size = new System.Drawing.Size(121, 24);
            this.comboBoxHistory.TabIndex = 0;
            this.comboBoxHistory.Visible = false;
            this.comboBoxHistory.SelectedIndexChanged += new System.EventHandler(this.comboBoxHistory_SelectedIndexChanged);
            this.comboBoxHistory.DropDownClosed += new System.EventHandler(this.comboBoxHistory_DropDownClosed);
            // 
            // AddressTextBox
            // 
            this.LocationChanged += new System.EventHandler(this.AddressTextBox_LocationChanged);
            this.TextChanged += new System.EventHandler(this.AddressTextBox_TextChanged);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.AddressTextBox_Layout);
            this.ContextMenuStripChanged += new System.EventHandler(this.AddressTextBox_ContextMenuStripChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressTextBox_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AddressTextBox_MouseDoubleClick);
            this.Leave += new System.EventHandler(this.AddressTextBox_Leave);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTextBox_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHistory;
    }
}
