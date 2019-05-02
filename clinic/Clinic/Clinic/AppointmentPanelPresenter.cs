using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class AppointmentPanelPresenter
    {
        IAppointmentPanelView view;
        Model model;

        public AppointmentPanelPresenter(IAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
