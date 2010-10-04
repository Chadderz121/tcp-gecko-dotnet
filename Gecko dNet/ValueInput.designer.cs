namespace GeckoApp
{
    partial class ValueInput
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.CheckInput = new System.Windows.Forms.Button();
            this.RegVal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PValue = new System.Windows.Forms.TextBox();
            this.InstLab = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(102, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // CheckInput
            // 
            this.CheckInput.Location = new System.Drawing.Point(3, 78);
            this.CheckInput.Name = "CheckInput";
            this.CheckInput.Size = new System.Drawing.Size(93, 23);
            this.CheckInput.TabIndex = 14;
            this.CheckInput.Text = "OK";
            this.CheckInput.UseVisualStyleBackColor = true;
            this.CheckInput.Click += new System.EventHandler(this.CheckInput_Click);
            // 
            // RegVal
            // 
            this.RegVal.Location = new System.Drawing.Point(11, 19);
            this.RegVal.Name = "RegVal";
            this.RegVal.Size = new System.Drawing.Size(89, 18);
            this.RegVal.TabIndex = 9;
            this.RegVal.Text = "Value:";
            this.RegVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RegVal);
            this.groupBox1.Controls.Add(this.PValue);
            this.groupBox1.Location = new System.Drawing.Point(15, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 45);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New value";
            // 
            // PValue
            // 
            this.PValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PValue.Location = new System.Drawing.Point(106, 19);
            this.PValue.MaxLength = 8;
            this.PValue.Name = "PValue";
            this.PValue.Size = new System.Drawing.Size(62, 20);
            this.PValue.TabIndex = 8;
            // 
            // InstLab
            // 
            this.InstLab.Location = new System.Drawing.Point(12, 9);
            this.InstLab.Name = "InstLab";
            this.InstLab.Size = new System.Drawing.Size(178, 15);
            this.InstLab.TabIndex = 12;
            this.InstLab.Text = "Poking address xxxxxxxxxx";
            // 
            // ValueInput
            // 
            this.AcceptButton = this.CheckInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(194, 106);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CheckInput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InstLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValueInput";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Poke address";
            this.Shown += new System.EventHandler(this.ValueInput_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CheckInput;
        private System.Windows.Forms.Label RegVal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PValue;
        private System.Windows.Forms.Label InstLab;
    }
}