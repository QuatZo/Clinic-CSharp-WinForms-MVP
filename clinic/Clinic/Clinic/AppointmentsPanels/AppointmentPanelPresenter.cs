using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class AppointmentPanelPresenter
    {
        #region Classes
        IAppointmentPanelView view;
        Model model;
        #endregion

        public AppointmentPanelPresenter(IAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
