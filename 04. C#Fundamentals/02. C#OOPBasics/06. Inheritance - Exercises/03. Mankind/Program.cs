using _03.Mankind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = input[0];
                string lastName = input[1];
                string facultyNum = input[2];
                Student student = new Student(firstName, lastName, facultyNum);

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                firstName = input[0];
                lastName = input[1];
                decimal salary = decimal.Parse(input[2]);
                int wrokingHours = int.Parse(input[3]);
                Worker worker = new Worker(firstName, lastName, salary, wrokingHours);

                Console.Write(student);
                Console.Write(worker);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
