using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    enum Sex {
        kobieta,
        mezczyzna
    };

    class Patient
    {
        int id;
        string name;
        string surname;
        double pesel;
        Sex sex;
        DateTime birthDay;
        string address;
        string phoneNumber;

        // pamietac naprawic konstruktor jak sie odkomentuje powyzsze pola
        public Patient(int id, string name, string surname, double pesel, Sex sex, DateTime birthDay, string address, string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.sex = sex;
            this.birthDay = birthDay.Date; 
            this.pesel = pesel;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{id}\t{name}\t{surname}\t{pesel}\t{sex}\t{birthDay}\t{address}\t{phoneNumber}";
        }
    }
}
