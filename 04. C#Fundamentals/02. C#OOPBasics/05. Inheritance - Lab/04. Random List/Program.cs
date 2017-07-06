using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            List<string> yeyy = new List<string>();
            yeyy.Add("yeeey");
            yeyy.Add("heyy");
            yeyy.Add("neyy");
            yeyy.Add("Ima lyrical spiritual mirical lyrical");

            Console.WriteLine(RandomList.RandomString(yeyy));
        }
    }
