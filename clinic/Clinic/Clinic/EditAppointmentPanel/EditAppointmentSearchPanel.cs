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
        #region Properties
        public string PeselPatient
        {
            get
            {
                return textBoxPatientPesel.Text;
            }
            set
            {
                textBoxPatientPesel.Text = value;
            }
        }
        public DateTime DateTimeAppointment
        {
            get
            {
                return dateTimePickerAppointmentDate.Value;
            }
        }
        #endregion

        #region Events
        public event Action SearchAppointmentButtonClicked;
        public event Action PatientPeselChanged;
        #endregion

        public EditAppointmentSearchPanel()
        {
            InitializeComponent();
        }

        #region Methods
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchAppointmentButtonClicked?.Invoke();
        }

        private void textBoxPatientPesel_TextChanged(object sender, EventArgs e)
        {
            PatientPeselChanged?.Invoke();
        }
        #endregion
    }
}
