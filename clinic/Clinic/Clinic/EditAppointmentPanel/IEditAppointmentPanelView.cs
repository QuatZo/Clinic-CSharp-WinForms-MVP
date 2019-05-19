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
        string Content { get; set; }
        List<string> Prescription { get; set; }
        #endregion
    }
}
