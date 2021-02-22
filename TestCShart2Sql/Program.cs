using CSharp2Sql;

using System;

namespace TestCShart2Sql {
    class Program {
        static void Main(string[] args) {

            var sql = new EducDbLib();
            sql.Connect("EdDb");
            Console.WriteLine("Connected successfully!");
            sql.ExecSelect();
            sql.Disconnect();
        }
    }
}
