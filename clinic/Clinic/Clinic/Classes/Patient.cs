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

    public sealed class Patient
    {
        #region Properties
        private static Patient instance = null;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double Pesel { get; private set; }
        public Sexs Sex { get; private set; }
        public DateTime BirthDay { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        #endregion

        public static Patient Instance
        {
            get
            {
                // jesli lewo null to zwroc prawo
                return instance ?? (instance = new Patient());
            }
        }

        private Patient()
        {
            Console.WriteLine("Singleton Pacjenta");
        }

        #region Methods
        public void Create(int id, string name, string surname, double pesel, Sexs sex, DateTime birthDay, string address, string phoneNumber)
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

        public void Edit(string phoneNumber, string address)
        {
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Surname}\t{Pesel}\t{Sex}\t{BirthDay}\t{Address}\t{PhoneNumber}";
        }
        #endregion
    }
}
