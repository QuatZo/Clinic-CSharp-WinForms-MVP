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
        private string FirstName
        {
            get
            {
                return textBoxName.Text;
            }
        }
        private string Surname
        {
            get
            {
                return textBoxSurname.Text;
            }
        }
        private string PESEL
        {
            get
            {
                return textBoxPESEL.Text;
            }
            set
            {
                textBoxPESEL.Text = value;
            }
        }
        private string PhoneNumber
        {
            get
            {
                return textBoxPhoneNumber.Text;
            }
        }
        private int SexID
        {
            get
            {
                return comboBoxSex.SelectedIndex;
            }
        }
        private DateTime DateTimeBirthDay
        {
            get
            {
                return dateTimePickerBirthDay.Value;
            }
        }
        private string Address
        {
            get
            {
                return textBoxAddress.Text;
            }
        }

        public FormRegister()
        {
            InitializeComponent();
        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            PESEL = FormLogin.pesel.ToString();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                using (var connection = new DatabaseConnection())
                {
                    // jesli idzie otworzyc polaczenie
                    if (connection.Open())
                    {
                        if (connection.InsertInfo($"INSERT INTO pacjenci(imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon) VALUES(\"{FirstName}\", \"{Surname}\", {PESEL}, {SexID}, \"{DateTimeBirthDay.ToString("yyyy-MM-dd")}\", \"{Address}\", {PhoneNumber})")){
                            connection.GetPatientInfo($"SELECT * FROM pacjenci WHERE pesel={PESEL}");
                            MessageBox.Show($"Rejestracja zakończona powodzeniem. Twoje ID do logowania to: {Patient.Instance.Id}");
                            Close();
                        }
                        else
                        {
                            ShowError("Ups! Coś poszło nie tak!");
                        }
                    }
                    else
                    {
                        // zwroc problem z polaczeniem jesli nie udalo sie otworzyc polaczenia
                        MessageBox.Show("Błąd z połaczeniem!");
                    }
                }
            }
        }

        private bool ValidateFields()
        {
            try
            {
                double.Parse(PhoneNumber);
            }
            catch (FormatException)
            {
                ShowError("Numer telefonu powinien byc wartosciowa liczbowa!");
                return false;
            }

            if (PhoneNumber.Length > 9)
            {
                ShowError("Numer telefonu jest za długi!");
                return false;
            }

            if (DateTimeBirthDay > DateTime.Now)
            {
                ShowError("Data urodzin nie może być późniejsza od teraźniejszości!");
                return false;
            }

            if(SexID == -1)
            {
                ShowError("Wybierz płeć!");
                return false;
            }

            return true;
        }

        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
