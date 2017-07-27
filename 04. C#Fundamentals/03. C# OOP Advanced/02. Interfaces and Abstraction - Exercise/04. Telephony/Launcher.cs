using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Telephony
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string[] phonenumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();
            Smartphone smartphone = new Smartphone();
            
            foreach (var number in phonenumbers)
            {
                smartphone.Call(number);
            }

            foreach (var website in websites)
            {
                smartphone.Visit(website);
            }
        }
    }
}
