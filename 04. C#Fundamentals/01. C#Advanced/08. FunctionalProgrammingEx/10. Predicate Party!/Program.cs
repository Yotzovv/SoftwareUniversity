using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd;
            string[] guests = Console.ReadLine()
                                     .Split()
                                     .ToArray();

            Func<string, string[]> startsWith = n => guests.Where(g => g.Substring(0, n.Length) == n)
                                                           .ToArray();
            Func<string, string[]> endsWith = n => guests.Where(g => g.EndsWith(n))
                                                        .ToArray();
            Func<int, string[]> withLength = l => guests.Where(g => g.Length == l)
                                                        .ToArray();

            while((cmd = Console.ReadLine().Split().ToArray())[0] != "Party!")
            {
                switch (cmd[0])
                {
                    case "Double":
                        switch(cmd[1])
                        {
                            case "StartsWith":
                                guests = guests.Concat(startsWith(cmd[2])).ToArray();
                                break;
                            case "EndsWith":
                                var sss = endsWith(cmd[2]);
                                guests = guests.Concat(endsWith(cmd[2])).ToArray();
                                break;
                            case "Length":
                                guests = guests.Concat(withLength(int.Parse(cmd[2]))).ToArray();
                                break;
                        }
                        break;
                    case "Remove":
                        switch(cmd[1])
                        {
                            case "StartsWith":
                                guests = guests.Where(g => !startsWith(cmd[2]).Contains(g)).ToArray();
                                break;
                            case "EndsWith":
                                guests = guests.Where(g => !endsWith(cmd[2]).Contains(g)).ToArray();
                                break;
                            case "Length":
                                guests = guests.Where(g => !withLength(int.Parse(cmd[2])).Contains(g)).ToArray();
                                break;
                        }
                        break;
                }
            }

            Console.WriteLine(guests.Count() > 0 ? string.Join(", ", guests.OrderBy(x => x)) + " are going to the party!" : "Nobody is going to the party!");
        }
    }
}
