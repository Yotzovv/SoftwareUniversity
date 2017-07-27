using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Tuple
{
    public class MyTuple<A, B>
    {
        public A first { get; set; }
        public B second { get; set; }

        public MyTuple(A first, B second)
        {
            this.first = first;
            this.second = second;
        }

        public override string ToString()
        {
            return $"{this.first} -> {this.second}";
        }
    }
}
