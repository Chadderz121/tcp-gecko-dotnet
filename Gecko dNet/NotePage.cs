using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GeckoApp
{
    public partial class NotePage : UserControl
    {
        private TabPage PMyPage;
        private NoteSheets PMyForm;

        public NotePage(TabPage page, NoteSheets form) : base()
        {
            InitializeComponent();
            PMyPage = page;
            PMyForm = form;
            Sheet sheet = (Sheet)page.Tag;
            SheetText.Text = sheet.content;
            SheetTitle.Text = sheet.title;
        }

        private void SheetText_TextChanged(object sender, EventArgs e)
        {
            Sheet sheet = (Sheet)PMyPage.Tag;
            sheet.content = SheetText.Text;
        }

        private void SheetTitle_TextChanged(object sender, EventArgs e)
        {
            Sheet sheet = (Sheet)PMyPage.Tag;
            sheet.title = SheetTitle.Text;
            PMyForm.UpdateTitle(PMyPage);
        }

        private void DelCurSheet_Click(object sender, EventArgs e)
        {
            PMyForm.DeleteSheet(PMyPage);
        }
    }
}
