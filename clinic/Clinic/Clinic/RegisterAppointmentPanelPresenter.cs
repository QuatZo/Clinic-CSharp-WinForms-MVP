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
            if (view.GetSpecialization != "" && view.GetDoctor != "")
            {
                if (model.RegisterAppointment(view.Fields)) { MessageBox.Show("Wizyta została zarejestrowana!"); }
                else { MessageBox.Show("Ups! Coś poszło nie tak!"); }
            }
            else
            {
                MessageBox.Show("Błędne dane!");
            }
        }

        private void View_DoctorChosen()
        {
            if (view.GetDoctor != null || view.GetDoctor != "")
            {
                view.HoursField = model.GetDoctorHours(view.GetDoctor);
            }
        }

        private void View_SpecializationChosen()
        {
            if (!view.DoctorActive)
                view.DoctorActive = true;

            List<string> doctors = new List<string>();

            foreach(var doc in model.GetDoctors(view.GetSpecialization))
            {
                Console.WriteLine(doc);
            }

            view.SetDoctorsList = model.GetDoctors(view.GetSpecialization);
        }
    }
}
