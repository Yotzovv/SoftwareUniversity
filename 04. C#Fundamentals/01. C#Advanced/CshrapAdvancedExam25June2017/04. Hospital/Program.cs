using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    public class Program
    {
        static List<Department> departments = new List<Department>();
        static List<Doctor> doctors = new List<Doctor>();

        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "Output")
            {
                try
                {
                    var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var department = departments.Any(d => d.Name == tokens[0]) ? departments.First(d => d.Name == tokens[0]) : new Department(tokens[0]);
                    var doctor = doctors.Any(d => d.Name == tokens[1] && d.Surname == tokens[2]) ? doctors.First(d => d.Name == tokens[1] && d.Surname == tokens[2]) : new Doctor(tokens[1], tokens[2]);
                    var patient = new Patient(tokens[3], doctor);

                    Refresh(tokens, department, doctor, patient);
                }
                catch { }
            }

            Output();
        }

        private static void Refresh(string[] tokens, Department department, Doctor doctor, Patient patient)
        {
            if (!departments.Any(d => d.Rooms.Any(r => r.Patients.Any(p => p.Name == patient.Name))))
            {
                department.SettlePatient(patient);

                if (departments.Any(d => d.Name == tokens[0]))
                {
                    departments[departments.IndexOf(departments.First(d => d.Name == tokens[0]))] = department;
                }
                else
                {
                    departments.Add(department);
                }

                if (doctors.Contains(doctor))
                {
                    doctors[doctors.IndexOf(doctor)].AddPatient(patient);
                }
                else
                {
                    doctor.AddPatient(patient);
                    doctors.Add(doctor);
                }
            }
        }

        private static void Output()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    switch (tokens.Length)
                    {
                        case 1:
                            PrintDepartment(tokens[0]);
                            break;
                        case 2:
                            if (tokens[1].Length == 1 && char.IsDigit(char.Parse(tokens[1])))
                            {
                                PrintRoom(tokens[0], int.Parse(tokens[1]));
                            }
                            else
                            {
                                PrintDoctor(tokens[0], tokens[1]);
                            }
                            break;
                    }
                }
                catch { }
            }
        }


        private static void PrintDoctor(string name, string surname)
        {
            doctors.First(n => n.Name == name && n.Surname == surname)
                   .Patients
                   .OrderBy(n => n.Name)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.Name));
        }

        private static void PrintRoom(string dep, int id)
        {
            departments.First(d => d.Name == dep)
                       .Rooms
                       .FirstOrDefault(r => r.Id == id)
                       .Patients
                       .OrderBy(n => n.Name)
                       .ToList()
                       .ForEach(p => Console.WriteLine(p.Name));
        }

        private static void PrintDepartment(string dep)
        {
            var rooms = departments.First(n => n.Name == dep).Rooms;

            foreach (var room in rooms)
            {
                foreach (var patient in room.Patients)
                {
                    Console.WriteLine(patient);
                }
            }
        }
    }



    public class Room
    {
        private List<Patient> patients;

        public Room(int id)
        {
            Id = id;
            patients = new List<Patient>();
        }

        public int Id { get; set; }

        public List<Patient> Patients { get { return this.patients; } private set { patients = value; } }

        public void AddPatient(Patient patient)
        {
            if (patients.Count < 3)
            {
                patients.Add(patient);
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, patients);
        }
    }

    public class Department
    {
        private List<Room> rooms;

        public Department(string name)
        {
            Name = name;
            rooms = new List<Room>();

            for (int i = 1; i <= 20; i++)
            {
                rooms.Add(new Room(i));
            }
        }

        public List<Room> Rooms { get { return rooms; } private set { rooms = value; } }

        public string Name { get; set; }

        public void SettlePatient(Patient patient)
        {
            if (!rooms.Any(r => r.Patients.Contains(patient) && rooms.Any(x => x.Patients.Count < 3)))
            {
                rooms.First(r => r.Patients.Count < 3).AddPatient(patient);
            }
        }
    }

    public class Doctor
    {
        private List<Patient> patients;

        public Doctor(string name, string surname)
        {
            Name = name;
            Surname = surname;
            patients = new List<Patient>();
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<Patient> Patients { get { return patients; } private set { patients = value; } }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
    }

    public class Patient
    {
        public Patient(string name, Doctor doctor)
        {
            Name = name;
            Doctor = doctor;
        }

        public string Name { get; set; }

        Doctor Doctor { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

