using RecyclingStation.BusinessLogic.Interfaces;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.BusinessLogic.Contracts.Core
{
    public class BalanceManager : IBalanceManager
    {
        public BalanceManager()
        {
            this.EnergyBalance = 0;
            this.CapitalBalance = 0;
            this.ManagementRequirement = null;
        }

        public double CapitalBalance { get; private set; }

        public double EnergyBalance { get; private set; }

        public IManagementRequirement ManagementRequirement { get; set; }

        public void ApplyProcessingResult(IProcessingData result)
        {
            this.EnergyBalance += result.EnergyBalance;
            this.CapitalBalance += result.CapitalBalance;
        }

        public bool CheckWasteForProcessing(IWaste waste)
        {
            if(this.ManagementRequirement == null)
            {
                return true;
            }

            return this.ManagementRequirement.CheckWasteForProcessing(this.EnergyBalance, this.CapitalBalance, waste);
        }
    }
}
