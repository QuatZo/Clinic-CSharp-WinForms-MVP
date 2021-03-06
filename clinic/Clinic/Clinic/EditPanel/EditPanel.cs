﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class EditPanel : UserControl, IEditPanelView
    {
        #region Properties
        // parametry ustawiajace widoczność pól wspólnych, pacjenta i doktora
        public bool SharedFields
        {
            get
            {
                return textBoxID.Visible && textBoxName.Visible && textBoxSurname.Visible && textBoxPESEL.Visible && textBoxPhoneNumber.Visible;
            }
            set
            {
                textBoxID.Visible = value;
                textBoxName.Visible = value;
                textBoxSurname.Visible = value;
                textBoxPESEL.Visible = value;
                textBoxPhoneNumber.Visible = value;
            }
        }
        public bool PatientFields
        {
            get
            {
                return comboBoxSex.Visible && dateTimePickerBirthDay.Visible && textBoxAddress.Visible;
            }
            set
            {
                comboBoxSex.Visible = value;
                dateTimePickerBirthDay.Visible = value;
                textBoxAddress.Visible = value;
                label8.Visible = value;
                label9.Visible = value;
                label10.Visible = value;
            }
        }
        public bool DoctorFields
        {
            get
            {
                return textBoxRoom.Visible && comboBoxHours.Visible;
            }
            set
            {
                textBoxRoom.Visible = value;
                comboBoxHours.Visible = value;
                label7.Visible = value;
                label6.Visible = value;
            }
        }

        // wspólne pola
        public int ID
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
        public string FirstName
        {
            get
            {
                return textBoxName.Text;
            }
            set
            {
                textBoxName.Text = value;
            }
        }
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
                return double.Parse(textBoxPESEL.Text);
            }
            set
            {
                textBoxPESEL.Text = value.ToString();
            }
        }
        public string PhoneNumber
        {
            get
            {
                return textBoxPhoneNumber.Text;
            }
            set
            {
                textBoxPhoneNumber.Text = value;
            }
        }

        // pola pacjenta
        public string Sex
        {
            get
            {
                return comboBoxSex.SelectedItem.ToString();
            }
            set
            {
                comboBoxSex.SelectedItem = value;
            }
        }
        public DateTime BirthDay
        {
            get
            {
                return dateTimePickerBirthDay.Value;
            }
            set
            {
                dateTimePickerBirthDay.Value = value;
            }
        }
        public string Address
        {
            get
            {
                return textBoxAddress.Text;
            }
            set
            {
                textBoxAddress.Text = value;
            }
        }

        // pola doktora
        public int Room
        {
            get
            {
                return int.Parse(textBoxRoom.Text);
            }
            set
            {
                textBoxRoom.Text = value.ToString();
            }
        }
        public string Hour
        {
            get
            {
                return comboBoxHours.SelectedItem.ToString();
            }
            set
            {
                comboBoxHours.SelectedItem = value;
            }
        }
        #endregion

        #region Events
        // zapis danych
        public event Action SaveButtonClicked;
        #endregion

        public EditPanel()
        {
            InitializeComponent();
        }

        #region Methods
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
                SaveButtonClicked();
        }

        // metoda uzupełniająca dane pacjenta
        public void FullfilPatientFields()
        {
            try
            {
                ID = FormLogin.Instance.Patient.Id;
                FirstName = FormLogin.Instance.Patient.Name;
                Surname = FormLogin.Instance.Patient.Surname;
                Pesel = FormLogin.Instance.Patient.Pesel;
                PhoneNumber = FormLogin.Instance.Patient.PhoneNumber;
                Sex = FormLogin.Instance.Patient.Sex.ToString();
                BirthDay = FormLogin.Instance.Patient.BirthDay;
                Address = FormLogin.Instance.Patient.Address;
            }
            catch (NullReferenceException) { }
        }

        // metoda uzupełniająca dane lekarza
        public void FullfilDoctorFields()
        {
            try
            {
                ID = FormLogin.Instance.Doctor.Id;
                FirstName = FormLogin.Instance.Doctor.Name;
                Surname = FormLogin.Instance.Doctor.Surname;
                Pesel = FormLogin.Instance.Doctor.Pesel;
                PhoneNumber = FormLogin.Instance.Doctor.PhoneNumber;
                Hour = FormLogin.Instance.Doctor.Hour.ToString();
                Room = FormLogin.Instance.Doctor.Room;
            }
            catch (NullReferenceException) { }
        }
        #endregion
    }
}
