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
        public int Id { get; private set; } = -1;
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double Pesel { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Room { get; private set; }
        public Hours Hour { get; private set; }
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
