using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Author: Weylin Renison
 * Stud No: 12009634
 * Home Affairs v1.0
 * */


namespace MainGUI
{
    class User
    {
        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;

        public User(string userName, string password, string firstName, string lastName, string dateOfBirth, string addressLine1, string addressLine2, string addressLine3)
        {

            this.userName = userName;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.addressLine1 = addressLine1;
            this.addressLine2 = addressLine2;
            this.addressLine3 = addressLine3;
        }

        public User(string[] userDetails)
        {
            userName = userDetails[0];
            password = userDetails[1];
            firstName = userDetails[2];
            lastName = userDetails[3];
            dateOfBirth = userDetails[4];
            addressLine1 = userDetails[5];
            addressLine2 = userDetails[6];
            addressLine3 = userDetails[7];
        }

        public string UserName
        {
            get { return userName; }
        }

        public string Password
        {
            get { return Password; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }

        public string AddressLine3
        {
            get { return addressLine3; }
            set { addressLine3 = value; }
        }
        

    }
}
