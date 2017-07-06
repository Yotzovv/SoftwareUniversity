using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            stack.Push("yeyyy");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            
        }
    }
