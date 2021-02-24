using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    
    public class MajorsController {

        private Connection connection { get; set; }

        public bool Remove(int id) {
            var sql = $"DELETE Major " +
                        $" Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }
        public bool Change(Major major) {
            var sql = $"UPDATE Major Set " +
                        $" Code = @code, " +
                        $" Description = @description, " +
                        $" MinSAT = @minsat " +
                        $" Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@code", major.Code);
            cmd.Parameters.AddWithValue("@description", major.Description);
            cmd.Parameters.AddWithValue("@minsat", major.MinSAT);
            cmd.Parameters.AddWithValue("@id", major.Id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }
        public bool Create(Major major) {
            var sql = $"INSERT into Major (Code, Description, MinSAT) " +
                        $" VALUES (@code, @description, @minsat);";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@code", major.Code);
            cmd.Parameters.AddWithValue("@description", major.Description);
            cmd.Parameters.AddWithValue("@minsat", major.MinSAT);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }
        public Major GetByPK(int id) {
            var sql = "SELECT * From Major Where Id = @Id ";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            cmd.Parameters.AddWithValue("@Id", id);
            var reader = cmd.ExecuteReader();
            var majors = new List<Major>();
            if(!reader.Read()) {
                reader.Close();
                return null;
            }
            var major = new Major();
            major.Id = Convert.ToInt32(reader["Id"]);
            major.Code = reader["Code"].ToString();
            major.Description = reader["Description"].ToString();
            major.MinSAT = Convert.ToInt32(reader["MinSAT"]);
            majors.Add(major);
            
            reader.Close();
            return major;
        }
        public List<Major> GetAll() {
            var sql = "SELECT * From Major ";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var majors = new List<Major>();
            while(reader.Read()) {
                var major = new Major();
                major.Id = Convert.ToInt32(reader["Id"]);
                major.Code = reader["Code"].ToString();
                major.Description = reader["Description"].ToString();
                major.MinSAT = Convert.ToInt32(reader["MinSAT"]);
                majors.Add(major);
            }
            reader.Close();
            return majors;
        }

        public MajorsController(Connection connection) {
            this.connection = connection;
        }
    }
}
