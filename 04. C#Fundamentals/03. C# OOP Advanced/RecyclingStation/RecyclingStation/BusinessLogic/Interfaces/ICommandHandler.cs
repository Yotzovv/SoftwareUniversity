using RecyclingStation.BusinessLogic.Models;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLogic.Contracts.Core
{
    public interface ICommandHandler
    {
        IGarbageProcessor GarbageProcessor { get; }

        IBalanceManager BalanceManager { get; }

        string ProcessGarbage(string[] parameters);

        string ChangeManagementRequirement(string[] parameters);

        string Status();
    }
}
