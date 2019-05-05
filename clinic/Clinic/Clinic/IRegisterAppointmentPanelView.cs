using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IRegisterAppointmentPanelView
    {
        #region Properties
        List<string> SetSpecializationsList { set; }
        string GetSpecialization { get; }
        List<string> SetDoctorsList { set; }
        string GetDoctor { get; }
        string HoursField { set; }
        List<string> Fields { get; }

        bool DoctorActive { get; set; }
        #endregion

        #region Events
        event Action SpecializationChosen;
        event Action DoctorChosen;
        event Action RegisterButtonClicked;
        #endregion
    }
}
