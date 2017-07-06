using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Drawing_tool
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            int width = 0;
            int height = 0;

            Square square = null;

            switch (input)
            {
                case "Square":
                    width = int.Parse(Console.ReadLine());
                    square = new Square(width);
                    break;
                case "Rectangle":
                    width = int.Parse(Console.ReadLine());
                    height = int.Parse(Console.ReadLine());
                    square = new Rectangle(width, height);
                    break;
                default:
                    break;
            }

            CorDraw corDraw = new CorDraw(square);
            corDraw.Figure.Draw();
        }
    }
}
