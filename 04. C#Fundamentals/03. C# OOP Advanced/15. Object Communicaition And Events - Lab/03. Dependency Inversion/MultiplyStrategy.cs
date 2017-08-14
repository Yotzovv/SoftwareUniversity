using System;
using _03.Dependency_Inversion.Interfaces;

namespace _03.Dependency_Inversion
{
    public class MultiplyStrategy : IStrategy
    {
        public int Calculate(int first, int second)
        {
            return first * second;
        }
    }
}
