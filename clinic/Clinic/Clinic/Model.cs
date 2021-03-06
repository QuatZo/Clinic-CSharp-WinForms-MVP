﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    // Wszystkie metody wszystkich widoków
    class Model
    {
        #region Fields
        private readonly DatabaseConnection connection = DatabaseConnection.Instance;
        private readonly FormLogin formLogin = FormLogin.Instance;
        #endregion

        #region Patient methods
        // aktualizuje dane pacjenta i zwraca czy zostaly zaktualizowane
        public bool UpdatePatientInfo(string phoneNumber, string address)
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@phone", phoneNumber},
                    { "@address", address },
                    { "@id", formLogin.Patient.Id.ToString() }
                };

                if (connection.UpdateInfo($"UPDATE pacjenci SET telefon=@phone, adres=@address WHERE idp=@id", parameters)) {
                    connection.Close();
                    return true;
                }
                else {
                    connection.Close();
                    return false;
                }
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // pobiera informacje pacjenta i wrzuca je do klasy Patient
        public Patient GetPatientInfo(string pesel)
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@pesel", pesel }
                };

                Patient result = connection.GetPatientInfo($"SELECT idp, imie, nazwisko, pesel, plec, data_urodzenia, adres, telefon FROM pacjenci WHERE pesel=@pesel", parameters);
                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }
        #endregion

        #region Doctor methods
        // pobiera informacje lekarza i wrzuca je do klasy Doctor
        public Doctor GetDoctorInfo(string pesel)
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@pesel", pesel }
                };

                Doctor result = connection.GetDoctorInfo($"SELECT idd, imie, nazwisko, pesel, telefon, gabinet, godziny FROM doktorzy WHERE pesel=@pesel", parameters);
                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // aktualizuje dane lekarza i zwraca czy zostaly zaktualizowane
        public bool UpdateDoctorInfo(string phoneNumber, string hour, int room)
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@phone", phoneNumber },
                    { "@room", room.ToString() },
                    { "@hour", hour },
                    { "@id", formLogin.Doctor.Id.ToString() }
                };
                if (connection.UpdateInfo($"UPDATE doktorzy SET telefon=@phone, gabinet=@room, godziny=@hour WHERE idd=@id", parameters))
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    connection.Close();
                    return false;
                }
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // pobiera lekarzy, ktorzy posiadaja dana specjalizacje (panel rejestracji wizyty)
        public List<string> GetDoctors(string specialization)
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@specialization", specialization }
                };
                List<string> result = connection.GetDoctors($"SELECT doktorzy.idd AS idd, doktorzy.imie AS imie, doktorzy.nazwisko AS nazwisko FROM doktorzy " +
                    $"JOIN dok_i_spec ON doktorzy.idd=dok_i_spec.idd JOIN specjalizacje ON dok_i_spec.ids=specjalizacje.ids WHERE specjalizacje.nazwa=@specialization", parameters);

                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // pobiera w jakich godzinach przyjmuje wybrany lekarz (panel rejestracji wizyty)
        public string GetDoctorHours(string id)
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@id", id }
                };
                string result = connection.GetDoctorHours($"SELECT godziny FROM doktorzy WHERE idd=@id", parameters);
                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // pobiera liste specjalizacji lekarzy (panel rejestracji wizyty)
        public List<string> GetSpecializations()
        {
            if (connection.Open())
            {
                List<string> result = connection.GetSpecializations($"SELECT nazwa FROM specjalizacje", new Dictionary<string, string>());

                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }
        #endregion

        #region Appointment methods
        // pobiera informacje nt wizyt, w zaleznosci od zalogowanej osoby
        public List<Appointment> GetAppointments()
        {
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                string whereClause;

                if (formLogin.Position == Position.pacjent)
                {
                    whereClause = $"pacjenci.idp=@id";
                    parameters.Add("@id", formLogin.Patient.Id.ToString());
                }
                else
                {
                    whereClause = $"doktorzy.idd=@id";
                    parameters.Add("@id", formLogin.Doctor.Id.ToString());
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

                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // zapisuje nową wizytę do bazy danych
        public bool RegisterAppointment(string doctorID, string content, DateTime date)
        {
            if (connection.Open())
            {
                Dictionary<string, string> selectCountParameters = new Dictionary<string, string>()
                {
                    { "@idp", formLogin.Patient.Id.ToString() },
                    { "@idd", doctorID.ToString() },
                    { "@datebefore", date.AddMinutes(-30).ToString("yyyy-MM-dd HH:mm:ss")},
                    { "@dateafter", date.AddMinutes(30).ToString("yyyy-MM-dd HH:mm:ss")}
                };

                Dictionary<string, string> insertParameters = new Dictionary<string, string>()
                {
                    { "@idp", formLogin.Patient.Id.ToString() },
                    { "@idd", doctorID.ToString() },
                    { "@content", content },
                    { "@date", date.ToString("yyyy-MM-dd HH:mm:ss")}
                };

                if(connection.SelectCount($"SELECT COUNT(*) FROM wizyty WHERE wizyty.data BETWEEN @datebefore AND @dateafter AND idp=@idp AND idd=@idd", selectCountParameters) == 0)
                {
                    if (connection.InsertInfo($"INSERT INTO wizyty (idp, idd, opis, data) VALUES (@idp, @idd, @content, @date)", insertParameters))
                    {
                        connection.Close();
                        return true;
                    }
                    connection.Close();
                    return false;
                }
                connection.Close();
                throw new CustomExceptions.DoctorIsBusyAtThisTimeException();
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
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
            }
            catch (NullReferenceException) { }
            return -1;
        }

        // aktualizuje info o wizycie
        public bool UpdateAppointmentInfo(int id, string content)
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
                    connection.Close();
                    return true;
                }
                connection.Close();
                return false;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
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

                    if (formLogin.Position == Position.pacjent) { str += $"{appointment.Doctor.Name} {appointment.Doctor.Surname} - "; }
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
            if (connection.Open())
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>()
                {
                    { "@id", id.ToString()}
                };

                List<string> result = connection.GetPrescription($"SELECT dawki_i_leki.iddl, leki.nazwa, dawki.ile FROM `wiz_i_dawki_i_leki` JOIN dawki_i_leki ON dawki_i_leki.iddl=wiz_i_dawki_i_leki.iddl JOIN dawki ON dawki.idd=dawki_i_leki.idd JOIN leki ON leki.idl=dawki_i_leki.idl WHERE idw=@id ORDER BY 2, 3", parameters);

                connection.Close();
                return result;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
            }
        }

        // usuwa podane wpisy w recepcie
        public bool DeleteRowsFromPrescription(int id, List<int> rows)
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
                    connection.Close();
                    return false;
                }
                connection.Close();
                return true;
            }
            else
            {
                throw new CustomExceptions.DatabaseConnectionFailedException();
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
