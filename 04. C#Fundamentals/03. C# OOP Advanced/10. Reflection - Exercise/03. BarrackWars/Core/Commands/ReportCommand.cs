using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Attributes;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;


        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
