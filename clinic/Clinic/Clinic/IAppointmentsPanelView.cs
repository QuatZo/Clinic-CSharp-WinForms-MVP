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
        string ChosenAppointment { get; }
        #endregion

        #region Events

        #endregion
    }
}
