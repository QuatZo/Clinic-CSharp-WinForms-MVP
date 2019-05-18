using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class EditAppointmentPanelPresenter
    {
        IEditAppointmentPanelView view;
        Model model;

        public EditAppointmentPanelPresenter(IEditAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
