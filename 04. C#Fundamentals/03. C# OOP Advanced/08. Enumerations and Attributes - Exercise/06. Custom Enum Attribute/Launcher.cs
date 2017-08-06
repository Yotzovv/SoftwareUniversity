using _06.Custom_Enum_Attribute.Attributes;
using System;

namespace _06.Custom_Enum_Attribute
{
    class Launcher
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "Rank")
            {
                PrintAttribute(typeof(Ranks));
            }
            else
            {
                PrintAttribute(typeof(Suits));
            }
        }

        public static void PrintAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(false);

            Console.WriteLine(attributes[0]);
        }
    }
}
