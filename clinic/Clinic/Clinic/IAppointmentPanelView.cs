﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IAppointmentPanelView
    {
        #region Properties
        List<string> FullfilFields { set; }
        #endregion

        #region Events

        #endregion
    }
}
