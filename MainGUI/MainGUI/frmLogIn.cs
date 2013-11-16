using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MainGUI
{
    public partial class frmLogIn : Form
    {
        const char FILE_DATA_SPLITTER = ':';
        const string FILE_DIRECTORY = "Users.txt";
        private string USER_LOGGED_IN;
        
        public frmLogIn()
        {
            InitializeComponent();
            
        }

        private void llblNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNewUserGUI frmNewUser = new frmNewUserGUI();
            frmNewUser.ShowDialog();
            
        }

        //Searches file for username and password, if they exist send the user to the main form
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            bool verifiedUsernameAndPass = false;

            try
            {
                using(StreamReader reader = new StreamReader(FILE_DIRECTORY))
                {
                    string inUser;
                    string[] inUserDetails;

                    while ((inUser = reader.ReadLine()) != null)
                    {                       
                       inUserDetails = inUser.Split(FILE_DATA_SPLITTER);

                       if (txtbUserName.Text == inUserDetails[0] && mtxtbPassword.Text == inUserDetails[1])
                       {
                           verifiedUsernameAndPass = true;
                           break;
                       }
                    }

                    if (verifiedUsernameAndPass == false)
                    {
                        MessageBox.Show("Username and Password incorrect please try again");
                        txtbUserName.Clear();
                        mtxtbPassword.Clear();
                    }
                    else
                    {
                        USER_LOGGED_IN = txtbUserName.Text;
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show("File Directory not found: " + dnfe.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("An IO Exception has occured: " + ioe.Message);
            }           

        }

        public string getLogedInUser()
        {
            return USER_LOGGED_IN;
        }
       
    }
}
