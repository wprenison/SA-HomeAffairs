using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

/*
 * Author: Weylin Renison
 * Stud No: 12009634
 * Home Affairs v1.0
 * */


namespace MainGUI
{
    public partial class frmNewUserGUI : Form
    {
        const char FILE_DATA_SPLITTER = ':';
        const string FILE_DIRECTORY = "Users.txt";

        public frmNewUserGUI()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {

            ValidationCalculator validator = new ValidationCalculator();
            string[] allFields = {txtbFirstNames.Text, txtbLastName.Text, txtbAddressLine1.Text, txtbAddressLine2.Text, txtbAddressLine3.Text, txtbUserName.Text, txtbPassword.Text};
            string[] nameFields = { txtbFirstNames.Text, txtbLastName.Text };

            if (validator.valCompleted(allFields) == false)
                MessageBox.Show("Error a field was not completed");
            else if (validator.valLettersAndSpace(nameFields) == false)
                MessageBox.Show("Error an invalid character was detected in your names");
            else if (validator.valPassword(txtbPassword.Text) == false)
                MessageBox.Show("Password does not conform to restrictions.\nPlease click on password restrictions to see what they are.");
            else if (txtbPassword.Text != txtbConfirmPassword.Text)
                MessageBox.Show("The Password in the Confirm Password field does not match the password in the Password field.");
            else
            {               

                //Checks username is unique and available then Writes base user details to file
                try
                {
                    bool usernameUnique = true;

                    using (StreamReader reader = new StreamReader(FILE_DIRECTORY))
                    {
                        string inValue;
                        string[] userDetails;

                        while((inValue = reader.ReadLine()) != null)
                        {
                            userDetails = inValue.Split(FILE_DATA_SPLITTER);

                            if (txtbUserName.Text == userDetails[0])
                            {
                                usernameUnique = false;
                                MessageBox.Show("The user name you have selected is not available, please try a diffrent user name.");
                                break;
                            }
                        }
                    }

                    if (usernameUnique)
                    {
                        using (StreamWriter writer = new StreamWriter(FILE_DIRECTORY, true))
                        {
                            string userLine = txtbUserName.Text + FILE_DATA_SPLITTER + txtbPassword.Text + FILE_DATA_SPLITTER + txtbFirstNames.Text + FILE_DATA_SPLITTER
                                                + txtbLastName.Text + FILE_DATA_SPLITTER + dtpDateOfBirth.Text + FILE_DATA_SPLITTER + txtbAddressLine1.Text + FILE_DATA_SPLITTER
                                                + txtbAddressLine2.Text + FILE_DATA_SPLITTER + txtbAddressLine3.Text;

                            writer.WriteLine(userLine);
                        }

                        MessageBox.Show("User created succefully");
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (DirectoryNotFoundException dnfe)
                {
                    MessageBox.Show("Directory was not found to store base user info: " + dnfe.Message);
                }
                catch (IOException ioe)
                {
                    MessageBox.Show("An IO Exception has occured: " + ioe.Message);
                }



            }
        }        

        private void llblPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this,"Your password must conaint at least one upper case letter on lower case letter and one special character like % or a number.\nThe password must also be 6 characters or longer and not contain a :", "Password Restrictions");
        }
        
    }
}
