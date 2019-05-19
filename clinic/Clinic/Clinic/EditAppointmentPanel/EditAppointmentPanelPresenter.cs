using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            this.view.SaveAppointmentButtonClicked += View_SaveAppointmentButtonClicked;
            this.view.AddRowButtonClicked += View_AddRowButtonClicked;
            this.view.DeleteRowButtonClicked += View_DeleteRowButtonClicked;
        }

        private void View_SaveAppointmentButtonClicked()
        {
            if (model.UpdateAppointmentInfo(view.AppointmentID, view.Content))
            {
                MessageBox.Show("Opis został poprawnie zaktualizowany!", "Potwierdzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ups! Coś poszło nie tak!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void View_AddRowButtonClicked()
        {
            FormAddRowToPrescription AddRowForm = new FormAddRowToPrescription(view.AppointmentID);
            AddRowForm.FormClosing += new FormClosingEventHandler(AddRowForm_FormClosing);
            AddRowForm.Show();
        }

        private void AddRowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
