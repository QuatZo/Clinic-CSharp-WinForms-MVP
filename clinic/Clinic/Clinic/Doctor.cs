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
        int id;
        string name;
        string surname;
        double pesel;
        string phoneNumber;
        int room;
        Hours hours;

        public Doctor(int id, string name, string surname, double pesel, string phoneNumber, int room, Hours hours)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.phoneNumber = phoneNumber;
            this.room = room;
            this.hours = hours;
        }

        public override string ToString()
        {
            return $"{id}\t{name}\t{surname}\t{pesel}\t{phoneNumber}\t{room}\t{hours}";
        }
    }
}
