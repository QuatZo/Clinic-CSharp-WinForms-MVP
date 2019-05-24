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
        IView view = new FormMain();
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

        #region Methods
        private void EditAppointmentSearchView_SearchAppointmentButtonClicked()
        {
            view.EditAppointmentView.AppointmentID = model.GetAppointmentToEditID(view.EditAppointmentSearchView.PeselPatient, view.EditAppointmentSearchView.DateTimeAppointment);

            if (view.EditAppointmentView.AppointmentID > -1){

                view.SetView();
                if (!view.EditAppointmentActive) { view.EditAppointmentActive = true; }

                view.EditAppointmentView.Content = model.GetSpecificAppointment(view.EditAppointmentView.AppointmentID.ToString())[3];
                view.EditAppointmentView.Prescription = model.GetPrescription(view.EditAppointmentView.AppointmentID);
            }
        }

        private void MenuView_EditAppointmentSearchButtonClicked()
        {
            view.SetView();
            if (!view.EditAppointmentSearchActive) { view.EditAppointmentSearchActive = true; }
        }

        private void MenuView_RegisterAppointmentButtonClicked()
        {
            if (FormLogin.position == Position.pacjent)
            {

                view.SetView();
                if (!view.RegisterAppointmentActive) { view.RegisterAppointmentActive = true; }

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

                view.SetView();
                if (!view.AppointmentActive) { view.AppointmentActive = true; }

                view.AppointmentView.FullfilFields = model.GetSpecificAppointment(view.AppointmentsView.ChosenAppointment);
            }
        }

        private void MenuView_AppointmentsButtonClicked()
        {
            view.SetView();
            if (!view.AppointmentsActive) { view.AppointmentsActive = true; }

            view.AppointmentsView.Content = model.GetAppointments();
        }

        private void MenuView_LogOut()
        {
            view.ExitForm();
        }

        private void MenuView_EditButtonClicked()
        {
            view.Title = FormLogin.position.ToString();

            // wylacz wszystkie widoki procz menu, potem wlacz ten ktory chcemy widziec
            view.SetView();
            if (!view.EditActive) { view.EditActive = true; }

            // aktualizacja panelu informacji (kto jest zalogowany i jaki panel [pacjent/lekarz])
            if (!view.WelcomeLabel.Contains(FormLogin.position.ToString()))
                view.WelcomeLabel = view.WelcomeLabel.Replace("Panel", "Panel " + FormLogin.position + "a");

            // aktualizacja panelu edycji (pola wspoldzielone)
            if (!view.EditView.SharedFields)
                view.EditView.SharedFields = true;

            // jesli jest zalogowany pacjent
            if (FormLogin.position == Position.pacjent)
            {
                // metoda w modelu, ktora pobierze pacjenta
                model.GetPatientInfo(Patient.Instance.Id.ToString());

                // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                if (!view.WelcomeLabel.Contains($"Witaj, {Patient.Instance.Name} {Patient.Instance.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {Patient.Instance.Name} {Patient.Instance.Surname}");

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
                view.EditView.ID = Patient.Instance.Id;
                view.EditView.FirstName = Patient.Instance.Name;
                view.EditView.Surname = Patient.Instance.Surname;
                view.EditView.Pesel = Patient.Instance.Pesel;
                view.EditView.PhoneNumber = Patient.Instance.PhoneNumber;
                view.EditView.Sex = Patient.Instance.Sex.ToString();
                view.EditView.BirthDay = Patient.Instance.BirthDay;
                view.EditView.Address = Patient.Instance.Address;
            }
            else
            {
                // metoda w modelu, ktora pobierze lekarza
                model.GetDoctorInfo(Doctor.Instance.Pesel.ToString());

                // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                if (!view.WelcomeLabel.Contains($"Witaj, {Doctor.Instance.Name} {Doctor.Instance.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {Doctor.Instance.Name} {Doctor.Instance.Surname}");

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
                view.EditView.ID = Doctor.Instance.Id;
                view.EditView.FirstName = Doctor.Instance.Name;
                view.EditView.Surname = Doctor.Instance.Surname;
                view.EditView.Pesel = Doctor.Instance.Pesel;
                view.EditView.PhoneNumber = Doctor.Instance.PhoneNumber;
                view.EditView.Hour = Doctor.Instance.Hour.ToString();
                view.EditView.Room = Doctor.Instance.Room;
            }
        }
        #endregion
    }
}
