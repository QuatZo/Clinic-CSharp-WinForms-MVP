using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    // Wszystkie metody wszystkich widoków
    class Model
    {
        #region Methods
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
        public bool UpdateDoctorInfo(string phoneNumber, string hour, int room)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    if(connection.UpdateInfo($"UPDATE doktorzy SET telefon={phoneNumber}, gabinet={room}, godziny=\"{hour}\" WHERE pesel={FormLogin.pesel}")) { return true; }
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
        public bool UpdatePatientInfo(string phoneNumber, string address)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    if (connection.UpdateInfo($"UPDATE pacjenci SET telefon={phoneNumber}, adres=\"{address}\" WHERE pesel={FormLogin.pesel}")) { return true; }
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

        // pobiera informacje nt wizyt, w zaleznosci od zalogowanej osoby
        public List<string> GetAppointments()
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    string uniqueFields;
                    string whereClause;
                    if (FormLogin.position == Position.pacjent)
                    {
                        uniqueFields = "doktorzy.imie, doktorzy.nazwisko, doktorzy.gabinet";
                        whereClause = $"pacjenci.pesel={FormLogin.pesel}";
                    }
                    else
                    {
                        uniqueFields = "pacjenci.imie, pacjenci.nazwisko, pacjenci.pesel";
                        whereClause = $"doktorzy.pesel={FormLogin.pesel}";
                    }

                    List<string> result = connection.Appointments($"SELECT wizyty.idw, wizyty.data, {uniqueFields} FROM wizyty JOIN pacjenci ON pacjenci.idp=wizyty.idp JOIN doktorzy ON doktorzy.idd=wizyty.idd WHERE {whereClause} ORDER BY wizyty.data DESC");
                    
                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    List<string> result = null;
                    return result;
                }
            }
        }

        // pobiera informacje nt konkretnej wizyty, wybranej przez zalogowanego uzytkownika
        public List<string> GetSpecificAppointment(string id)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<string> result = connection.Appointment($"SELECT pacjenci.pesel, CONCAT(pacjenci.imie, \" \", pacjenci.nazwisko), CONCAT(doktorzy.imie, \" \", doktorzy.nazwisko), wizyty.opis, wizyty.data FROM wizyty JOIN pacjenci ON pacjenci.idp=wizyty.idp JOIN doktorzy ON doktorzy.idd=wizyty.idd WHERE wizyty.idw={id}");

                    result.Add(string.Join("\n", connection.Prescription($"SELECT CONCAT(leki.nazwa, \" \", dawki.ile) FROM wizyty JOIN wiz_i_dawki_i_leki ON wizyty.idw=wiz_i_dawki_i_leki.idw JOIN dawki_i_leki ON wiz_i_dawki_i_leki.iddl=dawki_i_leki.iddl JOIN dawki ON dawki_i_leki.idd=dawki.idd JOIN leki ON dawki_i_leki.idl=leki.idl WHERE wizyty.idw={id}").ToArray()));

                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    List<string> result = null;
                    return result;
                }
            }
        }

        // pobiera liste specjalizacji lekarzy (panel rejestracji wizyty)
        public List<string> GetSpecializations()
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<string> result = connection.Specializations($"SELECT nazwa FROM specjalizacje");

                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    List<string> result = null;
                    return result;
                }
            }
        }

        // pobiera lekarzy, ktorzy posiadaja dana specjalizacje (panel rejestracji wizyty)
        public List<string> GetDoctors(string specialization)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<string> result = connection.Doctors($"SELECT doktorzy.idd, doktorzy.imie, doktorzy.nazwisko FROM doktorzy JOIN dok_i_spec ON doktorzy.idd=dok_i_spec.idd JOIN specjalizacje ON dok_i_spec.ids=specjalizacje.ids WHERE specjalizacje.nazwa=\"{specialization}\"");

                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    List<string> result = null;
                    return result;
                }
            }
        }

        // pobiera w jakich godzinach przyjmuje wybrany lekarz (panel rejestracji wizyty)
        public string GetDoctorHours(string id)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    string result = connection.DoctorHours($"SELECT godziny FROM doktorzy WHERE idd={id}");

                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    string result = null;
                    return result;
                }
            }
        }

        // zapisuje nową wizytę do bazy danych
        public bool RegisterAppointment(string doctorID, string content, DateTime date)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    if (connection.InsertInfo($"INSERT INTO wizyty (idp, idd, opis, data) VALUES ({FormLogin.id}, {doctorID}, \"{content}\", \"{date.ToString("yyyy-MM-dd HH:mm:ss")}\")")) { return true; }
                    else { return false; }
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
                }
            }
        }
        #endregion
    }
}
