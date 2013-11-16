using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MainGUI
{
    class PassDoc : IDDoc
    {
        private const string FILE_DATA_SPLITTER = ":";
        private const string FILE_DIRECTORY_PASSUSER = "PassUsers.txt";
        private string homeTell;
        private string workTell;
        private string cell;
        private string email;
        private string postalLine1;
        private string postalLine2;
        private string postalLine3;
        private string countryOfBirth;
        private string placeOfBirth;
        private string passNumber = null;
        private string dateOfIssue;
        private string expiryDate;

        //Constructor, the newPass param det if the user has a passport already or if they need a new one
        public PassDoc(string[] userDetails, string[] IDDetails, bool newId, string[] passDetails, bool newPass)
            :base(userDetails, IDDetails, newId)
        {
            if (newPass)
            {
                homeTell = passDetails[0];
                workTell = passDetails[1];
                cell = passDetails[2];
                email = passDetails[3];
                postalLine1 = passDetails[4];
                postalLine2 = passDetails[5];
                postalLine3 = passDetails[6];
                countryOfBirth = passDetails[7];
                placeOfBirth = passDetails[8];
            }
            else
            {
                homeTell = passDetails[2];
                workTell = passDetails[3];
                cell = passDetails[4];
                email = passDetails[5];
                postalLine1 = passDetails[6];
                postalLine2 = passDetails[7];
                postalLine3 = passDetails[8];
                countryOfBirth = passDetails[9];
                placeOfBirth = passDetails[10];
                passNumber = passDetails[11];
                dateOfIssue = passDetails[12];
                expiryDate = passDetails[13];
            }

        }

        public PassDoc(string[] userDetails, string[] IDDetails, bool newId)
            : base(userDetails, IDDetails, newId)
        {

            homeTell = "";
            workTell = "";
            cell = "";
            email = "";
            postalLine1 = "";
            postalLine2 = "";
            postalLine3 = "";
            countryOfBirth = "";
            placeOfBirth = "";
        }

        public void generatePassNumber()
        {
            Random radGen = new Random();

            passNumber = (radGen.Next(10000, 999999)) + "";

            PassNumber = passNumber;

        }

        public void generateDates()
        {
            DateTime currentDate = DateTime.Now;

            //sets date of issue
            dateOfIssue = currentDate.Day + "-" + currentDate.Month + "-" + currentDate.Year;

            //calc expiry date and sets it
            expiryDate = currentDate.Day + "-" + currentDate.Month + "-" + (currentDate.Year + 10);
            
        }

        public void generatePassport()
        {
            generatePassNumber();
            generateDates();
            writeUser();

        }

        //Writes the new passport to file
        override public void writeUser()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FILE_DIRECTORY_PASSUSER, true))
                {
                    string idDetailsToWrite = UserName + FILE_DATA_SPLITTER + IDNumber + FILE_DATA_SPLITTER + HomeTell + FILE_DATA_SPLITTER + WorkTell
                                                    + FILE_DATA_SPLITTER + Cell + FILE_DATA_SPLITTER + Email + FILE_DATA_SPLITTER + PostalLine1 + FILE_DATA_SPLITTER
                                                    + PostalLine2 + FILE_DATA_SPLITTER + PostalLine3 + FILE_DATA_SPLITTER + CountryOfBirth
                                                    + FILE_DATA_SPLITTER + PlaceOfBirth + FILE_DATA_SPLITTER + PassNumber + FILE_DATA_SPLITTER + DateOfIssue + FILE_DATA_SPLITTER + ExpiryDate;

                    writer.WriteLine(idDetailsToWrite);

                }
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show("Directory for Passport writing was not found: " + dnfe.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("An IO Exception occured while writing Passport Details: " + ioe.Message);
            }
        }

        //Displays passport
        override public void display()
        {
            frmPassportDocumentDisplay passDocDisplay = new frmPassportDocumentDisplay();

            passDocDisplay.txtbPassDisplayName.Text = FirstName;
            passDocDisplay.txtbPassDisplayName2.Text = FirstName;
            passDocDisplay.txtbPassDisplaySurname.Text = LastName;
            passDocDisplay.txtbPassDisplaySurname2.Text = LastName;
            passDocDisplay.txtbPassDisplayIdNo.Text = IDNumber;
            passDocDisplay.txtbPassDisplayIdNo2.Text = IDNumber;
            passDocDisplay.txtbPassDisplayGender.Text = Gender + "";
            passDocDisplay.txtbPassDisplayDateOfBirth.Text = DateOfBirth;
            passDocDisplay.txtbPassDisplayIssueDate.Text = DateOfIssue;
            passDocDisplay.txtbPassDisplayExpiryDate.Text = ExpiryDate;
            passDocDisplay.txtbPassDisplayPassNo.Text = PassNumber;

            if (Nationality)
                passDocDisplay.txtbPassDisplayCitizenship.Text = "South African";
            else
                passDocDisplay.txtbPassDisplayCitizenship.Text = "Other";

            passDocDisplay.Show();

        }

        public string DateOfIssue
        {
            get { return dateOfIssue; }
            set { dateOfIssue = value; }
        }

        public string ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public string HomeTell
        {
            get { return homeTell; }
            set { homeTell = value; }
        }

        public string WorkTell
        {
            get { return workTell; }
            set { workTell = value; }
        }

        public string Cell
        {
            get { return cell; }
            set { cell = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PostalLine1
        {
            get { return postalLine1; }
            set { postalLine1 = value; }
        }

        public string PostalLine2
        {
            get { return postalLine2; }
            set { postalLine2 = value; }
        }

        public string PostalLine3
        {
            get { return postalLine3; }
            set { postalLine3 = value; }
        }

        public string CountryOfBirth
        {
            get { return countryOfBirth; }
            set { countryOfBirth = value; }
        }

        public string PlaceOfBirth
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }

        public string PassNumber
        {
            get { return passNumber; }
            set { passNumber = value; }
        }

    }
}
