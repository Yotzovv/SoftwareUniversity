using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Collections.Generic;

namespace RecyclingStation.BusinessLogic.Models
{
    public class StrategyHolder : IStrategyHolder
    {
        private Dictionary<Type, IGarbageDisposalStrategy> getDisposalStrategies;

        public StrategyHolder()
        {
            getDisposalStrategies = new Dictionary<Type, IGarbageDisposalStrategy>();                        
        }

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return this.getDisposalStrategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if(this.getDisposalStrategies.ContainsKey(disposableAttribute))
            {
                return false;
            }

            this.getDisposalStrategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if(!getDisposalStrategies.ContainsKey(disposableAttribute))
            {
                return false;
            }

            getDisposalStrategies.Remove(disposableAttribute);
            return true;
        }
    }
}
