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
        private readonly FormLogin formLogin = FormLogin.Instance;
        private IEditPanelView view;
        private Model model;
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
            if (formLogin.Position == Position.pacjent)
            {
                try
                {
                    int.Parse(view.PhoneNumber);
                    Patient pacjent = new Patient(-1, "", "", 0, 0, DateTime.Now, "", "");
                    // metoda w modelu, ktora zapisze pacjenta, a potem pobiera (prawdopodobnie) nowe dane
                    if (model.UpdatePatientInfo(view.PhoneNumber, view.Address))
                        pacjent = model.GetPatientInfo(formLogin.Patient.Pesel.ToString());

                    // czy dane zostaly zaktualizowane
                    if (pacjent.PhoneNumber == view.PhoneNumber && pacjent.Address == view.Address) { MessageBox.Show("Poprawnie zaktualizowano dane pacjenta!"); }
                    else { MessageBox.Show("Ups! Coś poszło nie tak. Sprawdź czy nie umieściłeś/aś gdzieś polskich znaków."); }
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
                    Doctor lekarz = new Doctor(-1, "", "", 0, "", 0, 0);
                    // metoda w modelu, ktora zapisze lekarza, a potem pobiera (prawdopodobnie) nowe dane
                    if (model.UpdateDoctorInfo(view.PhoneNumber, view.Hour, view.Room))
                        lekarz = model.GetDoctorInfo(formLogin.Doctor.Pesel.ToString());

                    // czy dane zostaly zaktualizowane
                    if (lekarz.PhoneNumber == view.PhoneNumber && lekarz.Hour.ToString() == view.Hour && lekarz.Room == view.Room) { MessageBox.Show("Poprawnie zaktualizowano dane lekarza!"); }
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
