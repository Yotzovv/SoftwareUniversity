using System.Collections.Generic;

public static class Swapper<T>
{
    public static List<T> Swap<T>(List<T> list, int index1, int index2)
    {
        var firstElement = list[index1];

        list[index1] = list[index2];
        list[index2] = firstElement;

        return list;
    }
 }