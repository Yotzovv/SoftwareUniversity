using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = string.Empty;

            while(!(time = Console.ReadLine()).Equals("END"))
            {
                var hour = Regex.Match(time, "[0-9]+|[a-zA-Z]+");
                var minutes = hour.NextMatch();
                var seconds = minutes.NextMatch();

                if(int.Parse(hour.ToString()) >= 0 && int.Parse(hour.ToString()) <= 11)
                {
                    if(int.Parse(minutes.ToString()) >= 0 && int.Parse(minutes.ToString()) <= 59)
                    {
                        if(int.Parse(seconds.ToString()) >= 0 && int.Parse(seconds.ToString()) <= 59)
                        {
                            Console.WriteLine("valid");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
