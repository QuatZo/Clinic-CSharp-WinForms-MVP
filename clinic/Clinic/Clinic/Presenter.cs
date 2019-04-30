using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Presenter
    {
        Model model = new Model();
        IView view = new Form1();

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

            // prezenter = konstruktor prezentera
            EditPresenter = new EditPanelPresenter(view.EditView, model);
            MenuPresenter = new MenuPanelPresenter(view.MenuView, model);

            // eventy
            this.view.FormLoaded += View_FormLoaded;
            this.view.MenuView.EditPanelClicked += View_FormLoaded;
            this.view.MenuView.LogOut += MenuView_LogOut;
        }

        private void MenuView_LogOut()
        {
            view.ExitForm();
        }

        private void View_FormLoaded()
        {
            view.title = FormLogin.position.ToString();

            // tutaj beda wszystkie okna, upewnienie sie, ze na pewno dobre wyswietli
            if (!view.EditActive)
                view.EditActive = true;
            if (!view.MenuActive)
                view.MenuActive = true;

            if(!view.WelcomeLabel.Contains(FormLogin.position.ToString()))
                view.WelcomeLabel = view.WelcomeLabel.Replace("Panel", "Panel " + FormLogin.position + "a");

            if (!view.EditView.SharedFields)
                view.EditView.SharedFields = true;

            if (FormLogin.position == Position.pacjent)
            {
                // metoda w modelu, ktora pobierze pacjenta
                pacjent = model.GetPatientInfo(FormLogin.pesel.ToString());

                lekarz = null;

                if (!view.WelcomeLabel.Contains($"Witaj, {pacjent.Name} {pacjent.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {pacjent.Name} {pacjent.Surname}");

                if (!view.EditView.PatientFields)
                    view.EditView.PatientFields = true;
                if (view.EditView.DoctorFields)
                    view.EditView.DoctorFields = false;

                view.EditView.ID = pacjent.Id;
                view.EditView.FirstName = pacjent.Name;
                view.EditView.Surname = pacjent.Surname;
                view.EditView.Pesel = pacjent.Pesel;
                view.EditView.PhoneNumber = pacjent.PhoneNumber;
                view.EditView.Sex = pacjent.Sex.ToString();
                view.EditView.BirthDay = pacjent.BirthDay;
                view.EditView.Address = pacjent.Address;
            }
            else
            {
                // metoda w modelu, ktora pobierze lekarza
                pacjent = null;
                lekarz = model.GetDoctorInfo(FormLogin.pesel.ToString());

                if (!view.WelcomeLabel.Contains($"Witaj, {lekarz.Name} {lekarz.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {lekarz.Name} {lekarz.Surname}");

                if (view.EditView.PatientFields)
                    view.EditView.PatientFields = false;
                if (!view.EditView.DoctorFields)
                    view.EditView.DoctorFields = true;
                view.EditView.ID = lekarz.Id;
                view.EditView.FirstName = lekarz.Name;
                view.EditView.Surname = lekarz.Surname;
                view.EditView.Pesel = lekarz.Pesel;
                view.EditView.PhoneNumber = lekarz.PhoneNumber;
                view.EditView.Hour = lekarz.Hour.ToString();
                view.EditView.Room = lekarz.Room;
            }
        }
    }
}
