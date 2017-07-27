using _09.Collection_Hierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _09.Collection_Hierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public MyList()
        {
            this.collection = new List<T>();
        }

        public int User { get { return this.collection.Count; } }

        public override T Remove()
        {
            var item = this.collection.First();
            this.collection.RemoveAt(0);

            return item;
        }

        public override string ToString()
        {
            return string.Join(" ", new int[this.collection.Count]);
        }
    }
}
