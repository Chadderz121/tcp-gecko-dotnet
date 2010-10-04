namespace GeckoApp
{
    partial class NoteSheets
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Whatsthis = new System.Windows.Forms.Button();
            this.AddSheet = new System.Windows.Forms.Button();
            this.SheetSelection = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Whatsthis);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // Whatsthis
            // 
            this.Whatsthis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Whatsthis.Location = new System.Drawing.Point(6, 15);
            this.Whatsthis.Name = "Whatsthis";
            this.Whatsthis.Size = new System.Drawing.Size(447, 23);
            this.Whatsthis.TabIndex = 0;
            this.Whatsthis.Text = "&What is this?";
            this.Whatsthis.UseVisualStyleBackColor = true;
            this.Whatsthis.Click += new System.EventHandler(this.Whatsthis_Click);
            // 
            // AddSheet
            // 
            this.AddSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSheet.Location = new System.Drawing.Point(7, 52);
            this.AddSheet.Name = "AddSheet";
            this.AddSheet.Size = new System.Drawing.Size(447, 21);
            this.AddSheet.TabIndex = 3;
            this.AddSheet.Text = "&Add sheet";
            this.AddSheet.UseVisualStyleBackColor = true;
            this.AddSheet.Click += new System.EventHandler(this.AddSheet_Click);
            // 
            // SheetSelection
            // 
            this.SheetSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SheetSelection.Location = new System.Drawing.Point(1, 79);
            this.SheetSelection.Multiline = true;
            this.SheetSelection.Name = "SheetSelection";
            this.SheetSelection.SelectedIndex = 0;
            this.SheetSelection.ShowToolTips = true;
            this.SheetSelection.Size = new System.Drawing.Size(459, 237);
            this.SheetSelection.TabIndex = 4;
            this.SheetSelection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SheetSelection_MouseMove);
            this.SheetSelection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SheetSelection_MouseDown);
            this.SheetSelection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SheetSelection_MouseUp);
            // 
            // NoteSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 315);
            this.Controls.Add(this.SheetSelection);
            this.Controls.Add(this.AddSheet);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(440, 290);
            this.Name = "NoteSheets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notepad";
            this.Load += new System.EventHandler(this.NoteSheets_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteSheets_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Whatsthis;
        private System.Windows.Forms.Button AddSheet;
        private System.Windows.Forms.TabControl SheetSelection;
    }
}