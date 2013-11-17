using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MainGUI
{
    public partial class frmHomeAffiarsMainGUI : Form
    {
        private string CURRENT_USER;
        private const char FILE_DATA_SPLITTER = ':';
        private const string FILE_DIRECTORY_USER = "Users.txt";
        private const string FILE_DIRECTORY_IDUSER = "IDUsers.txt";
        private const string FILE_DIRECTORY_PASSUSER = "PASSUsers.txt";

        public frmHomeAffiarsMainGUI()
        {
            InitializeComponent();
            this.Hide();
            pnlPartnerDetails.Hide();

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogIn logInFrm = new frmLogIn();
            DialogResult logInResult = logInFrm.ShowDialog();
            CURRENT_USER = logInFrm.getLogedInUser();

            //Used to terminate the application if the login form is closed by the user.
            if (logInResult == DialogResult.Cancel)
                Application.Exit();

            MessageBox.Show("Welcome " + CURRENT_USER);

            //dissables all tabs except id tab
            ((Control)this.tpgPassport).Enabled = false;
            ((Control)this.tpgDeathCert).Enabled = false;

            pnlTandCs.Hide();

            //finds if the user has already an id number then allows access to specific tabs if so
            controlTabAccess();

            //finds out if passport details for user is available to auto fill death certificate
            string[] passUserDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_PASSUSER);

            if (passUserDetails != null)
            {
                txtbApplicantHomeTell.Text = passUserDetails[2];
                txtbApplicantWorkTell.Text = passUserDetails[3];
                txtbCell.Text = passUserDetails[4];
                txtbPostalLine1.Text = passUserDetails[5];
                txtbPostalLine2.Text = passUserDetails[6];
                txtbPostalLine3.Text = passUserDetails[7];
            }

        }

        private string[] searchUser(string currentUser, string FILE_DIRECTORY_TO_SEARCH)
        {
            string[] userDetails = null;

            try
            {
                using (StreamReader reader = new StreamReader(FILE_DIRECTORY_TO_SEARCH))
                {
                    string inValue;

                    while ((inValue = reader.ReadLine()) != null)
                    {
                        userDetails = inValue.Split(FILE_DATA_SPLITTER);

                        if (currentUser == userDetails[0])
                            break;
                        else
                            userDetails = null;

                    }
                }
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show("Directory not found: " + dnfe.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("IO Exception occured: " + ioe.Message);
            }

            return userDetails;
        }

        private void cbMarried_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarried.CheckState == CheckState.Checked)
                pnlPartnerDetails.Show();
            else
                pnlPartnerDetails.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ValidationCalculator validator = new ValidationCalculator(); //used to validate inputs

            //detrmines which tab is in use
            string selectedTabName = tctrlMenu.SelectedTab.Name;
            if (selectedTabName == "tpgIdDoc")
            {
                handelIdSubmit(validator);

            }
            else if (selectedTabName == "tpgPassport")
            {
                handelPassSubmit(validator);
            }
            else if (selectedTabName == "tpgDeathCert")
            {
                handelDeathSubmit(validator);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string selectedTabName = tctrlMenu.SelectedTab.Name;

            if (selectedTabName == "tpgIdDoc")
            {
                txtbMaidenName.Clear();
                rabSouthAfrica.Checked = false;
                rabOther.Checked = false;
                rabMale.Checked = false;
                rabFemale.Checked = false;
                cmbRace.SelectedIndex = -1;

                if (cbMarried.Checked)
                {
                    txtbPartnerId.Clear();
                    txtbPartnerFirstName.Clear();
                    txtbPartnerMaidenName.Clear();
                    txtbMarrageCity.Clear();
                    dtpPartnerDateOfBirth.Text = "";
                }
            }
            else if (selectedTabName == "tpgPassport")
            {
                txtbIdNo.Clear();
                txtbHomeTell.Clear();
                txtbWorkTell.Clear();
                txtbCell.Clear();
                txtbEmail.Clear();
                txtbPostalLine1.Clear();
                txtbPostalLine2.Clear();
                txtbPostalLine3.Clear();
                txtbCountryOfBirth.Clear();
                txtbPlaceOfBirth.Clear();
                cbTandCs.Checked = false;

            }
            else if (selectedTabName == "tpgDeathCert")
            {
                txtbDesceasedIdNo.Clear();
                txtbDesceasedFirstNames.Clear();
                txtbDesceasedMaidenName.Clear();
                txtbDesceasedSurname.Clear();
                txtbTownOfDeath.Clear();
                txtbProvinceOfDeath.Clear();
                txtbNameOfUndertaker.Clear();
                txtbApplicantHomeTell.Clear();
                txtbApplicantWorkTell.Clear();
                txtbApplicantCell.Clear();
                txtbApplicantPostalLine1.Clear();
                txtbApplicantPostalLine2.Clear();
                txtbApplicantPostalLine3.Clear();
                txtbApplicantResidentialLine1.Clear();
                txtbApplicantResidentialLine2.Clear();
                txtbApplicantResidentialLine3.Clear();
                dtpDateOfDeath.Text = "";
            }
        }

        private void llblTandCs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pnlTandCs.Visible == false)
                pnlTandCs.Show();
            else
                pnlTandCs.Hide();
        }

        private void controlTabAccess()
        {
            //Checks if user has id no
            string[] userIdDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_IDUSER);

            if (userIdDetails != null)
            {
                pnlIdDetails.Hide();
                lblAlredHaveId.Text = "You already have an ID Number: " + userIdDetails[1];
                lblAlredHaveId.Visible = true;
                ((Control)this.tpgIdDoc).Enabled = false;
                btnViewIdDoc.Visible = true;

                //Enables Passport page
                ((Control)this.tpgPassport).Enabled = true;
                lblNeedIdNo.Visible = false;
                txtbIdNo.Text = userIdDetails[1];

                //Enables Death Certificate page
                ((Control)this.tpgDeathCert).Enabled = true;
                lblNeedIdNoDeath.Visible = false;
            }
            else
                lblAlredHaveId.Visible = false;

            //Checks if user already has a passport
            string[] passUserDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_PASSUSER);

            if (passUserDetails != null)
            {
                pnlPassDetails.Hide();

                lblYouAlrdyHavPass.Text = "You already have a Passport: " + passUserDetails[11];
                lblYouAlrdyHavPass.Visible = true;

                ((Control)this.tpgPassport).Enabled = false;

            }

        }

        private void handelIdSubmit(ValidationCalculator validator)
        {
            string[] fields = new string[4];
            string[] valEmptyFields = new string[2];

            bool allFieldsValidated = true; ;    //used to indicate weither all fields are valid and normal proccessing can proceed.

            //Checks if person is married in order to know if validation of partner details is needed
            if (cbMarried.CheckState == CheckState.Checked)
            {
                //populate fields array
                fields[0] = txtbMaidenName.Text;
                fields[1] = txtbPartnerFirstName.Text;
                fields[2] = txtbPartnerMaidenName.Text;
                fields[3] = txtbMarrageCity.Text;

                //populate valEmptyField array
                valEmptyFields[0] = txtbPartnerFirstName.Text;
                valEmptyFields[1] = txtbMarrageCity.Text;

                //Validate digits only fields
                string[] digitOnlyFields = { txtbPartnerId.Text };
                if (validator.valDigitsOnly(digitOnlyFields))
                {
                    //Validate Partner ID
                    if (validator.valIdNo(txtbPartnerId.Text) == false)
                    {
                        MessageBox.Show("The Partner ID Number field is either incomplete or an invalid ID Number.");
                        allFieldsValidated = false;
                    }
                }
                else
                {
                    MessageBox.Show("The Partner ID Number Field contains and illegal char that is not a number.");
                    txtbPartnerId.Clear();
                    allFieldsValidated = false;
                }

            }
            else
            {
                fields[0] = txtbMaidenName.Text;
            }

            //validate fields are not empty or contain illegal chars

            if (validator.valCompleted(valEmptyFields) == false)
            {
                MessageBox.Show("A Field was in complete");
                allFieldsValidated = false;
            }

            if (validator.valLettersAndSpace(fields) == false)
            {
                MessageBox.Show("Invalid char dettected in maiden name");
                allFieldsValidated = false;
            }

            //Validates that radio buttons are not empty
            RadioButton[] rabsNationality = { rabSouthAfrica, rabOther };
            RadioButton[] rabsMaleFemale = { rabMale, rabFemale };

            if (validator.valRadioButtonComplete(rabsNationality) == false)
            {
                MessageBox.Show("Nationality radio button has not been selected");
                allFieldsValidated = false;
            }

            if (validator.valRadioButtonComplete(rabsMaleFemale) == false)
            {
                MessageBox.Show("Male // Female radio button has not been selected");
                allFieldsValidated = false;
            }

            //Validates that an option is selected for combo boxes
            ComboBox[] cmbs = { cmbRace };

            if (validator.valComboBoxComplete(cmbs) == false)
            {
                MessageBox.Show("A selection for the drop down list was not made");
                allFieldsValidated = false;
            }

            //Generating an ID NO
            if (allFieldsValidated)
            {
                //Writes IDDoc Details after generating ID Number

                string nationality = null;
                char gender = ' ';
                string married;

                if (rabSouthAfrica.Checked)
                    nationality = "true";
                else if (rabOther.Checked)
                    nationality = "false";

                if (rabMale.Checked)
                    gender = 'M';
                else if (rabFemale.Checked)
                    gender = 'F';

                if (cbMarried.Checked)
                    married = "true";
                else
                    married = "false";

                //Retrieves user base information
                string[] userDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_USER);

                string[] idUserDetails = { CURRENT_USER, txtbMaidenName.Text, nationality, gender + "", cmbRace.Text, married, txtbPartnerId.Text, txtbPartnerFirstName.Text,
                                                    txtbPartnerMaidenName.Text, txtbMarrageCity.Text, dtpPartnerDateOfBirth.Text };

                //Generates actual ID Number and writes the ID UserDoc
                IDDoc idUser = new IDDoc(userDetails, idUserDetails, true);
                idUser.generateID();
                idUser.display();

                //Checks if id exists and opens up other tabs if it does to avoid a relog
                controlTabAccess();

            }

        }

        private void handelPassSubmit(ValidationCalculator validator)
        {

            //Ensures Terms and conditions have been agreed to
            if (cbTandCs.Checked == true)
            {
                //validate no fields are empty
                bool allFieldsValidated = true;
                string[] passRequiredFields = { txtbIdNo.Text, txtbHomeTell.Text, txtbPostalLine1.Text, txtbPostalLine2.Text,
                                                      txtbPostalLine3.Text, txtbCountryOfBirth.Text, txtbPlaceOfBirth.Text };

                if (validator.valCompleted(passRequiredFields) == false)
                {
                    MessageBox.Show("All fields where not completed(Keep in mind to split postal address across all 3 lines)");
                    allFieldsValidated = false;
                }

                //validate that certain fields only have digits
                string[] passDigitFields = { txtbIdNo.Text, txtbHomeTell.Text, txtbWorkTell.Text, txtbCell.Text };

                if (validator.valDigitsOnly(passDigitFields))
                {
                    //validate Id No
                    if (validator.valIdNo(txtbIdNo.Text) == false)
                    {
                        MessageBox.Show("An invalid ID Number was used");
                        allFieldsValidated = false;
                    }
                }
                else
                {
                    MessageBox.Show("One of the fields do not only contain digits. eg ID Number or one of the tellephone number fields.");
                    allFieldsValidated = false;
                }

                //validates that only letters and spaces where used in appropriate fields
                string[] passLettersAndSpacesFields = { txtbCountryOfBirth.Text, txtbPlaceOfBirth.Text };

                if (validator.valLettersAndSpace(passLettersAndSpacesFields) == false)
                {
                    MessageBox.Show("One of the birth fields contain more that just letters or spaces");
                    allFieldsValidated = false;
                }

                //Generates passport only if all fields are valid
                if (allFieldsValidated)
                {
                    //stores all the extra details for a passport user in an array to be able to create a passUser obj
                    string[] passUserDetails = { txtbHomeTell.Text, txtbWorkTell.Text, txtbCell.Text, txtbEmail.Text,
                                                   txtbPostalLine1.Text, txtbPostalLine2.Text, txtbPostalLine3.Text, txtbCountryOfBirth.Text, txtbPlaceOfBirth.Text };

                    //Retrives user base info and id info
                    string[] userDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_USER);
                    string[] userIdDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_IDUSER);

                    PassDoc passUser = new PassDoc(userDetails, userIdDetails, false, passUserDetails, true);

                    passUser.generatePassport();
                    passUser.display();

                }

            }
            else
            {
                MessageBox.Show("You havent accepted the terms and conditions");
            }
        }

        private void handelDeathSubmit(ValidationCalculator validator)
        {
            bool allFieldsValidated = true;

            //Validate required fields are complete
            string[] deathRequiredFields = { txtbDesceasedIdNo.Text, txtbDesceasedFirstNames.Text, txtbDesceasedSurname.Text, txtbTownOfDeath.Text, txtbProvinceOfDeath.Text,
                                               txtbNameOfUndertaker.Text, txtbApplicantHomeTell.Text, txtbApplicantPostalLine1.Text, txtbApplicantPostalLine2.Text, txtbApplicantPostalLine3.Text,
                                               txtbApplicantResidentialLine1.Text, txtbApplicantResidentialLine2.Text, txtbApplicantResidentialLine3.Text };

            if (validator.valCompleted(deathRequiredFields) == false)
            {
                MessageBox.Show("Not all the required fields have been completed. (Everything except work tell and cell)");
                allFieldsValidated = false;
            }

            //Validate that specific fields only contain didgets
            string[] deathDigitOnlyFields = { txtbDesceasedIdNo.Text, txtbApplicantHomeTell.Text, txtbApplicantWorkTell.Text, txtbCell.Text };

            if (validator.valDigitsOnly(deathDigitOnlyFields))
            {

                //validate Id No of desceased
                if (validator.valIdNo(txtbDesceasedIdNo.Text) == false)
                {
                    MessageBox.Show("An invalid ID Number was used");
                    allFieldsValidated = false;
                }
            }
            else
            {
                MessageBox.Show("Not all numerical fields only contain a numeral.");
                allFieldsValidated = false;
            }

            //Validates that only letters and spaces are used in appropriate fields
            string[] deathLettersAndSpacesFields = { txtbDesceasedFirstNames.Text, txtbMaidenName.Text, txtbDesceasedSurname.Text, txtbTownOfDeath.Text,
                                                       txtbProvinceOfDeath.Text, txtbNameOfUndertaker.Text };

            if (validator.valLettersAndSpace(deathLettersAndSpacesFields) == false)
            {
                MessageBox.Show("A field contains an illegal character. eg and @ symbol in the Name field.");
                allFieldsValidated = false;
            }

            //Generates death certificate if all fields have been validated
            if (allFieldsValidated)
            {
                //get base user details
                string[] userDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_USER);
                string[] userIdDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_IDUSER);
                string[] userDeathDetails = {CURRENT_USER, txtbDesceasedIdNo.Text, txtbDesceasedFirstNames.Text, txtbDesceasedMaidenName.Text, txtbDesceasedSurname.Text, dtpDateOfDeath.Text, txtbTownOfDeath.Text, txtbProvinceOfDeath.Text,
                                               txtbNameOfUndertaker.Text, txtbCauseOfDeath.Text, txtbApplicantHomeTell.Text, txtbApplicantWorkTell.Text, txtbApplicantCell.Text, txtbApplicantPostalLine1.Text, txtbApplicantPostalLine2.Text, txtbApplicantPostalLine3.Text,
                                               txtbApplicantResidentialLine1.Text, txtbApplicantResidentialLine2.Text, txtbApplicantResidentialLine3.Text };

                DeathDoc deathUser = new DeathDoc(userDetails, userIdDetails, false, userDeathDetails);

                deathUser.display();

            }

        }

        private void btnViewIdDoc_Click(object sender, EventArgs e)
        {

            if (tctrlMenu.SelectedTab.Name == "tpgIdDoc")
            {
                string[] userDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_USER);
                string[] idUserDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_IDUSER);

                //Checks a doc exists before trying to display it
                if (idUserDetails != null)
                {
                    IDDoc reviewIdUser = new IDDoc(userDetails, idUserDetails, false);

                    reviewIdUser.display();
                }
                else
                {
                    MessageBox.Show("You do not currently have an ID Document", "Error: ID Document does not exist");
                }
            }
            else if (tctrlMenu.SelectedTab.Name == "tpgPassport")
            {
                string[] userDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_USER);
                string[] idUserDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_IDUSER);
                string[] passUserDetails = searchUser(CURRENT_USER, FILE_DIRECTORY_PASSUSER);

                //Checks a doc exists before trying to display it
                if (passUserDetails != null)
                {
                    PassDoc reviewPassUser = new PassDoc(userDetails, idUserDetails, false, passUserDetails, false);

                    reviewPassUser.display();
                }
                else
                {
                    MessageBox.Show("You do not currently have a Passport Document", "Error: Passport Document does not exist");
                }

            }
            else if (tctrlMenu.SelectedTab.Name == "tpgDeathCert")
            {
                btnViewIdDoc.Hide();
                MessageBox.Show("Sorry this function is not available for a death certificate.");
            }
        }

        private void mnuItemHelpF1_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\..\Documentation\Home Affairs User Manual.docx"); 
        }

    }
}
