using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd;
            Stack<string> guests = new Stack<string>(Console.ReadLine().Split().ToArray());

            Func<string, string[]> startsWith = n => guests.Where(g => g.Substring(0, n.Length) == n)
                                                           .ToArray();
            Func<string, string[]> endsWith = n => guests.Where(g => g.EndsWith(n))
                                                        .ToArray();
            Func<int, string[]> withLength = l => guests.Where(g => g.Length == l)
                                                        .ToArray();

            while ((cmd = Console.ReadLine().Split(';').ToArray())[0] != "Party!")
            {
                string g = guests.Peek();

                switch (cmd[0])
                {
                    case "Add filter":
                        switch (cmd[1])
                        {
                            case "StartsWith":
                                guests.Push(guests.Concat(startsWith(cmd[2])).ToString());
                                break;
                            case "EndsWith":
                                var sss = endsWith(cmd[2]);
                                guests.Push(guests.Concat(endsWith(cmd[2])).ToString());
                                break;
                            case "Length":
                                guests.Push(guests.Concat(withLength(int.Parse(cmd[2]))).ToString());
                                break;
                        }
                        break;
                    case "Remove filter":
                        switch (cmd[1])
                        {
                            case "StartsWith":
                                guests.Push(guests.Where(g => !startsWith(cmd[2]).Contains(g)).ToString());
                                break;
                            case "EndsWith":
                                guests.Push(guests.Where(g => !endsWith(cmd[2]).Contains(g)).ToString());
                                break;
                            case "Length":
                                guests.Push(guests.Where(g => !withLength(int.Parse(cmd[2])).Contains(g)).ToString());
                                break;
                        }
                        break;
                }
            }
        }
    }
}
