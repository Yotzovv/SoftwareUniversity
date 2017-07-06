using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[\+359]{4}(-| )[0-9]{1}\1[0-9]{3}\1[0-9]{4}$";
            string phoneNumber = string.Empty;

            while ((phoneNumber = Console.ReadLine()) != "end")
            {
                var match = Regex.Match(phoneNumber, pattern);

                if (match.Success)
                {
                    Console.WriteLine(match);
                }
            }
        }
    }
}
