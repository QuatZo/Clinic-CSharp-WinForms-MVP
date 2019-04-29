using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class Model
    {
        // Wszystkie metody wszystkich widoków

        // pobiera informacje uzytkownika i wrzuca je do tablicy znaków
        public string[] GetUserInfo(string CurrentPesel)
        {
            // dane będą pobierane z bazy danych
            // 2 to ilosc info, poki co 2 (a bedzie jakby cala klasa, wszystkie info)
            // na potrzeby testow uzywamy po prostu adresu i numeru telefonu
            string[] Info = new string[2];

            Info[0] = "Piłsudskiego 27/5";
            Info[1] = "502609296";

            return Info;
        }
    }
}
