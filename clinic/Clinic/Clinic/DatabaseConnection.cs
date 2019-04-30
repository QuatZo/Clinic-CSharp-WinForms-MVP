using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    class DatabaseConnection: IDisposable
    {
        private readonly MySqlConnection connection;
        private readonly string server;
        private readonly string database;
        private readonly string userID;
        private readonly string passwd;

        public DatabaseConnection()
        {
            server = "localhost";
            database = "clinic";
            userID = "clinic";
            passwd = "ZZZxxxCCCvvvBBBnnnMMM";

            connection = new MySqlConnection
            {
                ConnectionString = String.Format($"server={server};database={database};uid={userID};password={passwd}")
            };
        }

        public bool Open()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException e){
                Console.WriteLine($"Cannot connect to server: {e}");
                return false;
            }
        }

        public void Close()
        {
            try
            {
                connection.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine($"Cannot disconnect from the server: {e}");
            }
        }

        public void Dispose()
        {
            Close();
        }

        public List<Patient> PatientInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Patient> patients = new List<Patient>();

                List<string> record = new List<string>();

                while (reader.Read())
                {
                    Sexs sex;
                    if(reader[4].ToString() == "Kobieta") { sex=Sexs.kobieta; }
                    else { sex = Sexs.mezczyzna; }

                    Patient pat = new Patient(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Double.Parse(reader[3].ToString()), sex, DateTime.Parse(reader[5].ToString()), reader[6].ToString(), reader[7].ToString());

                    patients.Add(pat);
                }
                return patients;
            }
        }
        public List<Doctor> DoctorInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Doctor> doctors = new List<Doctor>();

                List<string> record = new List<string>();

                while (reader.Read())
                {
                    Hours hours;
                    if (reader[6].ToString() == "poranne") { hours=Hours.poranne; }
                    else if (reader[6].ToString() == "popoludniowe") { hours = Hours.popoludniowe; }
                    else { hours = Hours.wieczorowe; }

                    Doctor pat = new Doctor(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), Double.Parse(reader[3].ToString()), reader[4].ToString(), Int32.Parse(reader[5].ToString()), hours);

                    doctors.Add(pat);
                }
                return doctors;
            }
        }

        public bool UpdateInfo(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                if (cmd.ExecuteNonQuery() > 0) { return true; }
                else { return false; }
            }
        }
    }
}
