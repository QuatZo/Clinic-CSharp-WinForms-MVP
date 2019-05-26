using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public interface IEditPanelView
    {
        #region Properties
        // wszystkie pola edycji (wspoldzielone, pacjenta, lekarza)
        bool SharedFields { get; set; }
        bool PatientFields { get; set; }
        bool DoctorFields { get; set; }

        // pola wspoldzielone
        int ID { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        double Pesel { get; set; }
        string PhoneNumber { get; set; }

        // pola pacjenta
        string Sex { get; set; }
        DateTime BirthDay { get; set; }
        string Address { get; set; }
        
        // pola lekarza
        int Room { get; set; }
        string Hour { get; set; }
        #endregion

        #region Events
        event Action SaveButtonClicked; // zapis (aktualizacja danych do bazy)
        #endregion

        #region Methods
        void FullfilPatientFields();
        void FullfilDoctorFields();
        #endregion
    }
}
