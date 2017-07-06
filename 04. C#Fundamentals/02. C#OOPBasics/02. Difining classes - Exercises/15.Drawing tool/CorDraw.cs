using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Drawing_tool
{
    public class CorDraw
    {
        private Square figure;

        public CorDraw(Square figure)
        {
            this.figure = figure;
        }

        public Square Figure { get { return this.figure; }  set { this.figure = value; } }
    }
}
