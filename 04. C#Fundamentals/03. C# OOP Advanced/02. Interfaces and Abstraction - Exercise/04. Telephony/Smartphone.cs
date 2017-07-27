using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public void Call(string phonenumber)
        {
            Console.WriteLine(!phonenumber.All(char.IsDigit) ? "Invalid number!" : $"Calling... {phonenumber}");
        }

        public void Visit(string website)
        {
            Console.WriteLine(website.Any(char.IsDigit) ? "Invalid URL!" : $"Browsing: {website}!");
        }
    }
}
