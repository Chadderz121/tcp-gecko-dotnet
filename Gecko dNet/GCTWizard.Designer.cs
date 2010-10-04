namespace GeckoApp
{
    partial class GCTWizard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAddress = new System.Windows.Forms.GroupBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.radioButtonPO = new System.Windows.Forms.RadioButton();
            this.radioButtonBA = new System.Windows.Forms.RadioButton();
            this.comboBoxCodeType = new System.Windows.Forms.ComboBox();
            this.groupBoxCodeType = new System.Windows.Forms.GroupBox();
            this.comboBoxCodeSubType = new System.Windows.Forms.ComboBox();
            this.groupBoxValue = new System.Windows.Forms.GroupBox();
            this.labelMask = new System.Windows.Forms.Label();
            this.textBoxMask = new System.Windows.Forms.TextBox();
            this.textBoxFill = new System.Windows.Forms.TextBox();
            this.labelFill = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.checkBoxEndIf = new System.Windows.Forms.CheckBox();
            this.comboBoxCodeName = new System.Windows.Forms.ComboBox();
            this.groupBoxCode = new System.Windows.Forms.GroupBox();
            this.textBoxCodeEntries = new System.Windows.Forms.TextBox();
            this.groupBoxSize = new System.Windows.Forms.GroupBox();
            this.radioButton32Bit = new System.Windows.Forms.RadioButton();
            this.radioButton16Bit = new System.Windows.Forms.RadioButton();
            this.radioButton8Bit = new System.Windows.Forms.RadioButton();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAddCode = new System.Windows.Forms.Button();
            this.buttonStoreCode = new System.Windows.Forms.Button();
            this.buttonAddStoreClose = new System.Windows.Forms.Button();
            this.groupBoxAddress.SuspendLayout();
            this.groupBoxCodeType.SuspendLayout();
            this.groupBoxValue.SuspendLayout();
            this.groupBoxCode.SuspendLayout();
            this.groupBoxSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAddress
            // 
            this.groupBoxAddress.Controls.Add(this.textBoxAddress);
            this.groupBoxAddress.Controls.Add(this.radioButtonPO);
            this.groupBoxAddress.Controls.Add(this.radioButtonBA);
            this.groupBoxAddress.Location = new System.Drawing.Point(12, 95);
            this.groupBoxAddress.Name = "groupBoxAddress";
            this.groupBoxAddress.Size = new System.Drawing.Size(88, 69);
            this.groupBoxAddress.TabIndex = 0;
            this.groupBoxAddress.TabStop = false;
            this.groupBoxAddress.Text = "Address";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(13, 43);
            this.textBoxAddress.MaxLength = 8;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(62, 20);
            this.textBoxAddress.TabIndex = 2;
            // 
            // radioButtonPO
            // 
            this.radioButtonPO.AutoSize = true;
            this.radioButtonPO.Location = new System.Drawing.Point(49, 20);
            this.radioButtonPO.Name = "radioButtonPO";
            this.radioButtonPO.Size = new System.Drawing.Size(37, 17);
            this.radioButtonPO.TabIndex = 1;
            this.radioButtonPO.Text = "po";
            this.radioButtonPO.UseVisualStyleBackColor = true;
            // 
            // radioButtonBA
            // 
            this.radioButtonBA.AutoSize = true;
            this.radioButtonBA.Checked = true;
            this.radioButtonBA.Location = new System.Drawing.Point(6, 20);
            this.radioButtonBA.Name = "radioButtonBA";
            this.radioButtonBA.Size = new System.Drawing.Size(37, 17);
            this.radioButtonBA.TabIndex = 0;
            this.radioButtonBA.TabStop = true;
            this.radioButtonBA.Text = "ba";
            this.radioButtonBA.UseVisualStyleBackColor = true;
            // 
            // comboBoxCodeType
            // 
            this.comboBoxCodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodeType.FormattingEnabled = true;
            this.comboBoxCodeType.Items.AddRange(new object[] {
            "RAM Write",
            "If Then",
            "Base/Pointer",
            "Repeat/Return",
            "Gecko Register",
            "Unknown If",
            "Counter"});
            this.comboBoxCodeType.Location = new System.Drawing.Point(6, 19);
            this.comboBoxCodeType.Name = "comboBoxCodeType";
            this.comboBoxCodeType.Size = new System.Drawing.Size(139, 21);
            this.comboBoxCodeType.TabIndex = 1;
            this.comboBoxCodeType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCodeType_SelectedIndexChanged);
            // 
            // groupBoxCodeType
            // 
            this.groupBoxCodeType.Controls.Add(this.comboBoxCodeSubType);
            this.groupBoxCodeType.Controls.Add(this.comboBoxCodeType);
            this.groupBoxCodeType.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCodeType.Name = "groupBoxCodeType";
            this.groupBoxCodeType.Size = new System.Drawing.Size(154, 76);
            this.groupBoxCodeType.TabIndex = 2;
            this.groupBoxCodeType.TabStop = false;
            this.groupBoxCodeType.Text = "Code Type";
            // 
            // comboBoxCodeSubType
            // 
            this.comboBoxCodeSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodeSubType.FormattingEnabled = true;
            this.comboBoxCodeSubType.Location = new System.Drawing.Point(7, 47);
            this.comboBoxCodeSubType.Name = "comboBoxCodeSubType";
            this.comboBoxCodeSubType.Size = new System.Drawing.Size(138, 21);
            this.comboBoxCodeSubType.TabIndex = 2;
            // 
            // groupBoxValue
            // 
            this.groupBoxValue.Controls.Add(this.labelMask);
            this.groupBoxValue.Controls.Add(this.textBoxMask);
            this.groupBoxValue.Controls.Add(this.textBoxFill);
            this.groupBoxValue.Controls.Add(this.labelFill);
            this.groupBoxValue.Controls.Add(this.labelValue);
            this.groupBoxValue.Controls.Add(this.textBoxValue);
            this.groupBoxValue.Location = new System.Drawing.Point(12, 193);
            this.groupBoxValue.Name = "groupBoxValue";
            this.groupBoxValue.Size = new System.Drawing.Size(154, 100);
            this.groupBoxValue.TabIndex = 3;
            this.groupBoxValue.TabStop = false;
            this.groupBoxValue.Text = "Value";
            // 
            // labelMask
            // 
            this.labelMask.AutoSize = true;
            this.labelMask.Location = new System.Drawing.Point(21, 74);
            this.labelMask.Name = "labelMask";
            this.labelMask.Size = new System.Drawing.Size(33, 13);
            this.labelMask.TabIndex = 5;
            this.labelMask.Text = "Mask";
            // 
            // textBoxMask
            // 
            this.textBoxMask.Location = new System.Drawing.Point(72, 71);
            this.textBoxMask.MaxLength = 4;
            this.textBoxMask.Name = "textBoxMask";
            this.textBoxMask.Size = new System.Drawing.Size(62, 20);
            this.textBoxMask.TabIndex = 4;
            // 
            // textBoxFill
            // 
            this.textBoxFill.Location = new System.Drawing.Point(72, 45);
            this.textBoxFill.MaxLength = 4;
            this.textBoxFill.Name = "textBoxFill";
            this.textBoxFill.Size = new System.Drawing.Size(62, 20);
            this.textBoxFill.TabIndex = 3;
            // 
            // labelFill
            // 
            this.labelFill.AutoSize = true;
            this.labelFill.Location = new System.Drawing.Point(35, 48);
            this.labelFill.Name = "labelFill";
            this.labelFill.Size = new System.Drawing.Size(19, 13);
            this.labelFill.TabIndex = 2;
            this.labelFill.Text = "Fill";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(20, 22);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(34, 13);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "Value";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValue.Location = new System.Drawing.Point(72, 19);
            this.textBoxValue.MaxLength = 8;
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(62, 20);
            this.textBoxValue.TabIndex = 0;
            // 
            // checkBoxEndIf
            // 
            this.checkBoxEndIf.AutoSize = true;
            this.checkBoxEndIf.Location = new System.Drawing.Point(30, 170);
            this.checkBoxEndIf.Name = "checkBoxEndIf";
            this.checkBoxEndIf.Size = new System.Drawing.Size(54, 17);
            this.checkBoxEndIf.TabIndex = 4;
            this.checkBoxEndIf.Text = "End If";
            this.checkBoxEndIf.UseVisualStyleBackColor = true;
            // 
            // comboBoxCodeName
            // 
            this.comboBoxCodeName.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxCodeName.DropDownWidth = 173;
            this.comboBoxCodeName.FormattingEnabled = true;
            this.comboBoxCodeName.Location = new System.Drawing.Point(6, 19);
            this.comboBoxCodeName.Name = "comboBoxCodeName";
            this.comboBoxCodeName.Size = new System.Drawing.Size(173, 21);
            this.comboBoxCodeName.TabIndex = 4;
            this.comboBoxCodeName.SelectedIndexChanged += new System.EventHandler(this.comboBoxCodeName_SelectedIndexChanged);
            this.comboBoxCodeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxCodeName_KeyDown);
            // 
            // groupBoxCode
            // 
            this.groupBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCode.Controls.Add(this.comboBoxCodeName);
            this.groupBoxCode.Controls.Add(this.textBoxCodeEntries);
            this.groupBoxCode.Location = new System.Drawing.Point(368, 12);
            this.groupBoxCode.Name = "groupBoxCode";
            this.groupBoxCode.Size = new System.Drawing.Size(189, 304);
            this.groupBoxCode.TabIndex = 6;
            this.groupBoxCode.TabStop = false;
            this.groupBoxCode.Text = "Code";
            // 
            // textBoxCodeEntries
            // 
            this.textBoxCodeEntries.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCodeEntries.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodeEntries.Location = new System.Drawing.Point(6, 46);
            this.textBoxCodeEntries.Multiline = true;
            this.textBoxCodeEntries.Name = "textBoxCodeEntries";
            this.textBoxCodeEntries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCodeEntries.Size = new System.Drawing.Size(173, 249);
            this.textBoxCodeEntries.TabIndex = 0;
            // 
            // groupBoxSize
            // 
            this.groupBoxSize.Controls.Add(this.radioButton32Bit);
            this.groupBoxSize.Controls.Add(this.radioButton16Bit);
            this.groupBoxSize.Controls.Add(this.radioButton8Bit);
            this.groupBoxSize.Location = new System.Drawing.Point(106, 95);
            this.groupBoxSize.Name = "groupBoxSize";
            this.groupBoxSize.Size = new System.Drawing.Size(60, 91);
            this.groupBoxSize.TabIndex = 7;
            this.groupBoxSize.TabStop = false;
            this.groupBoxSize.Text = "Size";
            // 
            // radioButton32Bit
            // 
            this.radioButton32Bit.AutoSize = true;
            this.radioButton32Bit.Checked = true;
            this.radioButton32Bit.Location = new System.Drawing.Point(7, 68);
            this.radioButton32Bit.Name = "radioButton32Bit";
            this.radioButton32Bit.Size = new System.Drawing.Size(51, 17);
            this.radioButton32Bit.TabIndex = 2;
            this.radioButton32Bit.TabStop = true;
            this.radioButton32Bit.Text = "32-bit";
            this.radioButton32Bit.UseVisualStyleBackColor = true;
            // 
            // radioButton16Bit
            // 
            this.radioButton16Bit.AutoSize = true;
            this.radioButton16Bit.Location = new System.Drawing.Point(7, 44);
            this.radioButton16Bit.Name = "radioButton16Bit";
            this.radioButton16Bit.Size = new System.Drawing.Size(51, 17);
            this.radioButton16Bit.TabIndex = 1;
            this.radioButton16Bit.Text = "16-bit";
            this.radioButton16Bit.UseVisualStyleBackColor = true;
            // 
            // radioButton8Bit
            // 
            this.radioButton8Bit.AutoSize = true;
            this.radioButton8Bit.Location = new System.Drawing.Point(7, 20);
            this.radioButton8Bit.Name = "radioButton8Bit";
            this.radioButton8Bit.Size = new System.Drawing.Size(45, 17);
            this.radioButton8Bit.TabIndex = 0;
            this.radioButton8Bit.Text = "8-bit";
            this.radioButton8Bit.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(475, 359);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(82, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Exit";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAddCode
            // 
            this.buttonAddCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCode.Location = new System.Drawing.Point(374, 359);
            this.buttonAddCode.Name = "buttonAddCode";
            this.buttonAddCode.Size = new System.Drawing.Size(82, 23);
            this.buttonAddCode.TabIndex = 9;
            this.buttonAddCode.Text = "Add Code";
            this.buttonAddCode.UseVisualStyleBackColor = true;
            this.buttonAddCode.Click += new System.EventHandler(this.buttonAddCode_Click);
            // 
            // buttonStoreCode
            // 
            this.buttonStoreCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStoreCode.ForeColor = System.Drawing.Color.Red;
            this.buttonStoreCode.Location = new System.Drawing.Point(475, 323);
            this.buttonStoreCode.Name = "buttonStoreCode";
            this.buttonStoreCode.Size = new System.Drawing.Size(82, 23);
            this.buttonStoreCode.TabIndex = 10;
            this.buttonStoreCode.Text = "Store Code";
            this.buttonStoreCode.UseVisualStyleBackColor = true;
            this.buttonStoreCode.Click += new System.EventHandler(this.buttonStoreCode_Click);
            // 
            // buttonAddStoreClose
            // 
            this.buttonAddStoreClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddStoreClose.ForeColor = System.Drawing.Color.Red;
            this.buttonAddStoreClose.Location = new System.Drawing.Point(374, 323);
            this.buttonAddStoreClose.Name = "buttonAddStoreClose";
            this.buttonAddStoreClose.Size = new System.Drawing.Size(82, 23);
            this.buttonAddStoreClose.TabIndex = 11;
            this.buttonAddStoreClose.Text = "Add Store Exit";
            this.buttonAddStoreClose.UseVisualStyleBackColor = true;
            this.buttonAddStoreClose.Click += new System.EventHandler(this.buttonAddStoreClose_Click);
            // 
            // GCTWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(569, 394);
            this.Controls.Add(this.buttonAddStoreClose);
            this.Controls.Add(this.buttonStoreCode);
            this.Controls.Add(this.buttonAddCode);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBoxSize);
            this.Controls.Add(this.groupBoxCode);
            this.Controls.Add(this.checkBoxEndIf);
            this.Controls.Add(this.groupBoxValue);
            this.Controls.Add(this.groupBoxCodeType);
            this.Controls.Add(this.groupBoxAddress);
            this.Name = "GCTWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GCTWizard";
            this.Shown += new System.EventHandler(this.GCTWizard_Shown);
            this.groupBoxAddress.ResumeLayout(false);
            this.groupBoxAddress.PerformLayout();
            this.groupBoxCodeType.ResumeLayout(false);
            this.groupBoxValue.ResumeLayout(false);
            this.groupBoxValue.PerformLayout();
            this.groupBoxCode.ResumeLayout(false);
            this.groupBoxCode.PerformLayout();
            this.groupBoxSize.ResumeLayout(false);
            this.groupBoxSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAddress;
        private System.Windows.Forms.GroupBox groupBoxCodeType;
        private System.Windows.Forms.ComboBox comboBoxCodeSubType;
        private System.Windows.Forms.GroupBox groupBoxValue;
        private System.Windows.Forms.Label labelFill;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelMask;
        private System.Windows.Forms.TextBox textBoxMask;
        private System.Windows.Forms.TextBox textBoxFill;
        private System.Windows.Forms.CheckBox checkBoxEndIf;
        private System.Windows.Forms.ComboBox comboBoxCodeName;
        private System.Windows.Forms.GroupBox groupBoxCode;
        public System.Windows.Forms.TextBox textBoxCodeEntries;
        private System.Windows.Forms.GroupBox groupBoxSize;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAddCode;
        public System.Windows.Forms.RadioButton radioButtonBA;
        public System.Windows.Forms.RadioButton radioButtonPO;
        public System.Windows.Forms.TextBox textBoxAddress;
        public System.Windows.Forms.TextBox textBoxValue;
        public System.Windows.Forms.RadioButton radioButton8Bit;
        public System.Windows.Forms.RadioButton radioButton32Bit;
        public System.Windows.Forms.RadioButton radioButton16Bit;
        private System.Windows.Forms.Button buttonStoreCode;
        private System.Windows.Forms.Button buttonAddStoreClose;
        public System.Windows.Forms.ComboBox comboBoxCodeType;
    }
}