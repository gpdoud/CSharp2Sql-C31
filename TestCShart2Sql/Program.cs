using CSharp2Sql;

using System;

namespace TestCShart2Sql {
    class Program {
        static void Main(string[] args) {

            var conn = new Connection();
            conn.Connect("EdDb");

            var majorsController = new MajorsController(conn);

            var major = new Major { Code = "BAR", Description = "Bar Critic", MinSAT = 800 };
            var rc = majorsController.Create(major);
            Console.WriteLine($"Create Worked - {rc}");
            major.Id = 15;
            major.Description = "Advanced Bar Critic";
            major.MinSAT = 1590;
            rc = majorsController.Change(major);
            Console.WriteLine($"Changed Worked - {rc}");
            major = majorsController.GetByPK(major.Id);
            Console.WriteLine($"GetByPK Worked - {major != null}");
            var majors = majorsController.GetAll();
            foreach(var m in majors) {
                Console.WriteLine($"{m.Id}|{m.Description}|{m.MinSAT}");
            }
            rc = majorsController.Remove(major.Id);
            Console.WriteLine($"Remove Worked - {rc}");

            #region StudentsController Testing
            //var studentController = new StudentsController(conn);

            //var newStudent = new Student {
            //    Id = 0, Firstname = "Joseph", Lastname = "Biden", StateCode = "DC",
            //    SAT = 1350, GPA = 3.7m, Major = null
            //};
            //var success = studentController.Create(newStudent);

            //newStudent.Id = 61;
            //var success = studentController.Change(newStudent);

            //var student = studentController.GetByPK(61);
            //Console.WriteLine($"{student.Id}|{student.Firstname} {student.Lastname}");

            //success = studentController.Remove(61);
            //Console.WriteLine($"Remove worked? {success}");

            //success = studentController.RemoveRange(59, 60, 62);

            //var students = studentController.GetAll();
            //foreach(var s in students) {
            //    Console.WriteLine($"{s.Id}|{s.Firstname} {s.Lastname}|{s.Major}");
            //}

            #endregion

            conn.Disconnect();
        }
    }
}
