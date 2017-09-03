using System;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.WasteDisposal.Models;

namespace RecyclingStation.BusinessLogic.Attributes
{
    public class BurnableAttribute : DisposableAttribute
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyGained = (garbage.Weight * garbage.VolumePerKg) * 0.8;
            return new ProcessingData(energyGained, 0);
        }
    }
}
