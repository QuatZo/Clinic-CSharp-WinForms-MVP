using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public enum Hours
    {
        poranne,
        popoludniowe,
        wieczorowe
    };

    public class Doctor
    {
        #region Properties
        public int Id { get; } = -1;
        public string Name { get; }
        public string Surname { get; }
        public double Pesel { get; }
        public string PhoneNumber { get; }
        public int Room { get; }
        public Hours Hour { get; }
        #endregion

        public Doctor(int id, string name, string surname, double pesel, string phoneNumber, int room, Hours hours)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel = pesel;
            PhoneNumber = phoneNumber;
            Room = room;
            Hour = hours;
        }

        #region Methods
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Surname}\t{Pesel}\t{PhoneNumber}\t{Room}\t{Hour}";
        }
        #endregion
    }
}
