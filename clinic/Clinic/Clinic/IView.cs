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

        // zmiana widocznosci okien
        bool EditActive { get; set; }
        bool MenuActive { get; set; }
        bool AppointmentsActive { get; set; }
        bool AppointmentActive { get; set; }
        bool RegisterAppointmentActive { get; set; }
        bool EditAppointmentActive { get; set; }
        bool EditAppointmentSearchActive { get; set; }

        // zmiana tekstu "Witaj, [...]"
        string WelcomeLabel { get; set; }

        // Wizyty
        List<Appointment> Appointments { get; set; }
        #endregion

        #region Events
        event Action FormLoaded; // ładowanie formy, podpięte pod przycisk Edycji z Menu (do tego samego prowadzą)
        #endregion

        #region Methods
        void ExitForm();
        void SetView();
        #endregion
    }
}
