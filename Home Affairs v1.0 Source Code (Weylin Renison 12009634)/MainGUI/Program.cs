﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           /* Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogIn frmLogIn = new frmLogIn();

            if (frmLogIn.ShowDialog() == DialogResult.OK)*/
                Application.Run(new MainGUI());
            //else
              //  Application.Exit();

                
            
        }
    }
}
