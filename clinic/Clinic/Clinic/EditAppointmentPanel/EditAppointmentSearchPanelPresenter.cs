using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class EditAppointmentSearchPanelPresenter
    {
        IEditAppointmentSearchPanelView view;
        Model model;

        public EditAppointmentSearchPanelPresenter(IEditAppointmentSearchPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.PatientPeselChanged += View_PatientPeselChanged;
        }

        private void View_PatientPeselChanged()
        {
            try
            {
                double.Parse(view.PeselPatient);
            }
            catch (FormatException)
            {
                if (view.PeselPatient.Length < 1) { view.PeselPatient = ""; }
                else { view.PeselPatient = view.PeselPatient.Substring(0, view.PeselPatient.Length - 1); }
            }
        }
    }
}
