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
    public partial class AppointmentPanel : UserControl, IAppointmentPanelView
    {
        #region Properties
        public Appointment FullfilFields
        {
            set
            {
                textBoxPatientPesel.Text = value.Patient.Pesel.ToString();
                textBoxPatient.Text = value.Patient.Name + " " + value.Patient.Surname;
                textBoxDoctor.Text = value.Doctor.Name + " " + value.Doctor.Surname;
                textBoxContent.Text = value.Content;
                dateTimePickerAppointment.Value = value.Date;

                foreach(var medicine in value.Medicines)
                {
                    listBoxPrescription.Items.Add($"{medicine.ID} <=> {medicine.Name} <=> {medicine.Dose}");
                }
            }
        }
        #endregion

        public AppointmentPanel()
        {
            InitializeComponent();
        }

        #region Methods
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
