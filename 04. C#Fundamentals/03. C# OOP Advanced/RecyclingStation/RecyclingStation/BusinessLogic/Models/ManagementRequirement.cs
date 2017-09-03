using RecyclingStation.BusinessLogic.Attributes;
using RecyclingStation.BusinessLogic.Interfaces;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;

namespace RecyclingStation.BusinessLogic.Models
{
    public class ManagementRequirement : IManagementRequirement
    {
        private Type bannedWasteType;

        public ManagementRequirement(double energyBalance, double capitalBalance, Type bannedWasteType)
        {
            this.MinEnergyBalance = energyBalance;
            this.MinCapitalBalance = capitalBalance;
            this.BannedWasteType = bannedWasteType;
        }

        public double MinEnergyBalance { get; private set; }

        public double MinCapitalBalance { get; private set; }

        public Type BannedWasteType
        {
            get { return this.bannedWasteType; }
            private set
            {
                if (!typeof(IWaste).IsAssignableFrom(value)
                   || value.IsAbstract
                   || !value.GetCustomAttributes(false).Any(x => x.GetType().IsSubclassOf(typeof(DisposableAttribute))))
                {
                    throw new ArgumentException("The passed in type either does not inherit from IWaste, is abstract or does not implement a Disposable Attribute!");
                }

                this.bannedWasteType = value;
            }
        }

        public bool CheckWasteForProcessing(double currentEnergyBalance, double currentCapitalBalance, IWaste garbage)
        {
            if(currentCapitalBalance < this.MinCapitalBalance || currentEnergyBalance < this.MinEnergyBalance)
            {
                if(garbage.GetType() == this.bannedWasteType)
                {
                    return false;
                }
            }
            
            return true;
        }

    }
}
