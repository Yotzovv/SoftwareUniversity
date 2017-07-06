using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Drawing_tool
{
    public class Square
    {
        private int width;

        public Square(int width)
        {
            this.width = width;
        }

        public int Width { get { return this.width; } set { this.width = value; } }

        public virtual void Draw()
        {
            Console.WriteLine("|" + new string('-', width) + "|");
            for (int i = 1; i < width - 1; i++)
            {
                Console.WriteLine("|" + new string(' ', width) + "|");
            }
            if (width > 1)
            {
                Console.WriteLine("|" + new string('-', width) + "|");
            }
        }
    }
}
