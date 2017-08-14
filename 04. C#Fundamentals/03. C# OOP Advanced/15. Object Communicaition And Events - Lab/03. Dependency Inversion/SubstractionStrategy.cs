using _03.Dependency_Inversion.Interfaces;

namespace _03.Dependency_Inversion
{
    public class SubstractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
