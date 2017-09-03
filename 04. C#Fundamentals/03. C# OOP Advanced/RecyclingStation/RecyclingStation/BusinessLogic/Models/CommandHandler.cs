using System;
using RecyclingStation.BusinessLogic.Contracts.Core;
using System.Reflection;
using System.Linq;
using RecyclingStation.WasteDisposal.Interfaces;
using RecyclingStation.BusinessLogic.Attributes;
using RecyclingStation.BusinessLogic.Interfaces;
using RecyclingStation.WasteDisposal;

namespace RecyclingStation.BusinessLogic.Models
{
    public class CommandHandler : ICommandHandler
    {
        public CommandHandler(IBalanceManager balanceManager, IGarbageProcessor garbageProcessor)
        {
            this.GarbageProcessor = garbageProcessor;
            this.BalanceManager = balanceManager;
            this.InitializeStrategies();
        }

        public CommandHandler() : this (new BalanceManager(), new GarbageProcessor())
        {
        }

        public IBalanceManager BalanceManager { get; private set; }

        public IGarbageProcessor GarbageProcessor { get; private set; }

        private void InitializeStrategies()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly().DefinedTypes as TypeInfo[] ??
                                Assembly.GetExecutingAssembly().DefinedTypes.ToArray();

            var strategies = assemblyTypes.Where(x => typeof(IGarbageDisposalStrategy).IsAssignableFrom(x)
                             && x != typeof(IGarbageDisposalStrategy)
                             && !x.IsAbstract
                             && !x.IsInterface);

            var attributes = assemblyTypes.Where(x => typeof(DisposableAttribute).IsAssignableFrom(x)
                             && x != typeof(DisposableAttribute)
                             && !x.IsAbstract);

            foreach (var attr in attributes)
            {
                string strategyName = attr.Name.Replace("Attribute", "Strategy");
                var strategy = strategies.FirstOrDefault(x => x.Name == strategyName);

                if(strategy != null)
                {
                    var startInstance = (IGarbageDisposalStrategy)Activator.CreateInstance(strategy);
                    this.GarbageProcessor.StrategyHolder.AddStrategy(attr, startInstance);
                }

            }
        }

        public string Status()
        {
            return string.Format("Energy: {0:f2} Capital: {1:f2}", this.BalanceManager.EnergyBalance,
                this.BalanceManager.CapitalBalance);
        }

        public string ProcessGarbage(string[] parameters)
        {
            IWaste garbage = this.InstantiateWaste(parameters);
            if(this.BalanceManager.CheckWasteForProcessing(garbage))
            {
                IProcessingData result = this.GarbageProcessor.ProcessWaste(garbage);
                this.BalanceManager.ApplyProcessingResult(result);

                return string.Format("{0:f2} kg of {1} successfully processed!", garbage.Weight, garbage.Name);
            }

            return "Processing Denied!";
        }

        private IWaste InstantiateWaste(string[] parameters)
        {
            string type = parameters[3];
            string garbageTypeName = type + "Garbage";

            Type garbageType = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(x => x.Name == garbageTypeName);

            if(garbageType == null)
            {
                throw new ArgumentException("Unsupported garbage type passed!");
            }

            ConstructorInfo constructor = garbageType.GetConstructors()[0];
            ParameterInfo[] constructorParams = constructor.GetParameters();

            object[] converteddParameters = new object[constructorParams.Length];

            for (int i = 0; i < constructorParams.Length; i++)
            {
                Type parameterType = constructorParams[i].ParameterType;

                if(typeof(IConvertible).IsAssignableFrom(parameterType))
                {
                    converteddParameters[i] = Convert.ChangeType(parameters[i], parameterType);
                }
            }

            IWaste garbage = (IWaste)Activator.CreateInstance(garbageType, converteddParameters);
            return garbage;
        }

        private IManagementRequirement InstantiateManagementRequirement(string[] parameters)
        {
            string type = parameters[2];
            string garbageTypeName = type + "Garbage";

            Type garbageType = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(x => x.Name == garbageTypeName);
            double minEnergyBalance = double.Parse(parameters[0]);
            double minCapitalBalance = double.Parse(parameters[1]);

            IManagementRequirement req = new ManagementRequirement(minEnergyBalance, minCapitalBalance, garbageType);

            return req;
        }

        public string ChangeManagementRequirement(string[] parameters)
        {
            IManagementRequirement req = this.InstantiateManagementRequirement(parameters);
            this.BalanceManager.ManagementRequirement = req;

            return "Management requirement changed!";
        }
    }
}
