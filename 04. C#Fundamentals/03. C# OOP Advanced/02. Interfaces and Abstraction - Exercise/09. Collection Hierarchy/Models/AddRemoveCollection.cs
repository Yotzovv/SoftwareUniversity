using _09.Collection_Hierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace _09.Collection_Hierarchy.Models
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        protected List<T> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<T>();
        }

        public void Add(T item)
        {
            this.collection.Insert(0, item);
        }

        public virtual T Remove()
        {
            var item = this.collection.Last();
            this.collection.RemoveAt(collection.Count - 1);

            return item;
        }

        public override string ToString()
        {
            return string.Join(" ", new int[this.collection.Count]);
        }
    }
}
