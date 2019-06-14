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
        #region Patient methods
        // aktualizuje dane pacjenta i zwraca czy zostaly zaktualizowane
        public bool UpdatePatientInfo(string phoneNumber, string address)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@phone", phoneNumber},
                        { "@address", address },
                        { "@id", FormLogin.patient.Id.ToString() }
                    };

                    if (connection.UpdateInfo($"UPDATE pacjenci SET telefon=@phone, adres=@address WHERE idp=@id", parameters)) { return true; }
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
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@pesel", pesel }
                    };

                    Patient result = connection.GetPatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM pacjenci WHERE pesel=@pesel", parameters);
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
        #endregion

        #region Doctor methods
        // pobiera informacje lekarza i wrzuca je do klasy Doctor
        public Doctor GetDoctorInfo(string pesel)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@pesel", pesel }
                    };

                    Doctor result = connection.GetDoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM doktorzy WHERE pesel=@pesel", parameters);
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
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@phone", phoneNumber },
                        { "@room", room.ToString() },
                        { "@hour", hour },
                        { "@id", FormLogin.doctor.Id.ToString() }
                    };
                    if (connection.UpdateInfo($"UPDATE doktorzy SET telefon=@phone, gabinet=@room, godziny=@hour WHERE idd=@id", parameters)) { return true; }
                    else { return false; }
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
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
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@specialization", specialization }
                    };
                    List<string> result = connection.GetDoctors($"SELECT doktorzy.idd AS idd, doktorzy.imie AS imie, doktorzy.nazwisko AS nazwisko FROM doktorzy " +
                        $"JOIN dok_i_spec ON doktorzy.idd=dok_i_spec.idd JOIN specjalizacje ON dok_i_spec.ids=specjalizacje.ids WHERE specjalizacje.nazwa=@specialization", parameters);

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
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@id", id }
                    };
                    string result = connection.GetDoctorHours($"SELECT godziny FROM doktorzy WHERE idd=@id", parameters);

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

        // pobiera liste specjalizacji lekarzy (panel rejestracji wizyty)
        public List<string> GetSpecializations()
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    List<string> result = connection.GetSpecializations($"SELECT nazwa FROM specjalizacje", new Dictionary<string, string>());

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
        #endregion

        #region Appointment methods
        // pobiera informacje nt wizyt, w zaleznosci od zalogowanej osoby
        public List<Appointment> GetAppointments()
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();

                    string whereClause;

                    if (FormLogin.position == Position.pacjent)
                    {
                        whereClause = $"pacjenci.idp=@id";
                        parameters.Add("@id", FormLogin.patient.Id.ToString());
                    }
                    else
                    {
                        whereClause = $"doktorzy.idd=@id";
                        parameters.Add("@id", FormLogin.doctor.Id.ToString());
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
                        $" WHERE {whereClause} ORDER BY wizyty.data DESC", parameters);

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
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@id", id}
                    };
                    List<string> result = connection.GetAppointment($"SELECT pacjenci.pesel, CONCAT(pacjenci.imie, \" \", pacjenci.nazwisko), CONCAT(doktorzy.imie, \" \", doktorzy.nazwisko), wizyty.opis, wizyty.data FROM wizyty JOIN pacjenci ON pacjenci.idp=wizyty.idp JOIN doktorzy ON doktorzy.idd=wizyty.idd WHERE wizyty.idw=@id", parameters);

                    result.Add(string.Join(Environment.NewLine, connection.GetPrescription($"SELECT CONCAT(leki.nazwa, \" \", dawki.ile) FROM wizyty JOIN wiz_i_dawki_i_leki ON wizyty.idw=wiz_i_dawki_i_leki.idw JOIN dawki_i_leki ON wiz_i_dawki_i_leki.iddl=dawki_i_leki.iddl JOIN dawki ON dawki_i_leki.idd=dawki.idd JOIN leki ON dawki_i_leki.idl=leki.idl WHERE wizyty.idw=@id", parameters).ToArray()));

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

        // zapisuje nową wizytę do bazy danych
        public bool RegisterAppointment(string doctorID, string content, DateTime date)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Dictionary<string, string> selectCountParameters = new Dictionary<string, string>()
                    {
                        { "@idp", FormLogin.patient.Id.ToString() },
                        { "@idd", doctorID.ToString() },
                        { "@datebefore", date.AddMinutes(-30).ToString("yyyy-MM-dd HH:mm:ss")},
                        { "@dateafter", date.AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss")}
                    };

                    Dictionary<string, string> insertParameters = new Dictionary<string, string>()
                    {
                        { "@idp", FormLogin.patient.Id.ToString() },
                        { "@idd", doctorID.ToString() },
                        { "@content", content },
                        { "@date", date.ToString("yyyy-MM-dd HH:mm:ss")}
                    };

                    if(connection.SelectCount($"SELECT COUNT(*) FROM wizyty WHERE wizyty.data BETWEEN @datebefore AND @dateafter AND idp=@idp AND idd=@idd", selectCountParameters) == 0)
                    {
                        if (connection.InsertInfo($"INSERT INTO wizyty (idp, idd, opis, data) VALUES (@idp, @idd, @content, @date)", insertParameters))
                        {
                            return true;
                        }
                        return false;
                    }
                    MessageBox.Show("Lekarz o tej godzinie jest zajęty! Wybierz inną datę!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    MessageBox.Show("Błąd z połaczeniem!");
                    return false;
                }
            }
        }

        // pobiera ID wizyty do edycji
        public int GetAppointmentToEditID(List<Appointment> appointments, string patientPesel, DateTime date)
        {
            int count = 0;
            int id = -1;
            try
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    if (appointments[i].Patient.Pesel.ToString() == patientPesel && appointments[i].Date >= date.AddMinutes(-1) && appointments[i].Date <= date.AddMinutes(1))
                    {
                        count++;
                        id = i;
                    }
                }
                if (count == 1) { return id; }
                else if (count == 0) { MessageBox.Show("Brak wyników!"); }
                else { MessageBox.Show("Podana wizyta widnieje 2x w systemie. Proszę zgłosić się do administratora."); }
            }
            catch (NullReferenceException) { }
            return -1;
        }

        // aktualizuje info o wizycie
        public bool UpdateAppointmentInfo(int id, string content)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@id", id.ToString() },
                        { "@content", content }
                    };
                    if (connection.UpdateInfo($"UPDATE wizyty SET opis=@content WHERE idw=@id", parameters))
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

        // pobiera główne informacje z wizyty (ID, data, imie + nazwisko pacjenta/lekarza [w zależności od stanowiska osoby zalogowanej], gabinet)
        public List<string> GetAppointmentsMainInfo(List<Appointment> appointments)
        {
            List<string> apps = new List<string>();

            try
            {
                foreach (var appointment in appointments)
                {
                    string str = appointment.Id.ToString() + " - ";
                    str += appointment.Date.ToString("yyyy-MM-dd HH:mm") + " - ";

                    if (FormLogin.position == Position.pacjent) { str += $"{appointment.Doctor.Name} {appointment.Doctor.Surname} - "; }
                    else { str += $"{appointment.Patient.Name} {appointment.Patient.Surname} - "; }

                    str += appointment.Doctor.Room.ToString();

                    apps.Add(str);
                }
                return apps;
            }
            catch (NullReferenceException)
            {
                return new List<string>();
            }
        }
        #endregion

        #region Prescription methods
        // pobiera informacje nt danej recepty (lista leków i dawek)
        public List<string> GetPrescription(int id)
        {
            using (var connection = new DatabaseConnection())
            {
                if (connection.Open())
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@id", id.ToString()}
                    };

                    List<string> result = connection.GetPrescription($"SELECT dawki_i_leki.iddl, leki.nazwa, dawki.ile FROM `wiz_i_dawki_i_leki` JOIN dawki_i_leki ON dawki_i_leki.iddl=wiz_i_dawki_i_leki.iddl JOIN dawki ON dawki.idd=dawki_i_leki.idd JOIN leki ON leki.idl=dawki_i_leki.idl WHERE idw=@id ORDER BY 2, 3", parameters);

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
                        inClause += string.Join(", ", rows.ToArray()) + ")";
                    }
                    Dictionary<string, string> parameters = new Dictionary<string, string>()
                    {
                        { "@id", id.ToString() }
                    };

                    if (!connection.DeleteInfo($"DELETE FROM wiz_i_dawki_i_leki WHERE idw=@id {inClause}", parameters))
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

        public List<int> GetPrescriptionsID(List <string> prescriptions)
        {
            List<int> ids = new List<int>();

            foreach (var el in prescriptions)
            {
                ids.Add(int.Parse(el.Split()[0]));
            }
            return ids;
        }
        #endregion
    }
}
