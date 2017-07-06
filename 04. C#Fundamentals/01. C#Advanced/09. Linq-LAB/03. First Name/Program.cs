using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.First_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                                    .Trim()
                                    .Split()
                                    .ToArray();
            char[] lettters = Console.ReadLine()
                                    .Split()
                                    .Select(char.Parse)
                                    .ToArray();

            bool IsFound = false;

            foreach (var letter in lettters)
            {
                foreach (var name in names)
                {
                    if(name.ToLower()[0] == letter)
                    {
                        Console.WriteLine(name);
                        IsFound = true; 
                        break;
                    }
                }
                if(IsFound)
                {
                    break;
                }
            }

            if(!IsFound)
            {
                Console.WriteLine("No match");
            }
        }
    }
}
