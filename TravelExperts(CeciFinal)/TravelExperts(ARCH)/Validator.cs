using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts_fileVersion_
{
    public static class Validator
    {
        private static string title = "Entry Error";       


        //check if text box not empty
        public static bool IsPresent(TextBox tb, string name)
        {
            bool valid = true; 
            if (tb.Text == "") // bad
            {
                valid = false;
                MessageBox.Show(name + " is required" , title);
                tb.Focus();
            }
            return valid;
        }

        public static bool IsPresent(RichTextBox rtb, string name)
        {
            bool valid = true;
            if (rtb.Text == "") // bad
            {
                valid = false;
                MessageBox.Show(name + " is required", title);
                rtb.Focus();
            }
            return valid;
        }

        public static bool IsListPresent(ListBox lb, string name)
        {
            bool valid = true;
            if (lb.Items.Count == 0) // bad
            {
                valid = false;
                MessageBox.Show("Please enter at least one "+ name + " to save", title);                
            }
            return valid;
        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", title);
                textBox.Focus();
                return false;
            }
        }

        // check if textbox has non-negative int value
        public static bool IsNonNegativeInt(TextBox tb, string name)
        {
            bool valid = true;
            int value;

            if (!Int32.TryParse(tb.Text, out value)) // bad news
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", title);
                tb.SelectAll();
                tb.Focus();
            }
            else if (value < 0) // bad
            {
                valid = false;
                MessageBox.Show(name + " must be equal to or greater than zero", title);
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // check if textbox has positive int value
        public static bool IsPositiveInt(TextBox tb, string name)
        {
            bool valid = true;
            int value;

            if (!Int32.TryParse(tb.Text, out value)) // bad news
            {
                valid = false;
                MessageBox.Show(name + " must be a whole number", title);
                tb.SelectAll();
                tb.Focus();
            }
            else if (value <= 0) // bad
            {
                valid = false;
                MessageBox.Show(name + " must be a positive whole number", title);
                tb.SelectAll();
                tb.Focus();
            }
            return valid;
        }

        // check if textbox has positive int value
        public static bool IsDecimal(TextBox textBox, string name)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a number.", title);
                textBox.Focus();
                return false;
            }
        }
   
        public static bool IsPositive(TextBox textBox, string name)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number <= 0) 
            {
                MessageBox.Show(name + " must be a positive number.", title);
                textBox.Focus();
                return false;
            }
            else
                return true;
        }

        public static bool IsNonNegative(TextBox textBox, string name)
        {
            try
            {
                decimal number = Convert.ToDecimal(textBox.Text.Trim('$'));
                if (number < 0)
                {
                    MessageBox.Show(name + " must be a non-negative number.", title);
                    textBox.Focus();
                    return false;
                }
                else
                    return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(name + " must be a number.", title);
                textBox.Focus();
                return false;
            }

        }    

        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag + " is a required field.", title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", title);
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        public static bool IsEditPresent(Control control, string name, string str)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(name + " is a required field.", title);
                    textBox.Text = str;
                    textBox.Select();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", title);
                    comboBox.Select();
                    return false;
                }
            }
            else
            {
                RichTextBox richTextBox = (RichTextBox)control;
                if (richTextBox.Text == "")
                {
                    MessageBox.Show(name + " is a required field.", title);
                    richTextBox.Text = str;
                    richTextBox.Select();
                    return false;
                }
            }
            return true;
        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min.ToString()
                    + " and " + max.ToString() + ".", title);
                textBox.Focus();
                return false;
            }
            return true;
        }

        //Method to check the Package End Date must be later than Package Start Date
        public static bool DateCheck(DateTime pkgStartDate, DateTime pkgEndDate)
        {
            TimeSpan difference = pkgEndDate.Subtract(pkgStartDate);
            int days = difference.Days;
            if (days < 0) 
            {
                MessageBox.Show("Package End Date must be later than Package Start Date", title);
                return false;
            }
            else
                return true;
        }

        public static bool ValidateCommission(TextBox textBox, string name, decimal pkgAgencyCommission, decimal pkgBasePrice)
        {
            if (pkgBasePrice < pkgAgencyCommission)
            {
                MessageBox.Show(name + " can not be greater than Package Base Price", title);
                textBox.Focus();
                return false;
            }
            else
                return true;
        }
    }
}
