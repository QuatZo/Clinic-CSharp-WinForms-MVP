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
    public partial class RegisterAppointmentPanel : UserControl, IRegisterAppointmentPanelView
    {
        #region Properties
        public List<string> Specializations
        {
            set
            {
                if(comboBoxSpecialization.Items.Count > 0) { comboBoxSpecialization.Items.Clear(); }
                foreach (var spec in value)
                {
                    comboBoxSpecialization.Items.Add(spec);
                }
            }
        }
        public string Specialization
        {
            get
            {
                try
                {
                    return comboBoxSpecialization.SelectedItem.ToString();
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
        }

        public List<string> Doctors
        {
            set
            {
                if (comboBoxDoctor.Items.Count > 0) { comboBoxDoctor.Items.Clear(); }
                foreach (var doc in value)
                {
                    comboBoxDoctor.Items.Add(doc);
                }
            }
        }
        public string Doctor
        {
            get
            {
                try
                {
                    return comboBoxDoctor.SelectedItem.ToString().Split()[0];
                }
                catch (NullReferenceException)
                {
                    return "";
                }
            }
        }

        public string Content
        {
            get
            {
                return textBoxContent.Text;
            }
        }
        public DateTime AppointmentDate
        {
            get
            {
                return dateTimePickerAppointment.Value;
            }
            set
            {
                dateTimePickerAppointment.Value = value;
            }
        }
        public string Hour
        {
            set
            {
                textBoxHours.Text = value;
            }
        }

        public bool DoctorActive
        {
            get
            {
                return comboBoxDoctor.Enabled;
            }
            set
            {
                comboBoxDoctor.Enabled = value;
            }
        }
        #endregion

        #region Events
        public event Action SpecializationChosen;
        public event Action DoctorChosen;

        public event Action RegisterButtonClicked;

        public event Action AppointmentDateChanged;
        #endregion

        public RegisterAppointmentPanel()
        {
            InitializeComponent();
        }

        #region Methods
        private void comboBoxSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpecializationChosen?.Invoke();
        }

        private void comboBoxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoctorChosen?.Invoke();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterButtonClicked?.Invoke();
        }

        private void textBoxSpecializationID_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDoctorID_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterAppointmentPanel_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePickerAppointment_ValueChanged(object sender, EventArgs e)
        {
            AppointmentDateChanged?.Invoke();
        }
        #endregion
    }
}
