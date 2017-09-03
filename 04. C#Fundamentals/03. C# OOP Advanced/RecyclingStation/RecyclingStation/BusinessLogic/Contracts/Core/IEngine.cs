using RecyclingStation.BusinessLogic.Contracts.IO;

namespace RecyclingStation.BusinessLogic.Contracts.Core
{
    public interface IEngine
    {
        ICommandHandler CommandHandler { get; }

        IReader Reader { get; }

        IWriter Writer { get; }

        void Run();
    }
}
