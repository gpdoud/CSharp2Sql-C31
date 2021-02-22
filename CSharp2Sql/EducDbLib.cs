using Microsoft.Data.SqlClient;

using System;

namespace CSharp2Sql {

    public class EducDbLib {

        public SqlConnection connection { get; set; }

        public void ExecSelect() {
            var sql = "SELECT * From Student;";
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
