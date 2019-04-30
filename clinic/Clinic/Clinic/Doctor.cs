using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    enum Hours
    {
        poranne,
        popoludniowe,
        wieczorowe
    };

    class Doctor
    {
        // parametry klasy
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public double Pesel { get; }
        public string PhoneNumber { get; }
        public int Room { get; }
        public Hours Hour { get; }

        // konstruktor
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

        // przeciazona metoda ToString
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Surname}\t{Pesel}\t{PhoneNumber}\t{Room}\t{Hour}";
        }
    }
}
