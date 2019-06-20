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
        #region Classes
        private IEditAppointmentPanelView view;
        private Model model;
        #endregion 

        public EditAppointmentPanelPresenter(IEditAppointmentPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.SaveAppointmentButtonClicked += View_SaveAppointmentButtonClicked;
            this.view.AddRowButtonClicked += View_AddRowButtonClicked;
            this.view.DeleteRowButtonClicked += View_DeleteRowButtonClicked;
        }

        #region Methods
        private void View_SaveAppointmentButtonClicked()
        {
            try
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
            catch (CustomExceptions.DatabaseConnectionFailedException)
            {
                MessageBox.Show("Błąd z połączeniem!");
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
            try
            {
                view.Prescription = model.GetPrescription(view.AppointmentID);
            }
            catch (CustomExceptions.DatabaseConnectionFailedException)
            {
                MessageBox.Show("Błąd z połączeniem!");
            }
        }

        private void View_DeleteRowButtonClicked()
        {
            if (view.Prescription.Count > 0)
            {
                try
                {
                    if(model.DeleteRowsFromPrescription(view.AppointmentID, model.GetPrescriptionsID(view.Prescription)))
                    {
                        view.Prescription = model.GetPrescription(view.AppointmentID);
                    }
                    else
                    {
                        MessageBox.Show("Wpis nie został usunięty. Proszę się zgłosić do administratora!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (CustomExceptions.DatabaseConnectionFailedException)
                {
                    MessageBox.Show("Błąd z połączeniem!");
                }
            }
        }
        #endregion
    }
}
