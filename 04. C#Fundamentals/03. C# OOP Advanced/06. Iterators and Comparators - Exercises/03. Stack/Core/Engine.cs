using _03.Stack.Models;
using System;
using System.Linq;

namespace _03.Stack.Core
{
    public class Engine
    {
        private MyStack<int> stack;

        public Engine()
        {
            stack = new MyStack<int>();
        }

        public void Run()
        {
            string input;

            while((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string cmd = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                switch(cmd)
                {
                    case "Push":
                        this.stack.Push(tokens.Select(int.Parse).ToList());
                        break;
                    case "Pop":
                        this.stack.Pop();
                        break;
                }
            }

            this.stack.Print();
        }
    }
}
