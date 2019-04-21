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
        EditPanelPresenter EditPresenter;

        // konstruktor
        public Presenter(IView view, Model model){
            this.view = view;
            this.model = model;

            //prezenter = konstruktor prezentera, np.
            LoginPresenter = new LoginPanelPresenter(view.LoginView, model);
            EditPresenter = new EditPanelPresenter(view.EditView, model);

            this.view.LoginView.LoginButtonClicked += LoginView_LoginButtonClicked;
            this.view.EditPanelVisibilityChanged += View_EditPanelVisibilityChanged;
            //eventy
        }

        private void LoginView_LoginButtonClicked()
        {
            if (model.IsInDatabase(view.LoginView.CurrentPesel, view.LoginView.CurrentSurname, view.LoginView.CurrentID))
            {
                view.LoginActive = false;
                view.EditActive = true;

                Console.WriteLine("PESEL: " + view.LoginView.CurrentPesel + "\n" +
                    "Nazwisko: " + view.LoginView.CurrentSurname + "\n" +
                    "ID: " + view.LoginView.CurrentID);
                // tutaj bedzie zapytanie do bazy
            }
        }
        private void View_EditPanelVisibilityChanged()
        {
            string[] user = model.GetUserInfo(view.LoginView.CurrentPesel);
            view.EditView.Address = user[0];
            view.EditView.Phone = user[1];
        }

    }
}
