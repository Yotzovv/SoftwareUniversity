using System;
using System.Collections.Generic;

namespace _06.StrategyPatter.Models
{
    public class AgeCompare : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
