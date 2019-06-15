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
    // typ wyliczeniowy, kto jest zalogowany (zamiast operacji na 0 1 czy bool)
    public enum Position
    {
        pacjent,
        lekarz
    };

    public partial class FormLogin : Form
    {
        #region Singleton
        private static FormLogin instance;

        public static FormLogin Instance
        {
            get
            {
                return instance ?? (instance = new FormLogin());
            }
        }
        #endregion

        #region Fields
        private readonly DatabaseConnection connection = DatabaseConnection.Instance;
        #endregion

        #region Properties
        public string Surname
        {
            get
            {
                return textBoxSurname.Text;
            }
            set
            {
                textBoxSurname.Text = value;
            }
        }
        public double Pesel
        {
            get
            {
                return double.Parse(textBoxPesel.Text);
            }
            set
            {
                textBoxPesel.Text = value.ToString();
            }
        }
        public int Id
        {
            get
            {
                return int.Parse(textBoxID.Text);
            }
            set
            {
                textBoxID.Text = value.ToString();
            }
        }

        public Position Position { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        #endregion

        private FormLogin()
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
            // jesli idzie otworzyc polaczenie
            if (connection.Open()) {
                double.TryParse(currentPesel, out double dPesel); // pesel jest przechowywany w stringu, parsujemy na double

                // parametryzacja zapytań
                Dictionary<string, string> loginParameters = new Dictionary<string, string>
                {
                    {"@id", currentID },
                    {"@pesel", currentPesel },
                    {"@surname", currentSurname }
                };

                // jesli jest taki ktos w bazie
                if (connection.SelectCount($"SELECT COUNT(*) FROM pacjenci WHERE pesel=@pesel AND nazwisko=@surname AND idp=@id", loginParameters) > 0)
                {
                    Patient = connection.GetPatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM pacjenci WHERE pesel=@pesel AND nazwisko=@surname AND idp=@id", loginParameters);
                    Position = Position.pacjent;
                    connection.Close();
                    return true;
                }
                // jesli nie to sprawdz czy jest taki lekarz
                else if (connection.SelectCount($"SELECT COUNT(*) FROM doktorzy WHERE pesel=@pesel AND nazwisko=@surname AND idd=@id", loginParameters) > 0)
                {
                    Doctor = connection.GetDoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM doktorzy WHERE pesel=@pesel AND nazwisko=@surname AND idd=@id", loginParameters);
                    Position = Position.lekarz;
                    connection.Close();
                    return true;
                }
                // jesli jednak nie ma w bazie to zwroc falsz
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else {
                // zwroc falsz i problem z polaczeniem jesli nie udalo sie otworzyc polaczenia
                MessageBox.Show("Błąd z połaczeniem!");
                DialogResult = DialogResult.Abort;
                return false;
            }
        }

        // czy pesel istnieje w bazie danych
        private bool PeselExistsInDatabase(string currentPesel)
        {
            // jesli idzie otworzyc polaczenie
            if (connection.Open())
            {
                double.TryParse(currentPesel, out double dPesel); // pesel jest przechowywany w stringu, parsujemy na double

                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    {"@pesel", currentPesel }
                };

                // jeśli znaleziono kogoś o takim peselu to zwróć prawdę
                if (connection.SelectCount($"SELECT COUNT(*) FROM pacjenci WHERE pesel=@pesel", parameters) > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else
            {
                // zwroc falsz i problem z polaczeniem jesli nie udalo sie otworzyc polaczenia
                MessageBox.Show("Błąd z połaczeniem!");
                DialogResult = DialogResult.Abort;
                return false;
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
                if (Position == Position.pacjent) { Console.WriteLine("Logowanie na pacjenta udane!"); }
                else { Console.WriteLine("Logowanie na lekarza udane!"); }
            }
            // jesli jednak nie jest w bazie to sprawdz czy pesel jest w bazie
            else
            {
                if (DialogResult != DialogResult.Abort)
                {
                    // jesli jednak peselu nie ma w bazie, to odpal rejestrację
                    if (!PeselExistsInDatabase(textBoxPesel.Text))
                    {
                        Patient = new Patient(-1, "", "", double.Parse(textBoxPesel.Text), Sexs.kobieta, DateTime.Now, "", "");
                        DialogResult = DialogResult.No;
                    }
                    if (DialogResult != DialogResult.No) { MessageBox.Show("Błędne dane!"); }
                }
            }
        }
        #endregion
    }
}
