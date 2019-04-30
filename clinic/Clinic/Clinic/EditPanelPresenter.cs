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

            view.SaveButtonClicked += View_SaveButtonClicked;
        }

        private void View_SaveButtonClicked()
        {
            if (FormLogin.position == Position.pacjent)
            {
                // metoda w modelu, ktora zapisze pacjenta, a potem bierze
                if(model.UpdatePatientInfo(FormLogin.pesel.ToString(), view.PhoneNumber, view.Address))
                    pacjent = model.GetPatientInfo(FormLogin.pesel.ToString());

                if (pacjent.PhoneNumber == view.PhoneNumber && pacjent.Address == view.Address) { MessageBox.Show("Poprawnie zaktualizowano dane pacjenta!"); }
                else { MessageBox.Show("Ups! Coś poszło nie tak!"); }

                Console.WriteLine(pacjent);
                if (lekarz != null) { lekarz = null; }
            }
            else
            {
                // metoda w modelu, ktora pobierze lekarza
                if (model.UpdateDoctorInfo(FormLogin.pesel.ToString(), view.PhoneNumber, view.Hour, view.Room))
                    lekarz = model.GetDoctorInfo(FormLogin.pesel.ToString());

                if (lekarz.PhoneNumber == view.PhoneNumber && lekarz.Hour.ToString() == view.Hour && lekarz.Room == view.Room) { MessageBox.Show("Poprawnie zaktualizowano dane lekarza!"); }
                else { MessageBox.Show("Ups! Coś poszło nie tak!"); }

                Console.WriteLine(lekarz);
                if (pacjent != null) { pacjent = null; }
            }
        }
    }
}
