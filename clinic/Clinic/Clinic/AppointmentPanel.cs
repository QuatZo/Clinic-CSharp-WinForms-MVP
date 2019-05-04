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
        public List<string> FullfilFields
        {
            set
            {
                textBoxPatientPesel.Text = value[0];
                textBoxPatient.Text = value[1];
                textBoxDoctor.Text = value[2];
                textBoxContent.Text = value[3];
                dateTimePickerAppointment.Value = DateTime.Parse(value[4]);
                textBoxPrescription.Text = value[5];
            }
        }
        #endregion

        public AppointmentPanel()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
