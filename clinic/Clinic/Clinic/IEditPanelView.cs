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
        bool SharedFields { get; set; }
        bool PatientFields { get; set; }
        bool DoctorFields { get; set; }

        int ID { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        double Pesel { get; set; }
        string PhoneNumber { get; set; }

        string Sex { get; set; }
        DateTime BirthDay { get; set; }
        string Address { get; set; }
        
        int Room { get; set; }
        string Hour { get; set; }
        #endregion

        #region Events
        event Action SaveButtonClicked;
        #endregion
    }
}
