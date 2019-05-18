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
    public partial class EditAppointmentSearchPanel : UserControl, IEditAppointmentSearchPanelView
    {
        public EditAppointmentSearchPanel()
        {
            InitializeComponent();
        }

        private void EditAppointmentSearchPanel_Load(object sender, EventArgs e)
        {

        }

        private void textBoxPatientPesel_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerAppointmentDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
