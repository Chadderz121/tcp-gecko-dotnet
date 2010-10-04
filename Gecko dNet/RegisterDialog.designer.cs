namespace GeckoApp
{
    partial class RegisterDialog
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
            this.InstLab = new System.Windows.Forms.Label();
            this.RValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RegVal = new System.Windows.Forms.Label();
            this.CheckInput = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstLab
            // 
            this.InstLab.Location = new System.Drawing.Point(12, 9);
            this.InstLab.Name = "InstLab";
            this.InstLab.Size = new System.Drawing.Size(206, 55);
            this.InstLab.TabIndex = 0;
            this.InstLab.Text = "You are about to change the value stored in the register dddd. Please type in the" +
                " new value and click OK to set it or Cancel to abort.";
            // 
            // RValue
            // 
            this.RValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RValue.Location = new System.Drawing.Point(135, 19);
            this.RValue.MaxLength = 8;
            this.RValue.Name = "RValue";
            this.RValue.Size = new System.Drawing.Size(62, 20);
            this.RValue.TabIndex = 8;
            this.RValue.Text = "80000000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RegVal);
            this.groupBox1.Controls.Add(this.RValue);
            this.groupBox1.Location = new System.Drawing.Point(15, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 45);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register value";
            // 
            // RegVal
            // 
            this.RegVal.Location = new System.Drawing.Point(11, 20);
            this.RegVal.Name = "RegVal";
            this.RegVal.Size = new System.Drawing.Size(118, 18);
            this.RegVal.TabIndex = 9;
            this.RegVal.Text = "Value of register dddd:";
            this.RegVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckInput
            // 
            this.CheckInput.Location = new System.Drawing.Point(15, 121);
            this.CheckInput.Name = "CheckInput";
            this.CheckInput.Size = new System.Drawing.Size(100, 23);
            this.CheckInput.TabIndex = 10;
            this.CheckInput.Text = "OK";
            this.CheckInput.UseVisualStyleBackColor = true;
            this.CheckInput.Click += new System.EventHandler(this.CheckInput_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(118, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // RegisterDialog
            // 
            this.AcceptButton = this.CheckInput;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(230, 148);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.CheckInput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InstLab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change register";
            this.Load += new System.EventHandler(this.RegisterDialog_Load);
            this.Shown += new System.EventHandler(this.RegisterDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label InstLab;
        private System.Windows.Forms.TextBox RValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label RegVal;
        private System.Windows.Forms.Button CheckInput;
        private System.Windows.Forms.Button button2;
    }
}