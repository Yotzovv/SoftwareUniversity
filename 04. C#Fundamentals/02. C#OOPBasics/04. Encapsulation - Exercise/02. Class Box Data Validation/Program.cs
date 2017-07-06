using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.Class_Box_Data_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            Console.WriteLine(fields.Count());

            try
            {
                Box box = new Box(l, w, h);
                Console.WriteLine(box);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
