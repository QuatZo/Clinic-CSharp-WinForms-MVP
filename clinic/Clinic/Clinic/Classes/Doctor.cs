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

    class Doctor
    {
        #region Properties
        private static Doctor instance = null;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public double Pesel { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Room { get; private set; }
        public Hours Hour { get; private set; }
        #endregion
        public static Doctor Instance
        {
            get
            {
                // jesli lewo null to zwroc prawo
                return instance ?? (instance = new Doctor());
            }
        }

        private Doctor()
        {
            Console.WriteLine("Singleton Lekarza");
        }

        #region Methods
        public void Create(int id, string name, string surname, double pesel, string phoneNumber, int room, Hours hours)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Pesel = pesel;
            PhoneNumber = phoneNumber;
            Room = room;
            Hour = hours;
        }

        public void Edit(string phoneNumber, string hour, int room)
        {
            PhoneNumber = phoneNumber;
            Room = room;

            if (hour == "poranne") { Hour = Hours.poranne; }
            else if (hour == "popoludniowe") { Hour = Hours.popoludniowe; }
            else { Hour = Hours.wieczorowe; }
        }
        
        public override string ToString()
        {
            return $"{Id}\t{Name}\t{Surname}\t{Pesel}\t{PhoneNumber}\t{Room}\t{Hour}";
        }
        #endregion
    }
}
