using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainGUI
{
    class DeathUser : PassUser
    {

        private const string FILE_DATA_SPLITTER = ":";
        private const string FILE_DIRECTORY_PASSUSER = "DeathUsers.txt";
        private string deadIdNo;
        private string deadFirstNames;
        private string deadMaidenName;
        private string deadLastName;
        private string dateOfDeath;
        private string cityOfDeath;
        private string provinceOfDeath;
        private string nameOfUndertaker;
        private string causeOfDeath;
        private string resLine1;
        private string resLine2;
        private string resLine3;

        public DeathUser(string[] userDetails, string[] IDDetails, bool newId, string[] passDetails, bool newPass, string[] deathDetails)
            :base(userDetails, IDDetails, newId, passDetails, newPass)
        {
            deadIdNo = deathDetails[2];
            deadFirstNames = deathDetails[3];
            deadMaidenName = deathDetails[4];
            deadLastName = deathDetails[5];
            dateOfDeath = deathDetails[6];
            cityOfDeath = deathDetails[7];
            provinceOfDeath = deathDetails[8];
            nameOfUndertaker = deathDetails[9];
            causeOfDeath = deathDetails[10];
            ResLine1 = deathDetails[11];
            ResLine2 = deathDetails[12];
            ResLine3 = deathDetails[13];

        }

        public DeathUser(string[] userDetails, string[] IDDetails, bool newId, string[] deathDetails)
            : base(userDetails, IDDetails, newId)
        {
            deadIdNo = deathDetails[1];
            deadFirstNames = deathDetails[2];
            deadMaidenName = deathDetails[3];
            deadLastName = deathDetails[4];
            dateOfDeath = deathDetails[5];
            cityOfDeath = deathDetails[6];
            provinceOfDeath = deathDetails[7];
            nameOfUndertaker = deathDetails[8];
            causeOfDeath = deathDetails[9];
            HomeTell = deathDetails[10];
            WorkTell = deathDetails[11];
            Cell = deathDetails[12];
            PostalLine1 = deathDetails[13];
            PostalLine2 = deathDetails[14];
            PostalLine3 = deathDetails[15];
            resLine1 = deathDetails[16];
            resLine2 = deathDetails[17];
            resLine3 = deathDetails[18];

        }

        public override void display()
        {
            DeathCertDisplay deathCertDisplay = new DeathCertDisplay();

            deathCertDisplay.txtbDesceasedIdNoDisplay.Text = DeadIdNumber;
            deathCertDisplay.txtbDesceasedFirstNamesDisplay.Text = DeadFirstNames;
            deathCertDisplay.txtbDesceasedMaidenNameDisplay.Text = DeadMaidenName;
            deathCertDisplay.txtbDesceasedSurnameDisplay.Text = DeadLastName;
            deathCertDisplay.dtpDateOfDeathDisplay.Text = DateOfDeath;
            deathCertDisplay.txtbTownOfDeathDisplay.Text = CityOfDeath;
            deathCertDisplay.txtbProvinceOfDeathDisplay.Text = ProvinceOfDeath;
            deathCertDisplay.txtbNameOfUndertakerDisplay.Text = NameOfUndertaker;
            deathCertDisplay.txtbCauseOfDeath.Text = CauseOfDeath;

            deathCertDisplay.Show();

        }


         public string DeadIdNumber
        {
            get { return deadIdNo; }
            set { deadIdNo = value; }
        }

        public string DeadFirstNames
        {
            get { return deadFirstNames; }
            set { deadFirstNames = value; }
        }

        public string DeadMaidenName
        {
            get { return deadMaidenName; }
            set { deadMaidenName = value; }
        }

        public string DeadLastName
        {
            get { return deadLastName; }
            set { deadLastName = value; }
        }

        public string DateOfDeath
        {
            get { return dateOfDeath; }
            set { dateOfDeath = value; }
        }

        public string CityOfDeath
        {
            get { return cityOfDeath; }
            set { cityOfDeath = value; }
        }

        public string ProvinceOfDeath
        {
            get { return provinceOfDeath; }
            set { provinceOfDeath = value; }
        }

        public string NameOfUndertaker
        {
            get { return nameOfUndertaker; }
            set { nameOfUndertaker = value; }
        }

        public string CauseOfDeath
        {
            get { return causeOfDeath; }
            set { causeOfDeath = value; }
        }

 

        public string ResLine1
        {
            get { return resLine1; }
            set { resLine1 = value; }
        }

        public string ResLine2
        {
            get { return resLine2; }
            set { resLine2 = value; }
        }

        public string ResLine3
        {
            get { return resLine3; }
            set { resLine3 = value; }
        }



    }
}
