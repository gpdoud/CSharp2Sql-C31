using Microsoft.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2Sql {
    
    public class Connection {

        public SqlConnection sqlconnection { get; set; }

        public void Connect(string database) {
            var connStr = $"server=localhost\\sqlexpress;" +
                            $"database={database};" +
                            $"trusted_connection=true;";
            sqlconnection = new SqlConnection(connStr);
            sqlconnection.Open();
            if(sqlconnection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection did not open!");
            }
        }

        public void Disconnect() {
            sqlconnection.Close();
        }
    }
}
