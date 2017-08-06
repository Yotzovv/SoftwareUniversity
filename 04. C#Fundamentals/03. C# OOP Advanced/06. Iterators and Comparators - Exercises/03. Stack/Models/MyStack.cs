using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack.Models
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public MyStack() { this.collection = new List<T>(); }

        public IEnumerator<T> GetEnumerator() => this.collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Push(List<T> elements) => this.collection.InsertRange(0, new List<T>(elements.AsEnumerable().Reverse()));

        public void Pop()
        {
            if (this.collection.Count < 1)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                this.collection.RemoveAt(0);
            }
        }

        public void Print()
        {
            this.collection.ForEach(e => Console.WriteLine(e));
            this.collection.ForEach(e => Console.WriteLine(e));
        }
    }
}
