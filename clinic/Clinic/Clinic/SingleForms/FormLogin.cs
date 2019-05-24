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
    // zmienna przechowujaca kto aktualnie jest zalogowany
    public enum Position
    {
        pacjent,
        lekarz
    };

    public partial class FormLogin : Form
    {
        #region Static fields
        public static Position position;
        public static Patient patient;
        public static Doctor doctor;
        #endregion

        public FormLogin()
        {
            InitializeComponent();
        }

        #region Methods
        // walidacja numeru PESEL
        private bool PeselValidation(double dPesel)
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

        // czy jest w bazie danych
        private bool IsInDatabase(string currentPesel, string currentSurname, string currentID)
        {
            using (var connection = new DatabaseConnection())
            {
                // jesli idzie otworzyc polaczenie
                if (connection.Open()) {
                    double.TryParse(currentPesel, out double dPesel); // pesel jest przechowywany w stringu, parsujemy na double

                    if (connection.SelectCount($"SELECT COUNT(*) FROM pacjenci WHERE pesel={currentPesel} AND nazwisko=\"{currentSurname}\" AND idp={currentID}") > 0)
                    {

                        patient = connection.GetPatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM pacjenci WHERE pesel={currentPesel} AND nazwisko=\"{currentSurname}\" AND idp={currentID}");

                        // ustaw, ze loguje sie pacjent
                        position = Position.pacjent;
                        return true;
                    }
                    else if (connection.SelectCount($"SELECT COUNT(*) FROM doktorzy WHERE pesel={currentPesel} AND nazwisko=\"{currentSurname}\" AND idd={currentID}") > 0)
                    {
                        doctor = connection.GetDoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM doktorzy WHERE pesel={currentPesel} AND nazwisko=\"{currentSurname}\" AND idd={currentID}");
                        // ustaw, ze loguje sie lekarz
                        position = Position.lekarz;
                        return true;
                    }
                    // jesli jednak nie ma w bazie to zwroc falsz
                    else { return false; }
                }
                else {
                    // zwroc falsz i problem z polaczeniem jesli nie udalo sie otworzyc polaczenia
                    MessageBox.Show("Błąd z połaczeniem!");
                    DialogResult = DialogResult.Abort;
                    return false;
                }
            }
        }

        // czy pesel istnieje w bazie danych
        private bool PeselExistsInDatabase(string currentPesel)
        {
            using (var connection = new DatabaseConnection())
            {
                // jesli idzie otworzyc polaczenie
                if (connection.Open())
                {
                    double.TryParse(currentPesel, out double dPesel); // pesel jest przechowywany w stringu, parsujemy na double

                    // lista pacjentow; powinien byc jeden wynik, ale na wszelki wypadek wrzucamy do listy (bo w koncu select bez LIMIT 1)
                    if (connection.SelectCount($"SELECT COUNT(*) FROM pacjenci WHERE pesel={currentPesel}") > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
                else
                {
                    // zwroc falsz i problem z polaczeniem jesli nie udalo sie otworzyc polaczenia
                    MessageBox.Show("Błąd z połaczeniem!");
                    DialogResult = DialogResult.Abort;
                    return false;
                }
            }
        }

        private void textBoxPesel_TextChanged(object sender, EventArgs e)
        {
            // jesli pesel ma 11 znakow i jest wartoscia liczbowa
            if (textBoxPesel.Text.Length == 11 && double.TryParse(textBoxPesel.Text, out double dPesel))
            {
                // odpal walidacje; jesli przejdzie to odpal przycisk
                if (PeselValidation(dPesel)) { buttonLogin.Enabled = true; }
                else
                {
                    // jesli walidacji nie przejdzie to wyswietl info, ze bledny PESEL (tylko dla 11 znakow)
                    buttonLogin.Enabled = false;
                    MessageBox.Show("Błąd! Niepoprawny numer PESEL!");
                }
            }
            // w innym przypadku (<>11 znakow) wylacz przycisk
            else { buttonLogin.Enabled = false; }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // jesli ID nie jest wartoscia liczbowa to ustaw -1, zeby przeszlo pozniejsza walidacje i wyrzucilo bledne dane
            try
            {
                int.Parse(textBoxID.Text);
            }
            catch (FormatException)
            {
                textBoxID.Text = "-1";
            }
            
            // jesli jest w bazie danych to pozwol na logowanie
            if (IsInDatabase(textBoxPesel.Text, textBoxSurname.Text, textBoxID.Text))
            {
                DialogResult = DialogResult.OK;
                if (position == Position.pacjent) { Console.WriteLine("Logowanie na pacjenta udane!"); }
                else { Console.WriteLine("Logowanie na lekarza udane!"); }
            }
            // jesli jednak nie jest w bazie to wyrzuc info o blednych danych (chyba, ze blad z polaczeniem to tylko info o bledzie z polaczeniem)
            else
            {
                if (DialogResult != DialogResult.Abort)
                {
                    if (!PeselExistsInDatabase(textBoxPesel.Text))
                    {
                        patient = new Patient(-1, "", "", double.Parse(textBoxPesel.Text), Sexs.kobieta, DateTime.Now, "", "");
                        DialogResult = DialogResult.No;
                    }
                    if (DialogResult != DialogResult.No) { MessageBox.Show("Błędne dane!"); }
                }
            }
        }
        #endregion
    }
}
