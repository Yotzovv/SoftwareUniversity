namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Globalization;
    using System.Reflection;
    using System.Linq;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string commandCompleteName = $"_03BarracksFactory.Core.Commands.{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName)}Command";

            Type commandType = Type.GetType(commandCompleteName);

            if(commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] cmdParams = { data, this.repository, this.unitFactory };

            IExecutable currentCommand = Activator.CreateInstance(commandType, cmdParams) as IExecutable;

            return currentCommand.Execute();
        }      
    }
}
