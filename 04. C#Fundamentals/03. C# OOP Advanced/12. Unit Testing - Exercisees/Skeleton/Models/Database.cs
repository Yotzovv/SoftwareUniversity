using System;
using System.Collections;
using System.Linq;

namespace Skeleton.Models
{
    public class Database : IEnumerable
    {
        private const int ArrayCapacity = 16;

        private int[] arr;

        private int count;

        public Database(params int[] elements)
        {
            this.arr = new int[ArrayCapacity];

            elements.ToList().ForEach(e => this.Add(e));
        }

        public void Add(int n)
        {
            if(this.count == ArrayCapacity)
            {
                throw new InvalidOperationException("Database capacity reached!");
            }

            this.arr[count] = n;
            this.count++;
        }

        public IEnumerator GetEnumerator() => this.arr.GetEnumerator();

        public void Remove()
        {
            if(this.count == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            this.arr = this.arr.Where(i => i != arr[arr.Length - 1]).ToArray();
        }

        public int[] Fetch() => this.arr;
    }
}
