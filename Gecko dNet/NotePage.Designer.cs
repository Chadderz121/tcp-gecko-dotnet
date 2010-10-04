namespace GeckoApp
{
    partial class NotePage
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.SheetText = new System.Windows.Forms.RichTextBox();
            this.SheetTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DelCurSheet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SheetText
            // 
            this.SheetText.AcceptsTab = true;
            this.SheetText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SheetText.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SheetText.Location = new System.Drawing.Point(3, 26);
            this.SheetText.Name = "SheetText";
            this.SheetText.Size = new System.Drawing.Size(466, 302);
            this.SheetText.TabIndex = 6;
            this.SheetText.Text = "";
            this.SheetText.WordWrap = false;
            this.SheetText.TextChanged += new System.EventHandler(this.SheetText_TextChanged);
            // 
            // SheetTitle
            // 
            this.SheetTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SheetTitle.Location = new System.Drawing.Point(63, 3);
            this.SheetTitle.Name = "SheetTitle";
            this.SheetTitle.Size = new System.Drawing.Size(277, 20);
            this.SheetTitle.TabIndex = 5;
            this.SheetTitle.TextChanged += new System.EventHandler(this.SheetTitle_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DelCurSheet
            // 
            this.DelCurSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DelCurSheet.Location = new System.Drawing.Point(346, 3);
            this.DelCurSheet.Name = "DelCurSheet";
            this.DelCurSheet.Size = new System.Drawing.Size(123, 20);
            this.DelCurSheet.TabIndex = 7;
            this.DelCurSheet.Text = "Delete current sheet";
            this.DelCurSheet.UseVisualStyleBackColor = true;
            this.DelCurSheet.Click += new System.EventHandler(this.DelCurSheet_Click);
            // 
            // NotePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DelCurSheet);
            this.Controls.Add(this.SheetText);
            this.Controls.Add(this.SheetTitle);
            this.Controls.Add(this.label2);
            this.Name = "NotePage";
            this.Size = new System.Drawing.Size(472, 331);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SheetTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DelCurSheet;
        public System.Windows.Forms.RichTextBox SheetText;
    }
}
