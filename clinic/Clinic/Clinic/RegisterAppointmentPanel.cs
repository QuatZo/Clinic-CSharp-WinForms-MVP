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
        public List<string> SetSpecializationsList
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
        public string GetSpecialization
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

        public List<string> SetDoctorsList
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
        public string GetDoctor
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

        public string HoursField
        {
            set
            {
                textBoxHours.Text = value;
            }
        }
        public List<string> Fields
        {
            get
            {
                List<string> fields = new List<string>();

                fields.Add(FormLogin.id.ToString());
                fields.Add(GetDoctor);
                fields.Add(textBoxContent.Text);
                fields.Add(dateTimePickerAppointment.Value.ToString());

                return fields;
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
        #endregion

        public RegisterAppointmentPanel()
        {
            InitializeComponent();
        }

        private void comboBoxSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SpecializationChosen != null)
                SpecializationChosen();
        }

        private void comboBoxDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoctorChosen != null)
                DoctorChosen();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (RegisterButtonClicked != null)
                RegisterButtonClicked();
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
    }
}
