using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class RegisterAppointmentPanelPresenter
    {
        IRegisterAppointmentPanelView view;
        Model model;

        public RegisterAppointmentPanelPresenter(IRegisterAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }

    }
}
