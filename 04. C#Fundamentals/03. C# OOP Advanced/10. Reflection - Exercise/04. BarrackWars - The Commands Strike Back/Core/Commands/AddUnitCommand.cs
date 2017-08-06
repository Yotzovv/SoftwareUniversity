using System;
using _03BarracksFactory.Contracts;

namespace _04.BarrackWars___The_Commands_Strike_Back.Core.Commands
{
    public class AddUnitCommand : Command
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public AddUnitCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unit = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unit);

            return $"{unitType} added!";
        }
    }
}
