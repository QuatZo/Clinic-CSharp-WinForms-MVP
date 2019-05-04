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

        // metody jako parametry (zmiana widocznosci okien, tekst)
        bool EditActive { get; set; }
        bool MenuActive { get; set; }
        bool AppointmentsActive { get; set; }
        bool AppointmentActive { get; set; }
        bool RegisterAppointmentActive { get; set; }
        string WelcomeLabel { get; set; }
        #endregion

        // eventy
        #region Events
        event Action FormLoaded;
        #endregion

        void ExitForm();
    }
}
