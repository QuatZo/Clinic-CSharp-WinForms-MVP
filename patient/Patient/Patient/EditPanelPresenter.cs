using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    class EditPanelPresenter
    {
        IEditPanelView view;
        Model model;

        public EditPanelPresenter(IEditPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

        }
    }
}
