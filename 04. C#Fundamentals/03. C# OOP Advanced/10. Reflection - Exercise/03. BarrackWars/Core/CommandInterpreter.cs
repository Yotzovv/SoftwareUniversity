using _03BarracksFactory.Contracts;
using System;
using System.Globalization;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter
    {
        public static string InterpredCommand(string[] data, string commandName)
        {
            string commandCompleteName = $"_03BarracksFactory.Core.Commands.{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName)}Command";

            Type commandType = Type.GetType(commandCompleteName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] cmdParams = { data };

            IExecutable currentCommand = Activator.CreateInstance(commandType, data) as IExecutable;

            return currentCommand.Execute();
        }
    }
}
