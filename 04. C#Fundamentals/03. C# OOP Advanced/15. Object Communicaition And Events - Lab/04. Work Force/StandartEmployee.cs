namespace _04.Work_Force
{
    public class StandartEmployee : Employee
    {
        private const int WorkHoursPerWeek = 40;

        public StandartEmployee(string name) : base(name, WorkHoursPerWeek)
        {
        }
    }
}
