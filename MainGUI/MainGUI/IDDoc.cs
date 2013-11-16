using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MainGUI
{
    class IDDoc : UserDoc
    {
        private const string FILE_DIRECTORY_IDUSER = "IDUsers.txt";
        private const string FILE_DATA_SPLITTER = ":";
        private string maidenName;
        private bool nationality;
        private char gender;
        private string race;
        private bool married;
        private string partnerIdNo;
        private string partnerNames;
        private string partnerMaidenName;
        private string marrageCity;
        private string partnerDateOfBirth;
        private string idNumber = null;

        //Constructor with inheritance values being sent to parent class
        public IDDoc(string userName, string password, string firstName, string lastName, string dateOfBirth, string addressLine1, string addressLine2, string addressLine3, string maidenName, bool nationality, char gender, string race, bool married, string partnerIdNo, string partnerNames, string partnerMaidenName, string marrageCity, string partnerDateOfBirth)
            : base(userName, password, firstName, lastName, dateOfBirth, addressLine1, addressLine2, addressLine3)
        {
            this.maidenName = maidenName;
            this.nationality = nationality;
            this.gender = gender;
            this.race = race;
            this.married = married;
            this.partnerIdNo = partnerIdNo;
            this.partnerNames = partnerNames;
            this.partnerMaidenName = partnerMaidenName;
            this.marrageCity = marrageCity;
            this.partnerDateOfBirth = partnerDateOfBirth;
        }
         
        //Same constructor as above, however using arrays and an extra param this param is to det if the user needs a new id or if they already have one
        public IDDoc(string[] userDetails, string[] IDDetails, bool newId)
            : base(userDetails)
        {
            if (newId)
            {
                this.maidenName = IDDetails[1];
                this.nationality = bool.Parse(IDDetails[2]);
                this.gender = char.Parse(IDDetails[3]);
                this.race = IDDetails[4];
                this.married = bool.Parse(IDDetails[5]);
                this.partnerIdNo = IDDetails[6];
                this.partnerNames = IDDetails[7];
                this.partnerMaidenName = IDDetails[8];
                this.marrageCity = IDDetails[9];
                this.partnerDateOfBirth = IDDetails[10];
            }
            else
            { 
                this.idNumber = IDDetails[1];
                this.maidenName = IDDetails[2];
                this.nationality = bool.Parse(IDDetails[3]);
                this.gender = char.Parse(IDDetails[4]);
                this.race = IDDetails[5];
                this.married = bool.Parse(IDDetails[6]);
                this.partnerIdNo = IDDetails[7];
                this.partnerNames = IDDetails[8];
                this.partnerMaidenName = IDDetails[9];
                this.marrageCity = IDDetails[10];
                this.partnerDateOfBirth = IDDetails[11];
            }
        }

        public string generateIDNumber()
        {
            DateTime dob = DateTime.Parse(DateOfBirth);

            //Generate the first 6 numbers from date of birth yymmdd
            string year = (dob.Year + "").Substring(2,2);
            string month = (dob.Month + "");
            string day = (dob.Day + "");

            //used to add a 0 to the front of a month or day if it is bellow 10
            if (month.Length == 1)
                month = "0" + month;

            if (day.Length == 1)
                day = "0" + day;

            idNumber = year + month + day;

            //next digit represents male or female 0 - 4 is female 5 - 9 represents male
            Random randNumGenerator = new Random();
            string genderNumbers;

            if (gender == 'F')
                genderNumbers = randNumGenerator.Next(4000) + "";
            else
                genderNumbers = randNumGenerator.Next(4001, 9999) + "";

            idNumber = idNumber + genderNumbers;

            //next digit represents nationality
            if (nationality)
                idNumber = idNumber + "0";
            else
                idNumber = idNumber + "1";

            //next digit represents race but no longer applies so digit can either be 8 or 9
            idNumber = idNumber + randNumGenerator.Next(8, 9);
            
            //Generates and add the check digit to the id number
            string checkDigit = generateIdCheckDigit(idNumber);
            idNumber = idNumber + checkDigit;                  

            return idNumber;
        }

        public void generateID()
        {
            generateIDNumber();
            writeUser();
            
        }

        //This writes the users id detail to file
        public virtual void writeUser()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FILE_DIRECTORY_IDUSER, true))
                {
                    string idDetailsToWrite = UserName + FILE_DATA_SPLITTER + idNumber + FILE_DATA_SPLITTER + MaidenName + FILE_DATA_SPLITTER + Nationality
                                                    + FILE_DATA_SPLITTER + Gender + FILE_DATA_SPLITTER + Race + FILE_DATA_SPLITTER + Married + FILE_DATA_SPLITTER
                                                    + PartnerIdNo + FILE_DATA_SPLITTER + PartnerNames + FILE_DATA_SPLITTER + PartnerMaidenName
                                                    + FILE_DATA_SPLITTER + MarrageCity + FILE_DATA_SPLITTER + PartnerDateOfBirth;

                    writer.WriteLine(idDetailsToWrite);
                                        
                }
            }
            catch (DirectoryNotFoundException dnfe)
            {
                MessageBox.Show("Directory for ID writing was not found: " + dnfe.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show("An IO Exception occured while writing ID Details: " + ioe.Message);
            }
        }

        //This displays the users id
        public virtual void display()
        {
            frmIdDocumentDisplay display = new frmIdDocumentDisplay();

            string citizenship;

            if (Nationality)
                citizenship = "South Africa";
            else
                citizenship = "Other";

            DateTime currentDate = DateTime.Now;
            
            display.txtbDisplayIdNo.Text = IDNumber;
            display.txtbDisplayCitizenship.Text = citizenship;
            display.txtbDisplaySurname.Text = LastName;
            display.txtbDisplayNames.Text = FirstName;
            display.txtbDisplayBirthCountry.Text = citizenship;
            display.txtbDisplayBirthDate.Text = DateOfBirth;
            display.txtbDisplayIssueDate.Text = currentDate.Year + "-" + currentDate.Month + "-" + currentDate.Day;

            display.Show();
            
        }

        public string generateIdCheckDigit(string idNumber)
        {
            string checkDigit;

            //gets all the 12 current digits in the id number so far in an int format
            int[] idDigits = new int[idNumber.Length];
            for (int i = 0; i < idNumber.Length; i++)
            {
                idDigits[i] = int.Parse(idNumber.Substring(i, 1));
            }

            //sums all the odd position digits. osi = odd sum index
            int oddSum = 0;
            string oddValues = "";
            for (int osi = 0; osi < idDigits.Length; osi = osi + 2)
            {
                oddValues = oddValues + idDigits[osi];
                oddSum = oddSum + idDigits[osi];
            }

            //Concats all the even position digits then multiply them by 2. eci = even concat index
            string evenDigits = "";
            for (int eci = 1; eci < idDigits.Length; eci = eci + 2)
            {               
                evenDigits = evenDigits + idDigits[eci];
            }

            string evenDigitsDoubled = (int.Parse(evenDigits) * 2) +"";

            //sum of the evenDigitsDoubled. esi = even sum index
            int evenSum = 0; ;
            for (int esi = 0; esi < evenDigitsDoubled.Length; esi++)
            {
                evenSum = evenSum + int.Parse(evenDigitsDoubled.Substring(esi, 1));
            }

            //the sum of (odd position sum) + evenSum
            string sum = (oddSum + evenSum) + "";

            //minus the second digit of the result from 10
            checkDigit = (10 - int.Parse(sum.Substring(1, 1))) + "";

            //checks if the result is 2 digits or one. if so the second digit is the final check digit
            if (checkDigit.Length > 1)
                checkDigit = checkDigit.Substring(1, 1);

            return checkDigit;
        }

        public string MaidenName
        {
            get { return maidenName; }
            set { maidenName = value; }
        }

        public bool Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Race
        {
            get { return race; }
            set { race = value; }
        }

        public bool Married
        {
            get { return married; }
            set { married = value; }
        }

        public string PartnerIdNo
        {
            get { return partnerIdNo; }
            set { partnerIdNo = value; }
        }

        public string PartnerNames
        {
            get { return partnerNames; }
            set { partnerNames = value; }
        }

        public string PartnerMaidenName
        {
            get { return partnerMaidenName; }
            set { partnerMaidenName = value; }
        }

        public string MarrageCity
        {
            get{ return marrageCity;}
            set { marrageCity = value; }
        }

        public string PartnerDateOfBirth
        {
            get { return partnerDateOfBirth; }
            set { partnerDateOfBirth = value; }
        }

        public string IDNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

    }
}
