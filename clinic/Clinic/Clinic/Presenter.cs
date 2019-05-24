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

            List<string> appointments = new List<string>();
            foreach(var appointment in model.GetAppointments())
            {
                string str = appointment.Id.ToString() + "\t- ";
                str += appointment.Date.ToString("yyyy-MM-dd HH:mm") + "\t- ";

                if (FormLogin.position == Position.pacjent) { str += $"{appointment.Doctor.Name} {appointment.Doctor.Surname}\t- "; }
                else { str += $"{appointment.Patient.Name} {appointment.Patient.Surname}\t- "; }

                str += appointment.Doctor.Room.ToString();

                appointments.Add(str);
            }
            view.AppointmentsView.Content = appointments;
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
                FormLogin.patient = model.GetPatientInfo(FormLogin.patient.Pesel.ToString());

                // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                if (!view.WelcomeLabel.Contains($"Witaj, {FormLogin.patient.Name} {FormLogin.patient.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {FormLogin.patient.Name} {FormLogin.patient.Surname}");

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
                // metoda w modelu, ktora pobierze lekarza
                FormLogin.doctor = model.GetDoctorInfo(FormLogin.doctor.Pesel.ToString());

                // aktualizuj info, jesli juz nie jest zaktualizowane (czyt. pierwszy raz odpalone)
                if (!view.WelcomeLabel.Contains($"Witaj, {FormLogin.doctor.Name} {FormLogin.doctor.Surname}"))
                    view.WelcomeLabel = view.WelcomeLabel.Replace("Witaj", $"Witaj, {FormLogin.doctor.Name} {FormLogin.doctor.Surname}");

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
                view.EditView.FullfilDoctorFields();
            }
        }
        #endregion
    }
}
