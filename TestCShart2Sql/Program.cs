using CSharp2Sql;

using System;

namespace TestCShart2Sql {
    class Program {
        static void Main(string[] args) {

            var conn = new Connection();
            conn.Connect("EdDb");
            var studentController = new StudentsController(conn);

            var newStudent = new Student {
                Id = 0, Firstname = "Joseph", Lastname = "Biden", StateCode = "DC",
                SAT = 1350, GPA = 3.7m, Major = null
            };
            //var success = studentController.Create(newStudent);

            newStudent.Id = 61;
            var success = studentController.Change(newStudent);

            //var student = studentController.GetByPK(61);
            //Console.WriteLine($"{student.Id}|{student.Firstname} {student.Lastname}");

            success = studentController.Remove(61);
            Console.WriteLine($"Remove worked? {success}");

            success = studentController.RemoveRange(59, 60, 62);
            
            //var students = studentController.GetAll();
            //foreach(var s in students) {
            //    Console.WriteLine($"{s.Id}|{s.Firstname} {s.Lastname}|{s.Major}");
            //}
            conn.Disconnect();
        }
    }
}
