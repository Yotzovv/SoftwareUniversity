using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy.Models
{
    public class Lake : IEnumerable<int>
    {
        private List<int> collection;

        public Lake(List<int> collection)
        {
            this.collection = collection;
        }

        public IEnumerator<int> GetEnumerator() => this.collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Print()
        {
            Console.Write(string.Join(", ", this.collection.Where(e => this.collection.IndexOf(e) % 2 == 0)) + ", ");
            Console.Write(string.Join(", ", this.collection.Where(e => this.collection.IndexOf(e) % 2 != 0).Reverse()));
        }

    }
}
