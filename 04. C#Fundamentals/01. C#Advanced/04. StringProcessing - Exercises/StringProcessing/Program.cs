using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string student = input[0];
                
                students[student] = new List<double>();

                students[student].Add(double.Parse(input[1]));
                students[student].Add(double.Parse(input[2]));
                students[student].Add(double.Parse(input[3]));
            }

            Console.WriteLine(string.Format(
                    "{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|",
                    "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            foreach (var item in students)
            {
                Console.WriteLine(string.Format(
                    "{0, -10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",
                    item.Key, item.Value[0], item.Value[1], item.Value[2], item.Value.Average()));
            }
        }
    }
}
