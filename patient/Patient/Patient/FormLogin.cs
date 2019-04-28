using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        bool PeselValidation(double dPesel)
        {
            int[] multipliers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int sum = 0;
            char[] cPesel = new char[11];
            cPesel = dPesel.ToString().ToCharArray();


            for (int i = 0; i < multipliers.Length; i++)
            {
                sum += multipliers[i] * int.Parse(cPesel[i].ToString());
            }

            if (sum % 10 == 0) { return true; }
            else { return false; }
        }
        public bool IsInDatabase(string CurrentPesel, string CurrentSurname, string CurrentID)
        {
            //zapytanie do bazy czy taki pesel juz istnieje
            //if(wynik['pesel'] == CurrentPesel && [...])
            //{
            //    return true;
            //}
            //else { return false; }

            // test
            return true;
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPesel_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesel.Text.Length == 11 && Double.TryParse(textBoxPesel.Text, out double dPesel))
            {
                if (PeselValidation(dPesel)) { buttonLogin.Enabled = true; }
                else
                {
                    buttonLogin.Enabled = false;
                    MessageBox.Show("Błąd! Niepoprawny numer PESEL!");
                }
            }
            else { buttonLogin.Enabled = false; }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (IsInDatabase(textBoxPesel.Text, textBoxSurname.Text, textBoxID.Text)) {
                this.DialogResult = DialogResult.OK;
                this.Close();
                Console.WriteLine("Logowanie udane!");
            }
            else
            {
                MessageBox.Show("Błędne dane!");
            }
        }
    }
}
