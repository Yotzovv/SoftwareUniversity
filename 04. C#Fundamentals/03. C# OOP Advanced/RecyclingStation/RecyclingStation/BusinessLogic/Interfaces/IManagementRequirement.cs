using RecyclingStation.WasteDisposal.Interfaces;
using System;

namespace RecyclingStation.BusinessLogic.Interfaces
{
    public interface IManagementRequirement
    {
        double MinEnergyBalance { get; }

        double MinCapitalBalance { get; }

        Type BannedWasteType { get; }

        bool CheckWasteForProcessing(double currentEnergyBalance, double currentCapitalBalance, IWaste bannedWaste);
    }
}
