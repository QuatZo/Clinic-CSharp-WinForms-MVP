using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    class MenuPanelPresenter
    {
        IMenuPanelView view;
        Model model;

        public MenuPanelPresenter(IMenuPanelView view, Model model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
