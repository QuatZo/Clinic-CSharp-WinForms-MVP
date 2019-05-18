using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    class Presenter
    {
        #region Classes
        Model model = new Model();
        IView view = new Form1();

        Patient pacjent;
        Doctor lekarz;
        #endregion

        #region Presenters
        readonly EditPanelPresenter EditPresenter;
        readonly MenuPanelPresenter MenuPresenter;
        readonly AppointmentsPanelPresenter AppointmentsPresenter;
        readonly AppointmentPanelPresenter AppointmentPresenter;
        readonly RegisterAppointmentPanelPresenter RegisterAppointmentPresenter;
        readonly EditAppointmentPanelPresenter EditAppointmentPresenter;
        readonly EditAppointmentSearchPanelPresenter EditAppointmentSearchPresenter;
        #endregion

        #region Methods
        public Presenter(IView view, Model model){
            this.view = view;
            this.model = model;

            // prezenter = konstruktor prezentera
            EditPresenter = new EditPanelPresenter(view.EditView, model);
            MenuPresenter = new MenuPanelPresenter(view.MenuView, model);
            AppointmentsPresenter = new AppointmentsPanelPresenter(view.AppointmentsView, model);
            AppointmentPresenter = new AppointmentPanelPresenter(view.AppointmentView, model);
            RegisterAppointmentPresenter = new RegisterAppointmentPanelPresenter(view.RegisterAppointmentView, model);
            EditAppointmentPresenter = new EditAppointmentPanelPresenter(view.EditAppointmentView, model);
            EditAppointmentSearchPresenter = new EditAppointmentSearchPanelPresenter(view.EditAppointmentSearchView, model);

            // eventy
            this.view.FormLoaded += MenuView_EditButtonClicked;

            this.view.MenuView.EditButtonClicked += MenuView_EditButtonClicked;
            this.view.MenuView.RegisterAppointmentButtonClicked += MenuView_RegisterAppointmentButtonClicked;
            this.view.MenuView.AppointmentsButtonClicked += MenuView_AppointmentsButtonClicked;
            this.view.MenuView.LogOut += MenuView_LogOut;
            this.view.MenuView.EditAppointmentSearchButtonClicked += MenuView_EditAppointmentSearchButtonClicked;

            this.view.AppointmentsView.ChosenAppointmentClick += AppointmentsView_ChosenAppointmentClick;

            this.view.EditAppointmentSearchView.SearchAppointmentButtonClicked += EditAppointmentSearchView_SearchAppointmentButtonClicked;
        }

        private void EditAppointmentSearchView_SearchAppointmentButtonClicked()
        {
            if (model.AppointmentExist(view.EditAppointmentSearchView.PeselPatient, view.EditAppointmentSearchView.DateTimeAppointment)){
                if (!view.EditAppointmentActive)
                    view.EditAppointmentActive = true;
                if (view.EditAppointmentSearchActive)
                    view.EditAppointmentSearchActive = false;
            }
        }

        private void MenuView_EditAppointmentSearchButtonClicked()
        {
            if (view.EditActive)
                view.EditActive = false;
            if (!view.MenuActive)
                view.MenuActive = true;
            if (view.AppointmentsActive)
                view.AppointmentsActive = false;
            if (view.AppointmentActive)
                view.AppointmentActive = false;
            if (view.RegisterAppointmentActive)
                view.RegisterAppointmentActive = false;
            if (view.EditAppointmentActive)
                view.EditAppointmentActive = false;
            if (!view.EditAppointmentSearchActive)
                view.EditAppointmentSearchActive = true;
        }

        private void MenuView_RegisterAppointmentButtonClicked()
        {
            if (FormLogin.position == Position.pacjent)
            {
                if (view.EditActive)
                    view.EditActive = false;
                if (!view.MenuActive)
                    view.MenuActive = true;
                if (view.AppointmentsActive)
                    view.AppointmentsActive = false;
                if (view.AppointmentActive)
                    view.AppointmentActive = false;
                if (!view.RegisterAppointmentActive)
                    view.RegisterAppointmentActive = true;
                if (view.EditAppointmentActive)
                    view.EditAppointmentActive = false;
                if (view.EditAppointmentSearchActive)
                    view.EditAppointmentSearchActive = false;

                if (view.RegisterAppointmentView.DoctorActive)
                    view.RegisterAppointmentView.DoctorActive = false;

                view.RegisterAppointmentView.Specializations = model.GetSpecializations();
            }
            else
            {
                MessageBox.Show("Brak uprawnien! To jest menu dla pacjenta!");
            }
        }

        private void AppointmentsView_ChosenAppointmentClick()
        {
            if (int.Parse(view.AppointmentsView.ChosenAppointment) > -1)
            {
                if (view.EditActive)
                    view.EditActive = false;
                if (!view.MenuActive)
                    view.MenuActive = true;
                if (view.AppointmentsActive)
                    view.AppointmentsActive = false;
                if (!view.AppointmentActive)
                    view.AppointmentActive = true;
                if (view.RegisterAppointmentActive)
                    view.RegisterAppointmentActive = false;
                if (view.EditAppointmentActive)
                    view.EditAppointmentActive = false;
                if (view.EditAppointmentSearchActive)
                    view.EditAppointmentSearchActive = false;

                view.AppointmentView.FullfilFields = model.GetSpecificAppointment(view.AppointmentsView.ChosenAppointment);
            }
        }

        private void MenuView_AppointmentsButtonClicked()
        {
            if (view.EditActive)
                view.EditActive = false;
            if (!view.MenuActive)
                view.MenuActive = true;
            if (!view.AppointmentsActive)
                view.AppointmentsActive = true;
            if (view.AppointmentActive)
                view.AppointmentActive = false;
            if (view.RegisterAppointmentActive)
                view.RegisterAppointmentActive = false;
            if (view.EditAppointmentActive)
                view.EditAppointmentActive = false;
            if (view.EditAppointmentSearchActive)
                view.EditAppointmentSearchActive = false;

            view.AppointmentsView.Content = model.GetAppointments();
        }

        private void MenuView_LogOut()
        {
            view.ExitForm();
        }

        private void MenuView_EditButtonClicked()
        {
            view.Title = FormLogin.position.ToString();

            // tutaj beda wszystkie okna, upewnienie sie, ze na pewno dobre wyswietli - w kazdej metodzie tak bedzie, wiec moze zrobi sie osobna metode obslugujaca wszystkie wyjatki
            if (!view.EditActive)
                view.EditActive = true;
            if (!view.MenuActive)
                view.MenuActive = true;
            if (view.AppointmentsActive)
                view.AppointmentsActive = false;
            if (view.AppointmentActive)
                view.AppointmentActive = false;
            if (view.RegisterAppointmentActive)
                view.RegisterAppointmentActive = false;
            if (view.EditAppointmentActive)
                view.EditAppointmentActive = false;
            if (view.EditAppointmentSearchActive)
                view.EditAppointmentSearchActive = false;

            // aktualizacja panelu informacji (kto jest zalogowany i jaki panel [pacjent/lekarz])
            if (!view.WelcomeLabel.Contains(FormLogin.position.ToString()))
                view.WelcomeLabel = view.WelcomeLabel.Replace("Panel", "Panel " + FormLogin.position + "a");

            // aktualizacja panelu edycji (pola wspoldzielone)
            if (!view.EditView.SharedFields)
                view.EditView.SharedFields = true;

            // aktualizacja pól wspólnych, które znajdują się w tej samej klasie FormLogin
            view.EditView.ID = FormLogin.id;
            view.EditView.Pesel = FormLogin.pesel;

            // jesli jest zalogowany pacjent
            if (FormLogin.position == Position.pacjent)
            {
                // metoda w modelu, ktora pobierze pacjenta
                pacjent = model.GetPatientInfo(FormLogin.pesel.ToString());

                // na wszelki wypadek czyscimy lekarza, jesli jest
                if(lekarz != null) { lekarz = null; }

                // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                if (!view.WelcomeLabel.Contains($"Witaj, {pacjent.Name} {pacjent.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {pacjent.Name} {pacjent.Surname}");

                // pokaz pola pacjenta i ukryj doktora
                if (!view.EditView.PatientFields)
                    view.EditView.PatientFields = true;
                if (view.EditView.DoctorFields)
                    view.EditView.DoctorFields = false;
                if (view.MenuView.EditAppointmentButtonVisibility)
                    view.MenuView.EditAppointmentButtonVisibility = false;
                if (!view.MenuView.RegisterAppointmentButtonVisibility)
                    view.MenuView.RegisterAppointmentButtonVisibility = true;

                // uzupelnij dane (przydalaby sie jakas osobna metoda do tego, dla obydwoch 'pozycji' [lekarz/pacjent])
                view.EditView.FirstName = pacjent.Name;
                view.EditView.Surname = pacjent.Surname;
                view.EditView.PhoneNumber = pacjent.PhoneNumber;
                view.EditView.Sex = pacjent.Sex.ToString();
                view.EditView.BirthDay = pacjent.BirthDay;
                view.EditView.Address = pacjent.Address;
            }
            else
            {
                // metoda w modelu, ktora pobierze lekarza
                lekarz = model.GetDoctorInfo(FormLogin.pesel.ToString());

                // na wszelki wypadek czyscimy pacjenta, jesli jest
                if (pacjent != null) { pacjent = null; }

                // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                if (!view.WelcomeLabel.Contains($"Witaj, {lekarz.Name} {lekarz.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {lekarz.Name} {lekarz.Surname}");

                // ukryj pola pacjenta i pokaz doktora
                if (view.EditView.PatientFields)
                    view.EditView.PatientFields = false;
                if (!view.EditView.DoctorFields)
                    view.EditView.DoctorFields = true;
                if (!view.MenuView.EditAppointmentButtonVisibility)
                    view.MenuView.EditAppointmentButtonVisibility = true;
                if (view.MenuView.RegisterAppointmentButtonVisibility)
                    view.MenuView.RegisterAppointmentButtonVisibility = false;

                // uzupelnij dane (przydalaby sie jakas osobna metoda do tego, dla obydwoch 'pozycji' [lekarz/pacjent])
                view.EditView.FirstName = lekarz.Name;
                view.EditView.Surname = lekarz.Surname;
                view.EditView.PhoneNumber = lekarz.PhoneNumber;
                view.EditView.Hour = lekarz.Hour.ToString();
                view.EditView.Room = lekarz.Room;
            }
        }
        #endregion
    }
}
