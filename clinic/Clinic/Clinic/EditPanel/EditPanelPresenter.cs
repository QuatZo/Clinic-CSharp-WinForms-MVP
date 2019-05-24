using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    class EditPanelPresenter
    {
        #region Classes
        IEditPanelView view;
        Model model;

        Doctor lekarz;
        #endregion

        public EditPanelPresenter(IEditPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            view.SaveButtonClicked += View_SaveButtonClicked; // aktualizacja danych (polaczenie z baza)
        }

        #region Methods
        private void View_SaveButtonClicked()
        {
            // jesli pacjent jest zalogowany
            if (FormLogin.position == Position.pacjent)
            {
                try
                {
                    int.Parse(view.PhoneNumber);

                    // metoda w modelu, ktora zapisze pacjenta, a potem pobiera (prawdopodobnie) nowe dane
                    if (model.UpdatePatientInfo(view.PhoneNumber, view.Address))
                        model.GetPatientInfo(Patient.Instance.Id.ToString());

                    // czy dane zostaly zaktualizowane
                    if (Patient.Instance.PhoneNumber == view.PhoneNumber && Patient.Instance.Address == view.Address) { MessageBox.Show("Poprawnie zaktualizowano dane pacjenta!"); }
                    else { MessageBox.Show("Ups! Coś poszło nie tak. Sprawdź czy nie umieściłeś/aś gdzieś polskich znaków."); }

                    if (lekarz != null) { lekarz = null; }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Podano błędne dane!");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Podano błędny numer telefonu!");
                }
            }
            // jesli lekarz jest zalogowany
            else
            {
                try
                {
                    int.Parse(view.PhoneNumber);
                    // metoda w modelu, ktora zapisze lekarza, a potem pobiera (prawdopodobnie) nowe dane
                    if (model.UpdateDoctorInfo(view.PhoneNumber, view.Hour, view.Room))
                        model.GetDoctorInfo(Doctor.Instance.Pesel.ToString());

                    // czy dane zostaly zaktualizowane
                    if (Doctor.Instance.PhoneNumber == view.PhoneNumber && Doctor.Instance.Hour.ToString() == view.Hour && Doctor.Instance.Room == view.Room) { MessageBox.Show("Poprawnie zaktualizowano dane lekarza!"); }
                    else { MessageBox.Show("Ups! Coś poszło nie tak!"); }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Podano błędne dane!");
                }
            }   
            
        }
        #endregion
    }
}
