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

            this.view.LoginView.LoginButtonClicked += LoginView_LoginButtonClicked;
            //eventy
        }

        private void LoginView_LoginButtonClicked()
        {
            if (model.IsInDatabase(view.LoginView.CurrentPesel, view.LoginView.CurrentSurname, view.LoginView.CurrentID))
            {
                Console.WriteLine("PESEL: " + view.LoginView.CurrentPesel + "\n" +
                    "Nazwisko: " + view.LoginView.CurrentSurname + "\n" +
                    "ID: " + view.LoginView.CurrentID);
                // tutaj bedzie zapytanie do bazy
            }
        }
    }
}
