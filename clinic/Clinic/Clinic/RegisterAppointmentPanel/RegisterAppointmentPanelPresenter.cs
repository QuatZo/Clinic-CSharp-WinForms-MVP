using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    class RegisterAppointmentPanelPresenter
    {
        #region Classes
        private IRegisterAppointmentPanelView view;
        private Model model;
        #endregion

        public RegisterAppointmentPanelPresenter(IRegisterAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.SpecializationChosen += View_SpecializationChosen;
            this.view.DoctorChosen += View_DoctorChosen;
            this.view.RegisterButtonClicked += View_RegisterButtonClicked;

            this.view.AppointmentDateChanged += View_AppointmentDateChanged;
        }

        #region Methods
        private void View_AppointmentDateChanged()
        {
            if (view.AppointmentDate < DateTime.Now)
            {
                MessageBox.Show("Nie można umówić wizyty na przeszłość!");
                view.AppointmentDate = DateTime.Now;
            }
        }

        private void View_RegisterButtonClicked()
        {
            if(view.Hour == "poranne" && (view.AppointmentDate.Hour < 8 || view.AppointmentDate.Hour > 11) ||
                view.Hour == "popoludniowe" && (view.AppointmentDate.Hour < 12 || view.AppointmentDate.Hour > 15) ||
                view.Hour == "wieczorowe" && (view.AppointmentDate.Hour < 16 || view.AppointmentDate.Hour > 19))
            {
                MessageBox.Show("Godzina wizyty nie zgadza się z godzinami przyjęć lekarza!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (view.Specialization != "" && view.Doctor != "")
            {
                if (model.RegisterAppointment(view.Doctor, view.Content, view.AppointmentDate)) { MessageBox.Show("Wizyta została zarejestrowana!"); }
                else { MessageBox.Show("Ups! Coś poszło nie tak!"); }
            }
            else
            {
                MessageBox.Show("Błędne dane!");
            }
        }

        private void View_DoctorChosen()
        {
            if (view.Doctor != null || view.Doctor != "")
            {
                view.Hour = model.GetDoctorHours(view.Doctor);
            }
        }

        private void View_SpecializationChosen()
        {
            if (!view.DoctorActive)
                view.DoctorActive = true;

            view.Doctors = model.GetDoctors(view.Specialization);
        }
        #endregion
    }
}
