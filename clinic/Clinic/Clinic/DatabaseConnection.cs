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

        public DatabaseConnection(string server, string database, string userID, string passwd)
        {
            this.server = server;
            this.database = database;
            this.userID = userID;
            this.passwd = passwd;

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

        public List<Patient> QueryPatients(string name)
        {
            using (var cmd = new MySqlCommand(name, connection))
            {
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Patient> patients = new List<Patient>();

                List<string> record = new List<string>();

                while (reader.Read())
                {
                    Patient pat = new Patient(Int32.Parse(reader[0].ToString()), reader[2].ToString(), reader[3].ToString(), Double.Parse(reader[1].ToString()), reader[6].ToString(), reader[5].ToString());

                    patients.Add(pat);
                }

                return patients;
            }
        }
    }
}
