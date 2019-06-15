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
    public partial class FormRegister : Form
    {
        #region Singleton
        private static FormRegister instance;

        public static FormRegister Instance
        {
            get
            {
                return instance ?? (instance = new FormRegister());
            }
        }
        #endregion

        #region Fields
        private readonly DatabaseConnection connection = DatabaseConnection.Instance;
        private readonly FormLogin formLogin = FormLogin.Instance;
        #endregion

        private FormRegister()
        {
            InitializeComponent();
        }

        #region Methods
        
        private void FormRegister_Load(object sender, EventArgs e)
        {
            textBoxPESEL.Text = formLogin.Patient.Pesel.ToString();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                // jesli idzie otworzyc polaczenie
                if (connection.Open())
                {
                    Dictionary<string, string> registerParameters = new Dictionary<string, string>()
                    {
                        {"@firstname", textBoxName.Text },
                        {"@surname", textBoxSurname.Text },
                        {"@pesel", textBoxPESEL.Text },
                        {"@sex", (comboBoxSex.SelectedIndex + 1).ToString() },
                        {"@birthday", dateTimePickerBirthDay.Value.ToString("yyyy-MM-dd")},
                        {"@address", textBoxAddress.Text },
                        {"@phone", textBoxPhoneNumber.Text },
                    };

                    if (connection.InsertInfo($"INSERT INTO pacjenci(imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon) VALUES(@firstname, @surname, @pesel, @sex, @birthday, @address, @phone)", registerParameters)){
                        Dictionary<string, string> infoParameters = new Dictionary<string, string>()
                        {
                            {"@pesel", textBoxPESEL.Text }
                        };

                        Patient newPatient = connection.GetPatientInfo($"SELECT * FROM pacjenci WHERE pesel=@pesel", infoParameters);
                        formLogin.Pesel = newPatient.Pesel;
                        formLogin.Surname = newPatient.Surname;
                        formLogin.Id = newPatient.Id;
                        MessageBox.Show($"Rejestracja zakończona powodzeniem. Twoje ID do logowania to: {newPatient.Id}");
                        connection.Close();
                        Close();
                    }
                    else
                    {
                        ShowError("Ups! Coś poszło nie tak!");
                        connection.Close();
                    }
                }
                else
                {
                    // zwroc problem z polaczeniem jesli nie udalo sie otworzyc polaczenia
                    MessageBox.Show("Błąd z połaczeniem!");
                }
            }
        }

        // sprawdź pola, czy są poprawne
        private bool ValidateFields()
        {
            try
            {
                double.Parse(textBoxPhoneNumber.Text);
            }
            catch (FormatException)
            {
                ShowError("Numer telefonu powinien byc wartosciowa liczbowa!");
                return false;
            }

            if (textBoxPhoneNumber.Text.Length > 9)
            {
                ShowError("Numer telefonu jest za długi!");
                return false;
            }

            if (dateTimePickerBirthDay.Value > DateTime.Now)
            {
                ShowError("Data urodzin nie może być późniejsza od teraźniejszości!");
                return false;
            }

            if(comboBoxSex.SelectedIndex == -1)
            {
                ShowError("Wybierz płeć!");
                return false;
            }

            return true;
        }

        // metodą wyświetlająca błąd (do walidacji, mniej pisania)
        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxAddress.Text = "";
            textBoxPESEL.Text = "";
            textBoxPhoneNumber.Text = "";
            dateTimePickerBirthDay.Value = DateTime.Now;
        }
    }
}
