using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class AppointmentsPanelPresenter
    {
        #region Classes
        IAppointmentsPanelView view;
        Model model;
        #endregion

        public AppointmentsPanelPresenter(IAppointmentsPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }

    }
}
