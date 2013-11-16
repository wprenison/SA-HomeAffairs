using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainGUI
{
    class ValidationCalculator
    {
        const char FILE_DATA_SPLITTER = ':';

        public ValidationCalculator()
        {

        }

        public bool valIdNo(string IdNoToValidate)
        {
            bool validId = false;

            string checkDigit;

            if (IdNoToValidate.Length > 12)
            {
                
                //gets all the 12 current digits in the id number so far in an int format
                int[] idDigits = new int[IdNoToValidate.Length-1];
                for (int i = 0; i < idDigits.Length; i++)
                {
                    idDigits[i] = int.Parse(IdNoToValidate.Substring(i, 1));
                }

                //sums all the odd position digits. osi = odd sum index
                int oddSum = 0;
                string oddValues = "";
                for (int osi = 0; osi < idDigits.Length-1; osi = osi + 2)
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

                string evenDigitsDoubled = (int.Parse(evenDigits) * 2) + "";

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

                //compares last didgit of id number to validate against the check digit calculated
                if (IdNoToValidate.Substring(12, 1) == checkDigit)
                    validId = true;
                else
                    validId = false;
            }
            else
            {
                validId = false;
            }

            return validId;
        }

        //Validates if a combo box value has been selected
        public bool valComboBoxComplete(ComboBox[] cmbsToValidate)
        {
            bool optionSelectedForAllCmbs = true;

            for (int i = 0; i < cmbsToValidate.Length; i++)
            {
                if (cmbsToValidate[i].SelectedItem == null)
                    optionSelectedForAllCmbs = false;
            }

            return optionSelectedForAllCmbs;
        }

        //validates weither an option is selected in a radio button group
        public bool valRadioButtonComplete(RadioButton[] radGroup)
        {
            bool optionSelected = false;

            for (int i = 0; i < radGroup.Length; i++)
            {
                if (radGroup[i].Checked == true)
                {
                    optionSelected = true;
                    break;
                }
            }

            return optionSelected;
        }

        //validates if a set of strings have been completed
        public bool valCompleted(string[] fieldsToValidate)
        {
            bool fieldsComplete = true;

            for (int i = 0; i < fieldsToValidate.Length-1; i++)
            {
                if (fieldsToValidate[i] == "")
                {
                    fieldsComplete = false;
                    break;
                }
            }

            return fieldsComplete;
        }

        //validates a list of strings that they only contain letters or spaces
        public bool valLettersAndSpace(string[] fieldsToValidate)
        {
            bool valLetterAndSpace = true;

            char[] fieldChars;

            //By passes concat if there is only 1 string value in the array
            if (fieldsToValidate.Length > 1 && fieldsToValidate[1] != null)
                fieldChars = concatUpperCase(fieldsToValidate);
            else
                fieldChars = fieldsToValidate[0].ToUpper().ToCharArray();

            //Searches chars for illegal char, char must be in !uppercase!
            for (int i = 0; i < fieldChars.Length; i++)
            {
                if ((fieldChars[i] > 0 && fieldChars[i] < 32) || fieldChars[i] == 58 || (fieldChars[i] > 32 && fieldChars[i] < 65) || fieldChars[i] > 90)
                    valLetterAndSpace = false;               

            }

            return valLetterAndSpace;
        }

        //validates a list of string that they only contain didgits
        public bool valDigitsOnly(string[] fieldsToValidate)
        {
            bool valDigitsOnly = true;

            char[] fieldChars;

            //By passes concat if there is only 1 string value in the array
            if (fieldsToValidate.Length > 1 && fieldsToValidate[1] != null)
                fieldChars = concatUpperCase(fieldsToValidate);
            else
                fieldChars = fieldsToValidate[0].ToUpper().ToCharArray();

            //Searches chars for illegal char, char must be in !uppercase!
            for (int i = 0; i < fieldChars.Length; i++)
            {
                if ((fieldChars[i] > 47 && fieldChars[i] < 58))
                    valDigitsOnly = false;

            }

            return valDigitsOnly;
        }

        //validates that a password has at least one caps, one non caps, one special char and is >= 6 chars 
        public bool valPassword(string passwordToValidate)
        {
            bool validPassword = false;
            bool caps = false;
            bool noCaps = false;
            bool special = false;
            bool sperator = true;
            bool length = false;

            char[] passwordChars = passwordToValidate.ToCharArray();

            for (int i = 0; i < passwordChars.Length; i++)
            {
                if ((passwordChars[i] > 31 && passwordChars[i] < 58) || passwordChars[i] > 90 && passwordChars[i] < 97 || passwordChars[i] >122 && passwordChars[i] < 127 )
                    special = true;

                if (passwordChars[i] > 64 && passwordChars[i] < 91)
                    caps = true;

                if (passwordChars[i] > 96 && passwordChars[i] < 123)
                    noCaps = true;

                if (passwordChars.Length >= 6)
                    length = true;

                if (passwordToValidate.Contains(FILE_DATA_SPLITTER) == false)
                    sperator = false;

                if (special && caps && noCaps && length && sperator == false)
                {
                    validPassword = true;
                    break;
                }
            }

            return validPassword;
        }

        //conactenates a bunch of strings in uppercase and returns a char array with each letter in an element
        public char[] concatUpperCase(string[] concatStrings)
        {
            string concatedString = null;
            char[] charArray;

            for (int i = 0; i <= concatStrings.Length-2; i++)
            {
                concatedString = concatStrings[i].ToUpper() + concatStrings[i + 1].ToUpper();
            }

            charArray = new char[concatedString.Length];
            charArray = concatedString.ToCharArray();

            return charArray;
        }

    }
}
