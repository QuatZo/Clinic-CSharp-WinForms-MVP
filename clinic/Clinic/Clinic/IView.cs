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
        string title { set; }
 
        // widoki
        IEditPanelView EditView { get; }
        IMenuPanelView MenuView { get; }
        IAppointmentsPanelView AppointmentsView { get; }

        // metody jako parametry (zmiana widocznosci okien, tekst)
        bool EditActive { get; set; }
        bool MenuActive { get; set; }
        bool AppointmentsActive { get; set; }
        string WelcomeLabel { get; set; }
        #endregion

        // eventy
        #region Events
        event Action FormLoaded;
        #endregion

        void ExitForm();
    }
}
