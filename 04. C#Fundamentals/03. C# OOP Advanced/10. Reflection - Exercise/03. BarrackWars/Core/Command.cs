using _03BarracksFactory.Contracts;
using System;

namespace _03BarracksFactory.Core
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get { return this.data; }
            private set
            {
                this.data = value;
            }
        }

        public abstract string Execute();
    }
}
