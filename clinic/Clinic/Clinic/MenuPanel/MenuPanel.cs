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
        public bool RegisterAppointmentButtonVisibility
        {
            get
            {
                return buttonRegisterAppointment.Visible;
            }
            set
            {
                buttonRegisterAppointment.Visible = value;
            }
        }
        public bool EditAppointmentButtonVisibility
        {
            get
            {
                return buttonEditAppointment.Visible;
            }
            set
            {
                buttonEditAppointment.Visible = value;
            }
        }
        #endregion

        #region Events
        public event Action LogOut; // wyjscie z programu
        public event Action EditButtonClicked; // panel edycji
        public event Action AppointmentsButtonClicked; // panel wizyt
        public event Action RegisterAppointmentButtonClicked; // panel rejestracji wizyty
        public event Action EditAppointmentSearchButtonClicked; // panel wyszukiwania wizyty do edycji
        #endregion

        public MenuPanel()
        {
            InitializeComponent();
        }

        #region Methods
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            LogOut?.Invoke();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditButtonClicked?.Invoke();
        }

        private void buttonAppointments_Click(object sender, EventArgs e)
        {
            AppointmentsButtonClicked?.Invoke();
        }

        private void buttonRegisterAppointment_Click(object sender, EventArgs e)
        {
            RegisterAppointmentButtonClicked?.Invoke();
        }

        private void buttonEditAppointment_Click(object sender, EventArgs e)
        {
            EditAppointmentSearchButtonClicked?.Invoke();
        }
        #endregion
    }
}
