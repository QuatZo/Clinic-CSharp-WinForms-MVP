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
        IRegisterAppointmentPanelView view;
        Model model;

        public RegisterAppointmentPanelPresenter(IRegisterAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.SpecializationChosen += View_SpecializationChosen;
            this.view.DoctorChosen += View_DoctorChosen;
            this.view.RegisterButtonClicked += View_RegisterButtonClicked;
        }

        private void View_RegisterButtonClicked()
        {
            if (view.Specialization != "" && view.Doctor != "")
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

            List<string> doctors = new List<string>();

            foreach(var doc in model.GetDoctors(view.Specialization))
            {
                Console.WriteLine(doc);
            }

            view.Doctors = model.GetDoctors(view.Specialization);
        }
    }
}
