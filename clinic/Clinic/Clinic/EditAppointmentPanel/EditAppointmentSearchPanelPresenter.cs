using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class EditAppointmentSearchPanelPresenter
    {
        IEditAppointmentSearchPanelView view;
        Model model;

        public EditAppointmentSearchPanelPresenter(IEditAppointmentSearchPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }

    }
}
