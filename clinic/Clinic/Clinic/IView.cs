using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    interface IView
    {
        #region Properties
        // tytul formy
        string Title { set; }

        // widoki
        IEditPanelView EditView { get; }
        IMenuPanelView MenuView { get; }
        IAppointmentsPanelView AppointmentsView { get; }
        IAppointmentPanelView AppointmentView { get; }
        IRegisterAppointmentPanelView RegisterAppointmentView { get; }
        IEditAppointmentPanelView EditAppointmentView { get; }
        IEditAppointmentSearchPanelView EditAppointmentSearchView { get; }

        // metody jako parametry (zmiana widocznosci okien, tekst)
        bool EditActive { get; set; }
        bool MenuActive { get; set; }
        bool AppointmentsActive { get; set; }
        bool AppointmentActive { get; set; }
        bool RegisterAppointmentActive { get; set; }
        bool EditAppointmentActive { get; set; }
        bool EditAppointmentSearchActive { get; set; }
        string WelcomeLabel { get; set; }

        List<Appointment> Appointments { get; set; }
        #endregion

        #region Events
        event Action FormLoaded;
        #endregion

        #region Methods
        void ExitForm();
        void SetView();
        #endregion
    }
}
