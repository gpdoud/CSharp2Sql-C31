using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    
    public class MajorsController {

        private Connection connection { get; set; }

        public bool Remove(int id) {
            return true;
        }
        public bool Change(Major major) {
            return true;
        }
        public bool Create(Major major) {
            return true;
        }
        public Major GetByPK(int id) {
            return null;
        }
        public List<Major> GetAll() {
            var sql = "SELECT * From Major ";
            var cmd = new SqlCommand(sql, connection.sqlconnection);
            var reader = cmd.ExecuteReader();
            var students = new List<Major>();
            while(reader.Read()) {
                var major = new Major();
                major.Id = Convert.ToInt32(reader["Id"]);
                major.Description = reader["Description"].ToString();
                major.MinSAT = Convert.ToInt32(reader["MinSAT"]);
                students.Add(major);
            }
            reader.Close();
            return students;
        }

        public MajorsController(Connection connection) {
            this.connnection = connnection;
        }
    }
}
