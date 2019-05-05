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
        IEditPanelView view;
        Model model;

        // klasy, bedziemy wybierac jedna
        Patient pacjent;
        Doctor lekarz;

        public EditPanelPresenter(IEditPanelView view, Model model)
        {
            this.view = view;
            this.model = model;

            view.SaveButtonClicked += View_SaveButtonClicked; // aktualizacja danych (polaczenie z baza)
        }

        private void View_SaveButtonClicked()
        {
            // jesli pacjent jest zalogowany
            if (FormLogin.position == Position.pacjent)
            {
                try
                {
                    int.Parse(view.PhoneNumber);
                    Console.WriteLine(view.PhoneNumber);
                    // metoda w modelu, ktora zapisze pacjenta, a potem pobiera (prawdopodobnie) nowe dane
                    if (model.UpdatePatientInfo(view.PhoneNumber, view.Address))
                        pacjent = model.GetPatientInfo(FormLogin.pesel.ToString());

                    // czy dane zostaly zaktualizowane
                    if (pacjent.PhoneNumber == view.PhoneNumber && pacjent.Address == view.Address) { MessageBox.Show("Poprawnie zaktualizowano dane pacjenta!"); }
                    else { MessageBox.Show("Ups! Coś poszło nie tak!"); }

                    if (lekarz != null) { lekarz = null; }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Podano błędne dane!");
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
                        lekarz = model.GetDoctorInfo(FormLogin.pesel.ToString());

                    // czy dane zostaly zaktualizowane
                    if (lekarz.PhoneNumber == view.PhoneNumber && lekarz.Hour.ToString() == view.Hour && lekarz.Room == view.Room) { MessageBox.Show("Poprawnie zaktualizowano dane lekarza!"); }
                    else { MessageBox.Show("Ups! Coś poszło nie tak!"); }
                
                    if (pacjent != null) { pacjent = null; }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Podano błędne dane!");
                }
            }   
            
        }
    }
}
