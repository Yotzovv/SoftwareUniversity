using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomList<T> : IEnumerable where T : IComparable<T>
{
    private List<T> collection;

    public CustomList()
    {
        this.collection = new List<T>();
    }

    public void Add(T element)
    {
        collection.Add(element);
    }

    public T Remove(int index)
    {
        var element = collection[index];
        collection.RemoveAt(index);

        return element;
    }

    public bool Contains(T element)
    {
        if (!collection.Contains(element))
        {
            return false;
        }

        return true;
    }

    public void Swap(int index1, int index2)
    {
        var firstElement = collection[index1];

        collection[index1] = collection[index2];
        collection[index2] = firstElement;
    }

    public int CountGreaterThan(T element)
    {
        return collection.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return collection.Max();
    }

    public T Min()
    {
        return collection.Min();
    }

    public void Print()
    {
        foreach (var item in this.collection)
        {
            Console.WriteLine(item);
        }
    }

    public void Sort()
    {
        this.collection = this.collection.OrderBy(e => e).ToList();
    }

    public IEnumerator GetEnumerator()
    {
        return collection.GetEnumerator();
    }
}