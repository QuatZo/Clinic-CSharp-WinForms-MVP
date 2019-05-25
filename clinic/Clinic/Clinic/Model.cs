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
                    Doctor result = connection.GetDoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM doktorzy WHERE pesel={pesel}");
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
                    if(connection.UpdateInfo($"UPDATE doktorzy SET telefon={phoneNumber}, gabinet={room}, godziny=\"{hour}\" WHERE idd={FormLogin.doctor.Id}")) { return true; }
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
                    if (connection.UpdateInfo($"UPDATE pacjenci SET telefon={phoneNumber}, adres=\"{address}\" WHERE idp={FormLogin.patient.Id}")) { return true; }
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
                    Patient result = connection.GetPatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM pacjenci WHERE pesel={pesel}");
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
        public List<Appointment> GetAppointments()
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    string whereClause;

                    if (FormLogin.position == Position.pacjent)
                    {
                        whereClause = $"pacjenci.idp={FormLogin.patient.Id}";
                    }
                    else
                    {
                        whereClause = $"doktorzy.idd={FormLogin.doctor.Id}";
                    }
                    List<Appointment> result = connection.GetAppointments($"SELECT pacjenci.idp, pacjenci.imie AS pImie, pacjenci.nazwisko AS pNazwisko, pacjenci.pesel AS pPesel, plec, data_urodzenia, adres, pacjenci.telefon AS pTelefon," +
                        $" doktorzy.idd, doktorzy.imie AS dImie, doktorzy.nazwisko AS dNazwisko, doktorzy.pesel AS dPesel, doktorzy.telefon AS dTelefon, doktorzy.gabinet, doktorzy.godziny," +
                        $" wizyty.idw AS idWizyty,wizyty.data, wizyty.opis," +
                        $" (SELECT GROUP_CONCAT(CONCAT(dawki_i_leki.iddl, \"-\", leki.nazwa, \"-\", dawki.ile) SEPARATOR ',') FROM wizyty JOIN wiz_i_dawki_i_leki ON wizyty.idw = wiz_i_dawki_i_leki.idw" +
                            " JOIN dawki_i_leki ON dawki_i_leki.iddl = wiz_i_dawki_i_leki.iddl" +
                            " JOIN dawki ON dawki_i_leki.idd = dawki.idd" +
                            " JOIN leki ON dawki_i_leki.idl = leki.idl" +
                            " WHERE wizyty.idw = idWizyty) AS medicines" +
                        " FROM wizyty" +
                        " JOIN pacjenci ON pacjenci.idp = wizyty.idp" +
                        " JOIN doktorzy ON doktorzy.idd = wizyty.idd" +
                        $" WHERE {whereClause} ORDER BY wizyty.data DESC");

                    return result;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    List<Appointment> result = null;
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
                    List<string> result = connection.GetAppointment($"SELECT pacjenci.pesel, CONCAT(pacjenci.imie, \" \", pacjenci.nazwisko), CONCAT(doktorzy.imie, \" \", doktorzy.nazwisko), wizyty.opis, wizyty.data FROM wizyty JOIN pacjenci ON pacjenci.idp=wizyty.idp JOIN doktorzy ON doktorzy.idd=wizyty.idd WHERE wizyty.idw={id}");

                    result.Add(string.Join("\n", connection.GetPrescription($"SELECT CONCAT(leki.nazwa, \" \", dawki.ile) FROM wizyty JOIN wiz_i_dawki_i_leki ON wizyty.idw=wiz_i_dawki_i_leki.idw JOIN dawki_i_leki ON wiz_i_dawki_i_leki.iddl=dawki_i_leki.iddl JOIN dawki ON dawki_i_leki.idd=dawki.idd JOIN leki ON dawki_i_leki.idl=leki.idl WHERE wizyty.idw={id}").ToArray()));

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
                    List<string> result = connection.GetSpecializations($"SELECT nazwa FROM specjalizacje");

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
                    List<string> result = connection.GetDoctors($"SELECT doktorzy.idd, doktorzy.imie, doktorzy.nazwisko FROM doktorzy JOIN dok_i_spec ON doktorzy.idd=dok_i_spec.idd JOIN specjalizacje ON dok_i_spec.ids=specjalizacje.ids WHERE specjalizacje.nazwa=\"{specialization}\"");

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
                    string result = connection.GetDoctorHours($"SELECT godziny FROM doktorzy WHERE idd={id}");

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
                    if (connection.InsertInfo($"INSERT INTO wizyty (idp, idd, opis, data) VALUES ({FormLogin.patient.Id}, {doctorID}, \"{content}\", \"{date.ToString("yyyy-MM-dd HH:mm:ss")}\")")) { return true; }
                    else { return false; }
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
                }
            }
        }

        // pobiera ID wizyty do edycji
        public int GetAppointmentToEditID(string patientPesel, DateTime date)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<int> appointmentToEdit = connection.GetAppointmentToEdit($"SELECT wizyty.idw FROM wizyty JOIN pacjenci ON wizyty.idp=pacjenci.idp JOIN doktorzy ON wizyty.idd=doktorzy.idd WHERE pacjenci.pesel={patientPesel} AND doktorzy.pesel={FormLogin.doctor.Pesel} AND (wizyty.data BETWEEN \"{date.AddMinutes(-1).ToString("yyyy-MM-dd HH:mm:ss")}\" AND \"{date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm:ss")}\")");
                    int appointmentsForEditCount = appointmentToEdit[0];
                    if ( appointmentsForEditCount == 1) { return appointmentToEdit[1]; }
                    else if (appointmentsForEditCount == 0) { MessageBox.Show("Brak wyników!"); }
                    else { MessageBox.Show("Podana wizyta widnieje 2x w systemie. Proszę zgłosić się do administratora."); }
                    return -1;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return -1;
                }
            }
        }

        // pobiera informacje nt danej recepty (lista leków i dawek)
        public List<string> GetPrescription(int id)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<string> result = connection.GetPrescription($"SELECT dawki_i_leki.iddl, leki.nazwa, dawki.ile FROM `wiz_i_dawki_i_leki` JOIN dawki_i_leki ON dawki_i_leki.iddl=wiz_i_dawki_i_leki.iddl JOIN dawki ON dawki.idd=dawki_i_leki.idd JOIN leki ON leki.idl=dawki_i_leki.idl WHERE idw={id} ORDER BY 2, 3");

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

        // usuwa podane wpisy w recepcie
        public bool DeleteRowsFromPrescription(int id, List<int> rows)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    string inClause = "";
                    if (rows.Count > 0)
                    {
                        inClause = "AND iddl IN (";

                        foreach(var row in rows)
                        {
                            inClause += $"{row}, ";
                        }
                        inClause = inClause.Remove(inClause.Length - 2) + ")";
                    }

                    if(!connection.DeleteInfo($"DELETE FROM wiz_i_dawki_i_leki WHERE idw={id} {inClause}"))
                    {
                        MessageBox.Show("Ups! Coś poszło nie tak, spróbuj ponownie!");
                        return false;
                    }
                    return true;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
                }
            }
        }

        public bool UpdateAppointmentInfo(int id, string content)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    if (connection.UpdateInfo($"UPDATE wizyty SET opis=\"{content}\" WHERE idw={id}"))
                    {
                        return true;
                    }
                    return false;
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
