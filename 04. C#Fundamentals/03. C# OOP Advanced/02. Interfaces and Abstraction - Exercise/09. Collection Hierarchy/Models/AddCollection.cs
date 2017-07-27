using _09.Collection_Hierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _09.Collection_Hierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        private List<T> collection { get; set; }

        public AddCollection()
        {
            this.collection = new List<T>();
        }

        public void Add(T item)
        {
            this.collection.Add(item);
        }

        public override string ToString()
        {
            return string.Join(" ", Enumerable.Range(0, this.collection.Count));
        }
    }
}
