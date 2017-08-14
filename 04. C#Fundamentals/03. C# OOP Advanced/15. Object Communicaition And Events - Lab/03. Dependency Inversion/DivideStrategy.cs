using _03.Dependency_Inversion.Interfaces;

namespace _03.Dependency_Inversion
{
    class DivideStrategy : IStrategy
    {
        public int Calculate(int firs, int second)
        {
            return firs / second;
        }
    }
}
