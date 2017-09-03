using System;
using RecyclingStation.BusinessLogic.Contracts.Core;
using RecyclingStation.BusinessLogic.Models;
using RecyclingStation.BusinessLogic.Contracts.IO;
using System.Reflection;

namespace RecyclingStation.BusinessLogic.Core
{
    public class Engine : IEngine
    {
        public Engine(ICommandHandler commandHandler, IReader reader, IWriter writer)
        {
            this.CommandHandler = commandHandler;
            this.Reader = reader;
            this.Writer = writer;
        }

        public Engine() : this(new CommandHandler(), new Reader(), new Writer())
        {
        }

        public ICommandHandler CommandHandler { get; private set; }

        public IReader Reader { get; private set; }

        public IWriter Writer { get; private set; }

        public void Run()
        {
            string input;

            while((input = Console.ReadLine()) != "TimeToRecycle")
            {
                var tokens = input.Split();
                string methodName = tokens[0];
                object[] invokeParams = new object[0];

                if(tokens.Length > 1)
                {
                    invokeParams = new object[1];
                    invokeParams[0] = tokens[1].Split('|');                    
                 }

                try
                {
                    MethodInfo method = this.CommandHandler.GetType().GetMethod(methodName);

                    if(methodName == null)
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                     this.Writer.WriteLine((string)method.Invoke(this.CommandHandler, invokeParams));
                }
                catch(ArgumentException e)
                {
                    this.Writer.WriteLine(e.Message);
                }

            }
        }
    }
}
