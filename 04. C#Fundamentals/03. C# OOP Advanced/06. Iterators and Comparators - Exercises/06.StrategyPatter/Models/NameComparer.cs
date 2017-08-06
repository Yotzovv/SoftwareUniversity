using System;
using System.Collections;
using System.Collections.Generic;

namespace _06.StrategyPatter.Models
{
    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if(x.Name.Length == y.Name.Length)
            {
                return x.Name.ToLower()[0].CompareTo(y.Name.ToLower()[0]);
            }

            return x.Name.Length - y.Name.Length;
        }
    }
}
