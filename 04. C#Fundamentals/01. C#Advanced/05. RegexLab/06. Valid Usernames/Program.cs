using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = string.Empty;
            bool isValid = true;

            while (!(username = Console.ReadLine()).Equals("END"))
            {
                if (username.Count() < 3 || username.Count() > 16)
                {
                    isValid = false;
                }
                else if (Regex.Match(username, "[^a-zA-Z0-9-_]").Success)
                {
                    isValid = false;
                }

                Console.WriteLine(isValid == true ? "valid" : "invalid");
                isValid = true;
            }
        }
    }
}
