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
    public partial class DeathCertDisplay : Form
    {
        PrintDocument printDoc = new PrintDocument();

        public DeathCertDisplay()
        {
            InitializeComponent();

            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            
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

        private void pbPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDoc.Print();
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string dir = saveFileDialog1.FileName;
                        
            memoryImage.Save(dir);
        }
    }
}
