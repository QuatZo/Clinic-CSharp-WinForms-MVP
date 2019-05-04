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
    public partial class MenuPanel : UserControl, IMenuPanelView
    {
        #region Properties

        #endregion

        #region Events
        public event Action LogOut; // wyjscie z programu
        public event Action EditButtonClicked; // panel edycji
        public event Action AppointmentsButtonClicked; // panel wizyt
        public event Action RegisterAppointmentButtonClicked; // panel rejestracji wizyty
        #endregion

        public MenuPanel()
        {
            InitializeComponent();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (LogOut != null)
                LogOut();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (EditButtonClicked != null)
                EditButtonClicked();
        }

        private void buttonAppointments_Click(object sender, EventArgs e)
        {
            if (AppointmentsButtonClicked != null)
                AppointmentsButtonClicked();
        }

        private void buttonRegisterAppointment_Click(object sender, EventArgs e)
        {
            if (RegisterAppointmentButtonClicked != null)
                RegisterAppointmentButtonClicked();
        }
    }
}
