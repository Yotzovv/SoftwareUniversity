using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Mordor_s_Cruelty_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            Human gandalf = new Human("Gandalf");
            string[] foods = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var f in foods)
            {
                Food food = new Food(f);
                gandalf.Eat(food);
            }

            Console.WriteLine(gandalf.Mood.Points);
            Console.WriteLine(gandalf.Mood.MoodName);
        }
    }
}
