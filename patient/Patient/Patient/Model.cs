using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    class Model
    {
        // Wszystkie metody wszystkich widoków

        public bool CheckPesel(string CurrentPesel)
        {
            double temp = -1;

            if (CurrentPesel.Length == 11 && Double.TryParse(CurrentPesel, out temp))
            {
                Console.WriteLine("Tu bedzie polaczenie z baza i sprawdzenie czy pesel jest poprawny. Poki co drukujemy PESEL.");
                Console.WriteLine(CurrentPesel);

                return true;
            }
            else { return false; }
        }
    }
}
