using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Presenter
    {
        Model model;
        IView view;

        // klasy, bedziemy wybierac jedna
        Patient pacjent;
        Doctor lekarz;

        // wszystkie prezentery, np.
        EditPanelPresenter EditPresenter;
        MenuPanelPresenter MenuPresenter;

        // konstruktor
        public Presenter(IView view, Model model){
            this.view = view;
            this.model = model;

            // prezenter = konstruktor prezentera, np.
            EditPresenter = new EditPanelPresenter(view.EditView, model);
            MenuPresenter = new MenuPanelPresenter(view.MenuView, model);

            // eventy
            this.view.FormLoaded += View_FormLoaded;
            //this.view.EditPanelVisibilityChanged += View_EditPanelVisibilityChanged;

        }

        private void View_FormLoaded()
        {
            // tutaj beda wszystkie okna, upewnienie sie, ze na pewno dobre wyswietli
            if (!view.EditActive)
                view.EditActive = true;
            if (!view.MenuActive)
                view.MenuActive = true;

            if(view.Position == "pacjent")
            {
                // metoda w modelu, ktora pobierze pacjenta
                //pacjent = [...];
                //lekarz = null;
            }
            else
            {
                // metoda w modelu, ktora pobierze lekarza
                //pacjent = null;
                //lekarz = [...];
            }

            view.WelcomeLabel = view.WelcomeLabel.Replace("Panel", "Panel " + view.Position + "a").Replace("Witaj", "Witaj, " + "TU BEDZIE IMIE + NAZWISKO!");

        }

        //private void LoginView_LoginButtonClicked()
        //{
        //    if (!view.EditActive)
        //        view.EditActive = true;
        //    if (!view.MenuActive)
        //        view.MenuActive = true;

        //    // nizej bedzie imie pobrane z bazy, w ramach testow jest wpisane na sztywno nazwisko
        //    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", "Witaj, " + view.LoginView.CurrentSurname);
        //    Console.WriteLine("PESEL: " + view.LoginView.CurrentPesel + "\n" +
        //        "Nazwisko: " + view.LoginView.CurrentSurname + "\n" +
        //        "ID: " + view.LoginView.CurrentID);
        //    // tutaj bedzie zapytanie do bazy
        //}

        //private void View_EditPanelVisibilityChanged()
        //{
        //    string[] user = model.GetUserInfo(view.LoginView.CurrentPesel);
        //    view.EditView.Address = user[0];
        //    view.EditView.Phone = user[1];
        //}
    }
}
