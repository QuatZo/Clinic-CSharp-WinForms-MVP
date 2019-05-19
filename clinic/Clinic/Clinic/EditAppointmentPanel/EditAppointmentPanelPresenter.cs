using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class EditAppointmentPanelPresenter
    {
        IEditAppointmentPanelView view;
        Model model;

        public EditAppointmentPanelPresenter(IEditAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.AddRowButtonClicked += View_AddRowButtonClicked;
            this.view.DeleteRowButtonClicked += View_DeleteRowButtonClicked;
        }

        private void View_AddRowButtonClicked()
        {
            FormAddRowToPrescription AddRow = new FormAddRowToPrescription(view.AppointmentID);
            AddRow.Show();

            view.Prescription = model.GetPrescription(view.AppointmentID);
        }

        private void View_DeleteRowButtonClicked()
        {
            if (view.Prescription.Count > 0)
            {
                List<int> ids = new List<int>();

                foreach(var el in view.Prescription)
                {
                    ids.Add(int.Parse(el.Split()[0]));
                }
            
                if(model.DeleteRowsFromPrescription(view.AppointmentID, ids))
                {
                    view.Prescription = model.GetPrescription(view.AppointmentID);
                }
            }
        }
    }
}
