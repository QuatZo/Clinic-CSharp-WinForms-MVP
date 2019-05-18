using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IEditAppointmentSearchPanelView
    {
        #region Properties
        string PeselPatient { get; set; }
        DateTime DateTimeAppointment { get; }
        #endregion

        #region Events
        event Action SearchAppointmentButtonClicked;
        event Action PatientPeselChanged;
        #endregion
    }
}
