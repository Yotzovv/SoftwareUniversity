using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Work_Force
{
    class Program
    {
        public delegate void JobDoneEventHandler(object sender, JobEventArgs args);

        static void Main(string[] args)
        {
            JobsList jobs = new JobsList();
            List<Employee> employees = new List<Employee>();

            string[] input = Console.ReadLine().Split();

            while(input[0] != "End")
            {
                switch(input[0])
                {
                    case "Job":
                       Job job = new Job(input[1], int.Parse(input[2]), employees.FirstOrDefault(e => e.Name == input[3]));
                        job.JobDone += job.OnJobDone;
                        jobs.Add(job);
                       break;
                    case "StandartEmployee":
                        employees.Add(new StandartEmployee(input[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(input[1]));
                        break;
                    case "Pass":
                        jobs.ForEach(j => j.Update());
                        break;
                    case "Status":
                        jobs.Where(d => !d.IsDone).ToList().ForEach(j => Console.WriteLine(j));
                        break;

                }

                input = Console.ReadLine().Split();
            }

        }
    }
}
