using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Patient
    {
        int id;
        string name;
        string surname;
        double pesel;
        // bedzie jak baza bedzie poprawna, poki co jest testowa
        //enum Plec { kobieta, mezczyzna};
        //DateTime dataUrodzenia;
        string adres;
        string telefon;

        // pamietac naprawic konstruktor jak sie odkomentuje powyzsze pola
        public Patient(int id, string name, string surname, double pesel, string adres, string telefon)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
            this.adres = adres;
            this.telefon = telefon;
        }

        public override string ToString()
        {
            return $"{id}\t{pesel}\t{name}\t{surname}\t{adres}\t{telefon}";
        }
    }
}
