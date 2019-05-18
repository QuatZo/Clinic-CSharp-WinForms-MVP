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

    class Patient
    {
        // parametry klasy
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public double Pesel { get; }
        public Sexs Sex { get; }
        public DateTime BirthDay { get; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        // konstruktor klasy
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

        // przeciazona metoda ToString
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Surname}\t{Pesel}\t{Sex}\t{BirthDay}\t{Address}\t{PhoneNumber}";
        }
    }
}
