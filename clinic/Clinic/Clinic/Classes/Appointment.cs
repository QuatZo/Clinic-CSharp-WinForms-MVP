using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public class Appointment
    {
        #region Properties
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public List<(int ID, string Name, string Dose)> Medicines { get; set; }
        #endregion

        public Appointment(int id, Patient patient, Doctor doctor, DateTime date, string content, List<(int, string, string)> medicines)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            Date = date;
            Content = content;
            Medicines = medicines.OrderBy(iTuple => iTuple.Item2).ThenBy(iTuple => iTuple.Item3).ToList(); // sortowanie po nazwie, potem po dawce
        }

        #region Methods
        public override string ToString()
        {
            string str = $"{Id}\t{Patient}\t{Doctor}\t{Date.ToString()}\t{Content}\t";
            foreach(var medicine in Medicines)
            {
                str += $"({medicine.ID}, {medicine.Name}, {medicine.Dose})\t";
            }
            return str;
        }
        #endregion
    }
}
