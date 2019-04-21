using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    class Presenter
    {
        Model model = new Model();
        IView view = new Form1();

        // wszystkie prezentery, np.
        LoginPanelPresenter LoginPresenter;
        // LoginPanelPresenter loginPresenter;

        // konstruktor
        public Presenter(IView view, Model model){
            this.view = view;
            this.model = model;

            //prezenter = konstruktor prezentera, np.
            LoginPresenter = new LoginPanelPresenter(view.LoginView, model);

            //eventy
        }
    }
}
