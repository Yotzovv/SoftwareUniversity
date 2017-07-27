using System;
using System.Linq;
using System.Collections.Generic;

public class Box<T> where T : IComparable<T>
{
    private T data;

    public Box(T data)
    {
        this.data = data;
    }

    public int Compare(List<Box<T>> elements, T element)
    {
        return elements.Count(e => e.data.CompareTo(element) > 0);
    }

    public override string ToString()
    {
        return $"{data.GetType().FullName}: {this.data}";
    }
}
