namespace _03.Detail_Printer
{
    public class Employee
    {
        private string name;

        public Employee(string name)
        {
            this.name = name;
        }

        public override string ToString() => $"Name: {this.name}";
    }
}