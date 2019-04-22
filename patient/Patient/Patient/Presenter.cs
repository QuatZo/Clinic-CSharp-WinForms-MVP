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
        MenuPanelPresenter MenuPresenter;

        // konstruktor
        public Presenter(IView view, Model model){
            this.view = view;
            this.model = model;

            // prezenter = konstruktor prezentera, np.
            LoginPresenter = new LoginPanelPresenter(view.LoginView, model);
            EditPresenter = new EditPanelPresenter(view.EditView, model);
            MenuPresenter = new MenuPanelPresenter(view.MenuView, model);

            // eventy
            this.view.LoginView.LoginButtonClicked += LoginView_LoginButtonClicked;
            this.view.LoginScreenPopup += View_LoginScreenPopup;
            this.view.EditPanelVisibilityChanged += View_EditPanelVisibilityChanged;
            // niech to zawsze bedzie jako ostatnie
            this.view.MenuView.LogOut += MenuView_LogOut;
        }

        private void View_LoginScreenPopup()
        {
            if(!view.LoginActive)
                view.LoginActive = true;
            if(view.EditActive)
                view.EditActive = false;
            if(view.MenuActive)
                view.MenuActive = false;
        }

        private void LoginView_LoginButtonClicked()
        {
            if (model.IsInDatabase(view.LoginView.CurrentPesel, view.LoginView.CurrentSurname, view.LoginView.CurrentID))
            {
                if (view.LoginActive)
                    view.LoginActive = false;
                if (!view.EditActive)
                    view.EditActive = true;
                if (!view.MenuActive)
                    view.MenuActive = true;

                // nizej bedzie imie pobrane z bazy, w ramach testow jest wpisane na sztywno nazwisko
                view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", "Witaj, " + view.LoginView.CurrentSurname);
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
        // niech to zawsze bedzie ostatnie
        private void MenuView_LogOut()
        {
            if (!view.LoginActive)
                view.LoginActive = true;
            if (view.EditActive)
                view.EditActive = false;
            if (view.MenuActive)
                view.MenuActive = false;

            view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj, " + view.LoginView.CurrentSurname, "Witaj");

            Console.WriteLine("Użytkownik 'został wylogowany'");
        }

    }
}
