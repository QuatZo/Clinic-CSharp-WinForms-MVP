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
        private readonly FormLogin formLogin = FormLogin.Instance;
        private Model model = new Model();
        private IView view = new FormMain();
        #endregion

        #region Presenters
        private readonly EditPanelPresenter EditPresenter;
        private readonly RegisterAppointmentPanelPresenter RegisterAppointmentPresenter;
        private readonly EditAppointmentPanelPresenter EditAppointmentPresenter;
        private readonly EditAppointmentSearchPanelPresenter EditAppointmentSearchPresenter;
        #endregion

        public Presenter(IView view, Model model){
            this.view = view;
            this.model = model;

            // konstruktory prezenterów
            EditPresenter = new EditPanelPresenter(view.EditView, model);

            RegisterAppointmentPresenter = new RegisterAppointmentPanelPresenter(view.RegisterAppointmentView, model);

            EditAppointmentPresenter = new EditAppointmentPanelPresenter(view.EditAppointmentView, model);
            EditAppointmentSearchPresenter = new EditAppointmentSearchPanelPresenter(view.EditAppointmentSearchView, model);

            // podpinanie eventów
            this.view.FormLoaded += MenuView_EditButtonClicked;

            this.view.MenuView.EditButtonClicked += MenuView_EditButtonClicked;
            this.view.MenuView.RegisterAppointmentButtonClicked += MenuView_RegisterAppointmentButtonClicked;
            this.view.MenuView.AppointmentsButtonClicked += MenuView_AppointmentsButtonClicked;
            this.view.MenuView.LogOut += MenuView_LogOut;
            this.view.MenuView.EditAppointmentSearchButtonClicked += MenuView_EditAppointmentSearchButtonClicked;

            this.view.AppointmentsView.ChosenAppointmentClick += AppointmentsView_ChosenAppointmentClick;

            this.view.EditAppointmentSearchView.SearchAppointmentButtonClicked += EditAppointmentSearchView_SearchAppointmentButtonClicked;
        }

        #region Methods
        // szukaj wizyty (edycja, panel lekarza)
        private void EditAppointmentSearchView_SearchAppointmentButtonClicked()
        {
            view.Appointments = model.GetAppointments();
            view.EditAppointmentView.ID = model.GetAppointmentToEditID(view.Appointments, view.EditAppointmentSearchView.PeselPatient, view.EditAppointmentSearchView.DateTimeAppointment);

            if (view.EditAppointmentView.ID > -1){
                view.SetView();

                if (!view.EditAppointmentActive) { view.EditAppointmentActive = true; }
                view.EditAppointmentView.FullfilFields(view.Appointments[view.EditAppointmentView.ID]);
            }
        }

        // "Edytuj wizytę" w menu
        private void MenuView_EditAppointmentSearchButtonClicked()
        {
            view.SetView();
            if (!view.EditAppointmentSearchActive) { view.EditAppointmentSearchActive = true; }
        }

        // "Zarejestruj wizytę" w menu
        private void MenuView_RegisterAppointmentButtonClicked()
        {
            view.SetView();
            if (!view.RegisterAppointmentActive) { view.RegisterAppointmentActive = true; }

            if (view.RegisterAppointmentView.DoctorActive)
                view.RegisterAppointmentView.DoctorActive = false;

            view.RegisterAppointmentView.Specializations = model.GetSpecializations();
        }

        // Wybranie wizyty z listy
        private void AppointmentsView_ChosenAppointmentClick()
        {
            if (view.AppointmentsView.ChosenAppointment > -1)
            {
                view.SetView();
                if (!view.AppointmentActive) { view.AppointmentActive = true; }
                view.AppointmentView.FullfilFields = view.Appointments[view.AppointmentsView.ChosenAppointment];
            }
        }

        // "Wizyty" w menu
        private void MenuView_AppointmentsButtonClicked()
        {
            view.SetView();
            if (!view.AppointmentsActive) { view.AppointmentsActive = true; }

            view.Appointments = model.GetAppointments();
            view.AppointmentsView.Content = model.GetAppointmentsMainInfo(view.Appointments);
        }

        // "Zamknij" w menu
        private void MenuView_LogOut()
        {
            view.ExitForm();
        }

        // "Edytuj dane" w menu
        private void MenuView_EditButtonClicked()
        {
            view.Title = formLogin.Position.ToString();

            // wylacz wszystkie widoki procz menu, potem wlacz ten ktory chcemy widziec
            view.SetView();
            if (!view.EditActive) { view.EditActive = true; }

            // aktualizacja panelu informacji (kto jest zalogowany i jaki panel [pacjent/lekarz])
            if (!view.WelcomeLabel.Contains(formLogin.Position.ToString()))
                view.WelcomeLabel = view.WelcomeLabel.Replace("Panel", "Panel " + formLogin.Position + "a");

            // aktualizacja widoku (pola wspoldzielone)
            if (!view.EditView.SharedFields)
                view.EditView.SharedFields = true;

            // jesli jest zalogowany pacjent
            if (formLogin.Position == Position.pacjent)
            {
                
                try
                {
                    // metoda w modelu, ktora pobierze pacjenta
                    FormLogin.Instance.Patient = model.GetPatientInfo(FormLogin.Instance.Patient.Pesel.ToString());

                    // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                
                    if (!view.WelcomeLabel.Contains($"Witaj, {FormLogin.Instance.Patient.Name} {FormLogin.Instance.Patient.Surname}"))
                        view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {FormLogin.Instance.Patient.Name} {FormLogin.Instance.Patient.Surname}");
                }
                catch (NullReferenceException) { }

                // pokaz pola pacjenta i ukryj doktora
                if (!view.EditView.PatientFields)
                    view.EditView.PatientFields = true;
                if (view.EditView.DoctorFields)
                    view.EditView.DoctorFields = false;
                if (view.MenuView.EditAppointmentButtonVisibility)
                    view.MenuView.EditAppointmentButtonVisibility = false;
                if (!view.MenuView.RegisterAppointmentButtonVisibility)
                    view.MenuView.RegisterAppointmentButtonVisibility = true;

                // uzupelnij dane
                view.EditView.FullfilPatientFields();
            }
            else
            {
                try
                {
                    // metoda w modelu, ktora pobierze lekarza
                    FormLogin.Instance.Doctor = model.GetDoctorInfo(FormLogin.Instance.Doctor.Pesel.ToString());

                    // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                
                    if (!view.WelcomeLabel.Contains($"Witaj, {FormLogin.Instance.Doctor.Name} {FormLogin.Instance.Doctor.Surname}"))
                        view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {FormLogin.Instance.Doctor.Name} {FormLogin.Instance.Doctor.Surname}");
                }
                catch (NullReferenceException) { }

                // ukryj pola pacjenta i pokaz doktora
                if (view.EditView.PatientFields)
                    view.EditView.PatientFields = false;
                if (!view.EditView.DoctorFields)
                    view.EditView.DoctorFields = true;
                if (!view.MenuView.EditAppointmentButtonVisibility)
                    view.MenuView.EditAppointmentButtonVisibility = true;
                if (view.MenuView.RegisterAppointmentButtonVisibility)
                    view.MenuView.RegisterAppointmentButtonVisibility = false;

                // uzupelnij dane
                view.EditView.FullfilDoctorFields();
            }
        }
        #endregion
    }
}
