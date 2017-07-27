using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class Engine
    {
        ListyIterator iterator;

        public Engine()
        {
            this.iterator = new ListyIterator();
        }

        public void Run()
        {
            string command;

            while((command = Console.ReadLine()) != "END")
            {
                DistributeCommands(command);
            }
        }

        private void DistributeCommands(string cmd)
        {
            if (cmd.Split()[0] == "Create")
            {
                this.iterator.Create(new List<string>(cmd.Split().ToList()));
            }

            switch (cmd)
            {
                case "Move":
                    this.OutputWriter(this.iterator.Move().ToString());
                    break;
                case "HasNext":
                    this.OutputWriter(this.iterator.HasNext().ToString());
                    break;
                case "Print":
                    this.iterator.Print();
                    break;
            }
        }

        private void OutputWriter(string arg) => Console.WriteLine(arg);
    }
}