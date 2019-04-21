﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient
{
    class Model
    {
        // Wszystkie metody wszystkich widoków

        // walidacja numeru pesel
        bool PeselValidation(double dPesel)
        {
            int[] multipliers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 1 };
            int sum = 0;
            char[] cPesel = new char[11];
            cPesel = dPesel.ToString().ToCharArray();


            for (int i = 0; i < multipliers.Length; i++)
            {
                sum += multipliers[i] * int.Parse(cPesel[i].ToString());
            }

            if(sum % 10 == 0) { return true; }
            else { return false; }
        }

        // sprawdzamy pesel, w przypadku poprawnego przycisk logowania staje sie dostepny
        public bool CheckPesel(string CurrentPesel)
        {
            if (CurrentPesel.Length == 11 && Double.TryParse(CurrentPesel, out double dPesel))
            {
                if (PeselValidation(dPesel)) { return true; }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Błąd! Niepoprawny numer PESEL!");
                    return false;
                }
            }
            else { return false; }
        }

        public bool IsInDatabase(string CurrentPesel, string CurrentSurname, string CurrentID)
        {
            //zapytanie do bazy czy taki pesel juz istnieje
            //if(wynik['pesel'] == CurrentPesel && [...])
            //{
            //    return true;
            //}
            //else { return false; }

            // test
            return true;
        }
    }
}