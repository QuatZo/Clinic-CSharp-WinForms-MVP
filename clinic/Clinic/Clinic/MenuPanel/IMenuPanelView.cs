using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IMenuPanelView
    {
        #region Properties
        bool RegisterAppointmentButtonVisibility { get; set; }
        bool EditAppointmentButtonVisibility { get; set; }
        #endregion

        #region Events
        event Action LogOut; // zamkniecie programu
        event Action EditButtonClicked; // wejscie do panelu edycji
        event Action AppointmentsButtonClicked; // wejscie do panelu wizyt
        event Action RegisterAppointmentButtonClicked; // wejscie do panelu rejestracji wizyty
        event Action EditAppointmentSearchButtonClicked; // wejście do panelu edycji wizyty (wyszukiwarki)
        #endregion
    }
}
