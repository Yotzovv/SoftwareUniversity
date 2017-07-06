using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Drawing_tool
{
    public class Rectangle : Square
    {
        private int height;

        public Rectangle(int width, int height) : base(width)
        {
            this.Width = width;
            this.height = height;
        }

        public int Height { get { return this.height; } set { this.height = value; } }

        public override void Draw()
        {
            Console.WriteLine("|" + new string('-', this.Width) + "|");

            for (int i = 1; i < this.Height - 1; i++)
            {
                Console.WriteLine("|" + new string(' ', this.Width) + "|");
            }

            if (this.Height > 1)
            {
                Console.WriteLine("|" + new string('-', this.Width) + "|");
            }
        }
    }
}
