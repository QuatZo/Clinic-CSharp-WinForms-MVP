using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class AppointmentsPanelPresenter
    {
        IAppointmentsPanelView view;
        Model model;

        public AppointmentsPanelPresenter(IAppointmentsPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }

    }
}
