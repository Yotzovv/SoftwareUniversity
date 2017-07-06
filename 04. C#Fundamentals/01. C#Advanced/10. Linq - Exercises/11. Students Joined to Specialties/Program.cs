using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Students_Joined_to_Specialties
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            List<StudentSpecialty> specialities = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();

            while ((input = Console.ReadLine().Split())[0] != "Students:")
            {
                string specialtyName = input[0] + " " + input[1];
                string facultyNumber = input[2];

                specialities.Add(new StudentSpecialty(specialtyName, facultyNumber));
            }

            while((input = Console.ReadLine().Split())[0] != "END")
            {
                string factulyNumber = input[0];
                string firstName = input[1];
                string lastName = input[2];

                students.Add(new Student(firstName, lastName, factulyNumber));
            }

            var output = students.Join(specialities, s => s.FacultyNumber,
                                                     x => x.FacultyNumber, (st, spec) => 
                                                     new { FirstName = st.firstName, LastName = st.lastName, FacultyNumber = st.FacultyNumber, Speciality = spec.SpecialtyName }).ToList();

            foreach (var student in output.OrderBy(st => st.FirstName))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.FacultyNumber} {student.Speciality}");
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, string facultyNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.FacultyNumber = facultyNumber;
        }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string FacultyNumber { get; set; }
    }

    class StudentSpecialty
    {
        public StudentSpecialty(string specialtyName, string facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }
        public string SpecialtyName { get; set; }

        public string FacultyNumber { get; set; }
    }
}
