using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Rectangle_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < n[0]; i++)
            {
                string[] input = Console.ReadLine().Split();

                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double x = double.Parse(input[3]);
                double y = double.Parse(input[4]);

                rectangles.Add(new Rectangle(id, width, height, x, y));
            }

            for (int i = 0; i < n[1]; i++)
            {
                string[] input = Console.ReadLine().Split();
                Rectangle r1 = rectangles.FirstOrDefault(id => id.Id == input[0]);
                Rectangle r2 = rectangles.FirstOrDefault(id => id.Id == input[1]);
                Console.WriteLine(r1.Intersects(r2).ToString().ToLower());
            }
        }        
    }
}
