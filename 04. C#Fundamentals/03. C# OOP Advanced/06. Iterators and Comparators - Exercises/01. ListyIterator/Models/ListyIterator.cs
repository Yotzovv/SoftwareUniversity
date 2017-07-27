using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class ListyIterator
    {
        private List<string> collection;
        private int internalIndex;

        public ListyIterator()
        {
            this.collection = new List<string>();
            this.internalIndex = 0;
        }

        public void Create(List<string> args)
        {
            this.collection = args.Skip(1).ToList();
        }

        public bool Move()
        {
            if(this.HasNext())
            {
                internalIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext() => internalIndex + 1 < collection.Count;
        
        public void Print()
        {
            try
            {
                Console.WriteLine(this.collection[this.internalIndex]);
            }
            catch
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }
}
