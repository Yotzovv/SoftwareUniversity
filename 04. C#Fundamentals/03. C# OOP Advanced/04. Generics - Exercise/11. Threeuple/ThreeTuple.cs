using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Threeuple
{
    public class ThreeTuple<A, B, C>
    {
        public A first { get; set; }
        public B second { get; set; }
        public C third { get; set; }

        public ThreeTuple(A first, B second, C third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        public override string ToString()
        {
            return $"{this.first} -> {this.second} -> {this.third}";
        }
    }
}
