namespace _12.Google
{
    public class Company
    {
        private string name;
        private string department;
        private string salary;

        public Company(string name, string department, string salary)
        {
            this.name = name;
            this.department = department;
            this.salary = salary;
        }

        public Company()
        {
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Department { get { return this.department; } set { this.department = value; } }
        public string Salary { get { return this.salary; } set { this.salary = value; } }

        public override string ToString()
        {
            return $"{name} {department} {salary}";
        }
    }
}