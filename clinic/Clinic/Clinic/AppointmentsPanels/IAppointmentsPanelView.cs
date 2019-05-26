using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IAppointmentsPanelView
    {
        #region Properties
        List<string> Content { set; }
        int ChosenAppointment { get; }
        #endregion

        #region Events
        event Action ChosenAppointmentClick;
        #endregion
    }
}
