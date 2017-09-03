using RecyclingStation.BusinessLogic.Interfaces;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLogic.Contracts.Core
{
    public interface IBalanceManager
    {
        double EnergyBalance { get; }

        double CapitalBalance { get; }

        IManagementRequirement ManagementRequirement { get; set; }

        void ApplyProcessingResult(IProcessingData result);

        bool CheckWasteForProcessing(IWaste waste);
    }
}
