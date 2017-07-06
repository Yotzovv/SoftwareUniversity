using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Office_Stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var companies = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { '|', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string company = input[0];
                int amount = int.Parse(input[1]);
                string product = $"{input[2]}";

                if(!companies.ContainsKey(company))
                {
                    companies[company] = new Dictionary<string, int>();
                    companies[company][product] = 0;
                }

                if(!companies[company].ContainsKey(product))
                {
                    companies[company].Add(product, 0);
                }

                companies[company][product] += amount;
            }

            foreach (var company in companies.OrderBy(a => a.Key).ThenBy(s => s.Value.Values))
            {
                Console.Write(company.Key + ": ");

                Console.WriteLine($"{string.Join(", ", companies[company.Key].Select(k => k.Key + "-" + k.Value))}");
                Console.WriteLine();
            }
        }
    }
}
