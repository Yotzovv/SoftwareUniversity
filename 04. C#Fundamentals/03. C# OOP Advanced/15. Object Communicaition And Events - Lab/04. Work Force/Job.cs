using System;

namespace _04.Work_Force
{
    public class Job
    {
        public delegate void JobDoneEventHandler(object sender, JobEventArgs args);
        public event JobDoneEventHandler JobDone;

        public Job(string name, int workHoursRequired, Employee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.Employee = employee;
            this.IsDone = false;
        }

        public string Name { get; private set; }

        public int WorkHoursRequired { get; private set; }

        public Employee Employee { get; private set; }

        public bool IsDone { get; private set; }

        public void Update()
        {
            this.WorkHoursRequired -= Employee.WorkHoursPerWeek;

            if (this.WorkHoursRequired <= 0 && !this.IsDone)
            {
                JobDone?.Invoke(this, new JobEventArgs(this));
            }
        }

        public void OnJobDone(object sender, EventArgs args)
        {
            Console.WriteLine($"Job {this.Name} done!" );
            this.IsDone = true;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
        }

    }
}
