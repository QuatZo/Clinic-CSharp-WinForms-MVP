using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
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

            // to tylko zapytanie czy taki PESEL istnieje, tu beda inne dane
            using (var connection = new DatabaseConnection("localhost", "sanivitas", "root", ""))
            {
                if (connection.Open()) {
                    List<Patient> results = connection.QueryPatients($"SELECT * FROM osoba WHERE pesel={CurrentPesel}");

                if (results.Count > 0) { return true; }
                    else { return false; }
                }
                else {
                    MessageBox.Show("Błąd z połaczeniem!");
                    Close();
                    return false;
                }
            }
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
