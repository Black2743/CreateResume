using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateResume
{
    internal class CheckField
    {

        public static bool CheckedListBoxToTheSelectedElement(params CheckedListBox[] checkedListBox)
        {
            bool b = true;
            for (int i = 0; i < checkedListBox.Length; i++)
            {
                if (checkedListBox[i].SelectedItems.Count != 0)
                    continue;
                else
                {
                    b = false;
                    break;                
                }
            }
            return b;

        }
        public static bool CheckedTextBoxToFillIn(params TextBox[] textBoxes)  //проверка, существуют ли текст в полях
        {
            bool b = true;
            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i].Text != null)
                {
                    continue;
                }
                else
                {
                    b = false;
                    break;
                }
            }
            return b;
        }
        public static bool CheckPhoneNumber(ref TextBox textBox)  //проверка, правильно ли записан номер телефона
        {
            String number = textBox.Text;
            if (Regex.IsMatch(number, "^37529[0-9]{7}$") || Regex.IsMatch(number, "^37525[0-9]{7}$")
                || Regex.IsMatch(number, "^8025[0-9]{7}$") || Regex.IsMatch(number, "^8025[0-9]{7}$")
                || Regex.IsMatch(number, "^8044[0-9]{7}$") || Regex.IsMatch(number, "^37544[0-9]{7}$")
                || Regex.IsMatch(number, "^25[0-9]{7}$") || Regex.IsMatch(number, "^29[0-9]{7}$")
                || Regex.IsMatch(number, "^37544[0-9]{7}$") || Regex.IsMatch(number, "^37533[0-9]{7}$")
                || Regex.IsMatch(number, "^8033[0-9]{7}$") || Regex.IsMatch(number, "^33[0-9]{7}$")
                || Regex.IsMatch(number, @"^\+?375(29|33|25|44)\d{7}$")
                )
            {
                textBox.BackColor= Color.Green;
                return true;
            }
            else
            {
                textBox.BackColor = Color.Red;
                return false;
            }
        }
        public static bool IsValidEmail(ref TextBox textBox)
        {
            // возвращает 
            String strIn = textBox.Text;
            if(Regex.IsMatch(strIn,
                       @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")) { 
                textBox.BackColor=Color.Green;
                return true; }
            else
            {
                textBox.BackColor= Color.Red;
                return false;
            }
           
        }

        public static bool CheckNSPtoCorrectFill(ref TextBox textBox ) //проверка, правильно ли заполнено поле ФИО(NSP)
        {
            String NSP = textBox.Text;
            string test = "";
            string[] arra = NSP.Split(' ', '\n', 'r');
            foreach (string i in arra)
            {
                if (i != string.Empty)
                {
                    test += i + '|';
                }
            }
            arra = test.Split('|');
            if (arra.Length != 4)
            {
                textBox.BackColor= Color.Red;
                return false;
            }
            foreach (char c in NSP)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || c == 32|| ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))))
                {
                    textBox.BackColor= Color.Red;
                    return false;
                }
            }
            textBox.BackColor= Color.Green;
            return true;
        }

    }
}
