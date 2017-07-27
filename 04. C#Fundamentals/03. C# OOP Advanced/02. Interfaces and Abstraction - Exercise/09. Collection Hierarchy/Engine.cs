using _09.Collection_Hierarchy.Models;
using System.Collections.Generic;
using System;

namespace _09.Collection_Hierarchy
{
    public class Engine
    {
        AddCollection<string> addCollection;
        AddRemoveCollection<string> addRemoveCollection;
        MyList<string> myList;

        public Engine()
        {
            addCollection = new AddCollection<string>();
            addRemoveCollection = new AddRemoveCollection<string>();
            myList = new MyList<string>();
        }

        public void Run()
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                addCollection.Add(token);
                addRemoveCollection.Add(token);
                myList.Add(token);
            }

            Console.WriteLine(addCollection);
            Console.WriteLine(addRemoveCollection);
            Console.WriteLine(myList);

            int n = int.Parse(Console.ReadLine());
            
            var addremove = new List<string>();
            var mylist = new List<string>();

            for (int i = 0; i < n; i++)
            {
                addremove.Add(addRemoveCollection.Remove());
                mylist.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addremove));
            Console.WriteLine(string.Join(" ", mylist));
        }
    }
}
