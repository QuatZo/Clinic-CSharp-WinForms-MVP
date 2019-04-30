using System;
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
        // Parametry ustawiajace widoczność pól wspólnych, pacjenta i doktora
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
            }
        }

        // Wspólne pola
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

        // Pola pacjenta
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

        // Pola doktora
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
        // Zapis danych
        public event Action SaveButtonClicked;
        #endregion

        public EditPanel()
        {
            InitializeComponent();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
                SaveButtonClicked();
        }
    }
}
