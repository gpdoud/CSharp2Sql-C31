using Microsoft.Data.SqlClient;

using System;

namespace CSharp2Sql {

    public class EducDbLib {

        public SqlConnection connection { get; set; }

        public void SelectAllClasses() {
            var sql = "SELECT * From Class;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var subject = reader["Subject"].ToString();
                var section = reader["Section"].ToString();
                Console.WriteLine($"id={id}|{subject} {section}");
            }
            reader.Close();
        }

        public void SelectAllMajors() {
            var sql2 = "SELECT * From Major;";
            var cmd2 = new SqlCommand(sql2, connection);
            var reader = cmd2.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var desc = reader["Description"].ToString();
                var minsat = Convert.ToInt32(reader["MinSAT"]);
                Console.WriteLine($"{id}|{desc}|{minsat}");
            }
            reader.Close();
        }

        public void SelectAllStudents() {
            var sql = "SELECT * From Student where id < 5;";
            var cmd = new SqlCommand(sql, connection);
            var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                var id = Convert.ToInt32(reader["Id"]);
                var lastname = reader["Lastname"].ToString();
                Console.WriteLine($"id={id}, lastname={lastname}");
            }
            reader.Close();
        }

        public void Connect(string database) {
            var connStr = $"server=localhost\\sqlexpress;" +
                            $"database={database};" +
                            "trusted_connection=true;";
            connection = new SqlConnection(connStr);
            connection.Open();
            if(connection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection is not open!");
            }
        }
        public void Disconnect() {
            connection.Close();
        }
    }
}
