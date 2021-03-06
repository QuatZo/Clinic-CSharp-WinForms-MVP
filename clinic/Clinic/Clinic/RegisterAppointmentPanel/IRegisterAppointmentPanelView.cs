﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IRegisterAppointmentPanelView
    {
        #region Properties
        List<string> Specializations { set; }
        string Specialization { get; }
        List<string> Doctors { set; }
        string Doctor { get; }
        string Hour { get;  set; }
        string Content { get; }
        DateTime AppointmentDate { get; set; }
        bool DoctorActive { get; set; }
        #endregion

        #region Events
        event Action SpecializationChosen;
        event Action DoctorChosen;
        event Action RegisterButtonClicked;
        event Action AppointmentDateChanged;
        #endregion
    }
}
