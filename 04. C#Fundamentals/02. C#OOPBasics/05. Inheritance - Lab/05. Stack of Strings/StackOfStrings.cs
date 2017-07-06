using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class StackOfStrings
    {
        private List<string> data = new List<string>();

        public void Push(string item)
        {
            data.Add(item);
        }

        public string Pop()
        {
            string pop = data.Last();
            data.Remove(pop);

            return pop;
        }

        public string Peek()
        {
            return data.Last();
        }

        public bool isEmpty()
        {
            return data.Count > 0;
        }
    }
