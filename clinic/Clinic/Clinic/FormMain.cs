using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class FormMain : Form, IView
    {
        #region Properties
        // tytul okna
        public string Title
        {
            set
            {
                Text = $"Panel {value}a";
            }
        }

        // widoki
        public IEditPanelView EditView
        {
            get
            {
                return editPanel1;
            }
        }
        public IMenuPanelView MenuView
        {
            get
            {
                return menuPanel1;
            }
        }
        public IAppointmentsPanelView AppointmentsView
        {
            get
            {
                return appointmentsPanel1;
            }
        }
        public IAppointmentPanelView AppointmentView
        {
            get
            {
                return appointmentPanel1;
            }
        }
        public IRegisterAppointmentPanelView RegisterAppointmentView
        {
            get
            {
                return registerAppointment1;
            }

        }
        public IEditAppointmentPanelView EditAppointmentView
        {
            get
            {
                return editAppointmentPanel1;
            }
        }
        public IEditAppointmentSearchPanelView EditAppointmentSearchView
        {
            get
            {
                return editAppointmentSearchPanel1;
            }
        }

        // zmiana widocznosci okien
        public bool EditActive
        {
            get
            {
                return editPanel1.Enabled && editPanel1.Visible;
            }
            set
            {
                editPanel1.Enabled = value;
                editPanel1.Visible = value;
            }
        }
        public bool MenuActive
        {
            get
            {
                return menuPanel1.Enabled && menuPanel1.Visible;
            }
            set
            {
                menuPanel1.Enabled = value;
                menuPanel1.Visible = value;
            }
        }
        public bool AppointmentsActive
        {
            get
            {
                return appointmentsPanel1.Enabled && appointmentsPanel1.Visible;
            }
            set
            {
                appointmentsPanel1.Enabled = value;
                appointmentsPanel1.Visible = value;
            }
        }
        public bool AppointmentActive
        {
            get
            {
                return appointmentPanel1.Enabled && appointmentPanel1.Visible;
            }
            set
            {
                appointmentPanel1.Enabled = value;
                appointmentPanel1.Visible = value;
            }
        }
        public bool RegisterAppointmentActive
        {
            get
            {
                return registerAppointment1.Enabled && registerAppointment1.Visible;
            }
            set
            {
                registerAppointment1.Enabled = value;
                registerAppointment1.Visible = value;
            }
        }
        public bool EditAppointmentActive
        {
            get
            {
                return editAppointmentPanel1.Enabled && editAppointmentPanel1.Visible;
            }
            set
            {
                editAppointmentPanel1.Enabled = value;
                editAppointmentPanel1.Visible = value;
            }
        }
        public bool EditAppointmentSearchActive
        {
            get
            {
                return editAppointmentSearchPanel1.Enabled && editAppointmentSearchPanel1.Visible;
            }
            set
            {
                editAppointmentSearchPanel1.Enabled = value;
                editAppointmentSearchPanel1.Visible = value;
            }
        }

        // zmiana tekstu "Witaj, [...]"
        public string WelcomeLabel
        {
            get
            {
                return labelInfo.Text;
            }
            set
            {
                labelInfo.Text = value;
            }
        }

        // Wizyty
        public List<Appointment> Appointments { get; set; }
        #endregion

        #region Events
        public event Action FormLoaded; // logowanie formy, podpisany jest pod to przycisk Edycji z menu
        #endregion

        public FormMain()
        {
            InitializeComponent();
        }

        #region Methods
        private void Form1_Load(object sender, EventArgs e)
        {
            FormLoaded?.Invoke();
        }

        public void ExitForm()
        {
            Close();
        }

        // wyłączanie wszystkich widoków, za wyjątkiem menu
        public void SetView()
        {
            if (!MenuActive) { MenuActive = true; }
            if (EditActive) { EditActive = false; }
            if (AppointmentActive) { AppointmentActive = false; }
            if (AppointmentsActive) { AppointmentsActive = false; }
            if (RegisterAppointmentActive) { RegisterAppointmentActive = false; }
            if (EditAppointmentActive) { EditAppointmentActive = false; }
            if (EditAppointmentSearchActive) { EditAppointmentSearchActive = false; }
        }
        #endregion

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
