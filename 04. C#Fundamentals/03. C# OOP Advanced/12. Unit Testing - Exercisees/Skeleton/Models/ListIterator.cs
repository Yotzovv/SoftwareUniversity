using System;
using System.Collections.Generic;
using Skeleton.Abstraction.Interfaces;
using System.Linq;

namespace Skeleton.Models
{
    public class ListIterator : IListIterator
    {
        private List<string> collection;
        private int currentIndex;

        public ListIterator(params string[] elements)
        {
            if (elements.Any(e => e == null) || elements == null)
            {
                throw new ArgumentNullException("Values can not be null!");
            }

            this.collection = new List<string>(elements);
            this.currentIndex = 0;
        }

        public List<string> Collection { get { return this.collection; } }

        public bool HasNext() => this.collection.Count - 1 > currentIndex;

        public bool Move()
        {
            if (this.HasNext())
            {
                currentIndex++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if(collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(collection[currentIndex]);
        }
    }
}
