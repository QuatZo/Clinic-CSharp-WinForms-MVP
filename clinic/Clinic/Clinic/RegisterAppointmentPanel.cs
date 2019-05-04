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
                return comboBoxSpecialization.SelectedItem.ToString();
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
                return comboBoxDoctor.SelectedItem.ToString().Split()[0];
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

                fields.Add(comboBoxSpecialization.SelectedText);
                fields.Add(comboBoxDoctor.SelectedText);
                fields.Add(textBoxContent.Text);
                fields.Add(dateTimePickerAppointment.Value.ToString());
                fields.Add(textBoxHours.Text);

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
    }
}
