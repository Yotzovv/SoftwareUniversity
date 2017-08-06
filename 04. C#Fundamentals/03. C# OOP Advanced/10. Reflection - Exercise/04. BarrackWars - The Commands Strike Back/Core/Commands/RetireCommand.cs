using System;
using _03BarracksFactory.Contracts;

namespace _04.BarrackWars___The_Commands_Strike_Back.Core.Commands
{
    public class RetireCommand : Command
    {
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string unit = this.Data[1];
            this.repository.RemoveUnit(unit);

            return $"{unit} retired!";
        }
    }
}
