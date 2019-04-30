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
    public enum Position
    {
        pacjent,
        lekarz
    };
    public partial class FormLogin : Form
    {
        public static Position position;
        public static double pesel;
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

        public bool IsInDatabase(string CurrentPesel, string CurrentSurname, string CurrentID, string table)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open()) {

                    double.TryParse(CurrentPesel, out double dPesel);
                    if (table == "pacjenci") {
                        List<Patient> results = connection.PatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM {table} WHERE pesel={CurrentPesel} AND nazwisko=\"{CurrentSurname}\" AND idp={CurrentID}");
                        if (results.Count > 0)
                        {
                            pesel = dPesel;
                            position = Position.pacjent;
                            return true;
                        }
                        else { return false; }
                    }
                    else
                    {
                        List<Doctor> results = connection.DoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM {table} WHERE pesel={CurrentPesel} AND nazwisko=\"{CurrentSurname}\" AND idd={CurrentID}");
                        if (results.Count > 0)
                        {
                            pesel = dPesel;
                            position = Position.lekarz;
                            return true;
                        }
                        else { return false; }
                    }
                }
                else {
                    MessageBox.Show("Błąd z połaczeniem!");
                    Close();
                    return false;
                }
            }
        }

        private void textBoxPesel_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesel.Text.Length == 11 && double.TryParse(textBoxPesel.Text, out double dPesel))
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
            try
            {
                int.Parse(textBoxID.Text);
            }
            catch (FormatException)
            {
                textBoxID.Text = "-1";
            }

            if (IsInDatabase(textBoxPesel.Text, textBoxSurname.Text, textBoxID.Text, "pacjenci")) {
                DialogResult = DialogResult.OK;
                Close();
                Console.WriteLine("Logowanie na pacjenta udane!");
            }
            else if(IsInDatabase(textBoxPesel.Text, textBoxSurname.Text, textBoxID.Text, "doktorzy")){
                DialogResult = DialogResult.Yes;
                Close();
                Console.WriteLine("Logowanie na lekarza udane!");
            }
            else
            {
                MessageBox.Show("Błędne dane!");
            }
        }
    }
}
