using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    class Model
    {
        // Wszystkie metody wszystkich widoków

        // pobiera informacje lekarza i wrzuca je do klasy Doctor
        public Doctor GetDoctorInfo(string pesel)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Doctor result = connection.DoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM doktorzy WHERE pesel={pesel}")[0];
                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    Doctor result = null;
                    return result;
                }
            }
        }

        // aktualizuje dane lekarza i zwraca czy zostaly zaktualizowane
        public bool UpdateDoctorInfo(string pesel, string phoneNumber, string hour, int room)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    if(connection.UpdateInfo($"UPDATE doktorzy SET telefon={phoneNumber}, gabinet={room}, godziny=\"{hour}\" WHERE pesel={pesel}")) { return true; }
                    else { return false; }
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
                }
            }
        }

        // aktualizuje dane pacjenta i zwraca czy zostaly zaktualizowane
        public bool UpdatePatientInfo(string pesel, string phoneNumber, string address)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    if (connection.UpdateInfo($"UPDATE pacjenci SET telefon={phoneNumber}, adres=\"{address}\" WHERE pesel={pesel}")) { return true; }
                    else { return false; }
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
                }
            }
        }
        // pobiera informacje pacjenta i wrzuca je do klasy Patient
        public Patient GetPatientInfo(string pesel)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Patient result = connection.PatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM pacjenci WHERE pesel={pesel}")[0];
                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    Patient result = null;
                    return result;
                }
            }
        }
    }
}
