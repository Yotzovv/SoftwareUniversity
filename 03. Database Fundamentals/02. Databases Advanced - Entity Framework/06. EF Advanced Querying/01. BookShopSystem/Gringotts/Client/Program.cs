using Gringotts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts
{
    class Program
    {
        static void Main(string[] args)
        {
            DepositSumForOlivanderFamily();
            //DepositFilter();
        }

        private static void DepositFilter()
        {
            GringottsContext context = new GringottsContext();
            Dictionary<string, decimal> output = new Dictionary<string, decimal>();

            foreach (var group in context.WizzardDeposits.Where(d => d.MagicWandCreator == "Ollivander family").GroupBy(s => s.DepositGroup))
            {
                if (group.Sum(x => x.DepositAmount) < 150000)
                {
                    output[group.Key] = (decimal)group.Sum(x => x.DepositAmount);
                }                
            }

            foreach (var item in output.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        private static void DepositSumForOlivanderFamily()
        {
            GringottsContext context = new GringottsContext();

            foreach (var group in context.WizzardDeposits.Where(d => d.MagicWandCreator == "Ollivander family").GroupBy(s => s.DepositGroup))
            {
                Console.WriteLine($"{group.Key} - {group.Sum(z => z.DepositAmount)}");
            }
        }
    }
}
