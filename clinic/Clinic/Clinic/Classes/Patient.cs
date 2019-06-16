using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    public enum Sexs {
        kobieta,
        mezczyzna
    };

    public class Patient
    {
        #region Properties
        public int Id { get; private set; } = -1;
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double Pesel { get; private set; }
        public Sexs Sex { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        #endregion

        public Patient(int id, string name, string surname, double pesel, Sexs sex, DateTime birthDay, string address, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel = pesel;
            Sex = sex;
            BirthDay = birthDay.Date; 
            Address = address;
            PhoneNumber = phoneNumber;
        }

        #region Methods
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Surname}\t{Pesel}\t{Sex}\t{BirthDay}\t{Address}\t{PhoneNumber}";
        }
        #endregion
    }
}
