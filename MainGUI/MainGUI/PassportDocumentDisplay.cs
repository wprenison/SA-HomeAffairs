using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//the printing sections whas taken from http://msdn.microsoft.com/en-us/library/6he9hz8c.aspx

namespace MainGUI
{
    public partial class PassportDocumentDisplay : Form
    {
        PrintDocument printDoc = new PrintDocument();

        public PassportDocumentDisplay()
        {
            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            InitializeComponent();
        }

        private void pbPassPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDoc.Print();
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
