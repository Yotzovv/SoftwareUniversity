using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class ListyIterator<T> : IEnumerable<T>
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
        if (this.HasNext())
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

    public void PrintAll()
    {
        string.Join(" ", this.collection);
    }

    public IEnumerator<T> GetEnumerator()
    {
         return this.GetEnumerator();
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return this.collection.GetEnumerator();
    }
}
