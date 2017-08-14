using _03.Dependency_Inversion.Interfaces;
using System.Collections.Generic;

namespace _03.Dependency_Inversion
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;
        private Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
        {
            { '+', new AdditionStrategy()},
            { '-', new SubstractionStrategy()},
            { '*', new MultiplyStrategy()},
            { '/', new DivideStrategy()},
        };

        public PrimitiveCalculator()
        {
            this.strategy = this.strategies['+'];
        }

        public void ChangeStrategy(char @operator)
        {
            this.strategy = this.strategies[@operator];
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
