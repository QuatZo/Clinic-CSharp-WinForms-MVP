using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IEditAppointmentPanelView
    {
        #region Properties
        int AppointmentID { get; set; }
        string Content { get; set; }
        List<string> Prescription { get; set; }
        #endregion

        #region Events
        event Action AddRowButtonClicked;
        event Action DeleteRowButtonClicked;
        event Action SaveAppointmentButtonClicked;
        #endregion

        #region Methods
        void FullfilFields(Appointment appointment);
        #endregion
    }
}
