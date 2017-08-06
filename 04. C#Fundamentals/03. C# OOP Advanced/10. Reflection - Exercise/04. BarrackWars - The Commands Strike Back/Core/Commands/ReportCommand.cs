using System;
using _03BarracksFactory.Contracts;

namespace _04.BarrackWars___The_Commands_Strike_Back.Core.Commands
{
    public class ReportCommand : Command
    {
        private IRepository repository;

        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
            this.repository = repository;
        }

        public override string Execute() => this.Repository.Statistics;
    }
}
