using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    class LoginPanelPresenter
    {
        ILoginPanelView view;
        Model model;

        public LoginPanelPresenter(ILoginPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.PeselChanged += View_PeselChanged;
        }

        private void View_PeselChanged()
        {
            if (!model.CheckPesel(view.CurrentPesel))
            {
                Console.WriteLine(view.CurrentPesel);
            }
            else {
                Console.WriteLine("Dobry PESEL!");
            }
            
        }
    }
}
