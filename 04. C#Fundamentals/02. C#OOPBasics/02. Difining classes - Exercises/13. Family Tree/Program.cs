using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Family_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var people = new List<Person>();

            Person toGather = new Person(input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains("-"))
                {
                    Person parent;
                    Person child;
                    var tokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    var left = tokens[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var right = tokens[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    //left is birthday
                    if (left.Count() == 1)
                    {
                        if (people.Any(p => p.Birthday == left[0]))
                        {
                            parent = people.First(p => p.Birthday == left[0]);
                        }
                        else
                        {
                            parent = new Person(left);
                        }
                    }
                    else   //left is name
                    {
                        if (people.Any(p => p.FirstName == left[0] && p.LastName == left[1]))
                        {
                            parent = people.First(p => p.FirstName == left[0] && p.LastName == left[1]);
                        }
                        else
                        {
                            parent = new Person(left);
                        }
                    }

                    if (right.Count() == 1)     //right is birthday
                    {
                        if (people.Any(p => p.Birthday == right[0]))
                        {
                            child = people.First(p => p.Birthday == right[0]);
                        }
                        else
                        {
                            child = new Person(right);
                        }
                    }
                    else    //right is name
                    {
                        if (people.Any(p => p.FirstName == right[0] && p.LastName == right[1]))
                        {
                            child = people.First(p => p.FirstName == right[0] && p.LastName == right[1]);
                        }
                        else
                        {
                            child = new Person(right);
                        }
                    }

                    //connect parent and children objects
                    parent.Children.Add(child);
                    child.Parents.Add(parent);

                    if (!people.Contains(parent))
                    {
                        people.Add(parent);
                    }

                    if (!people.Contains(child))
                    {
                        people.Add(child);
                    }
                }
                else
                {
                    Person target;
                    Person secObj;
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens.Take(2).ToArray();
                    var birthday = tokens.Last();

                    //check if name already exist in collection
                    if (people.Any(p => p.FirstName == name[0] && p.LastName == name[1]))
                    {
                        target = people.First(p => p.FirstName == name[0] && p.LastName == name[1]);

                        if (people.Any(p => p.Birthday == birthday))
                        {
                            secObj = people.First(p => p.Birthday == birthday);

                            target.Birthday = secObj.Birthday;

                            foreach (var child in secObj.Children)
                            {
                                target.Children.Add(child);
                            }

                            foreach (var parent in secObj.Parents)
                            {
                                target.Parents.Add(parent);
                            }
                            

                            secObj.FirstName = target.FirstName;
                            secObj.LastName = target.LastName;

                            foreach (var child in target.Children)
                            {
                                secObj.Children.Add(child);
                            }
                            
                            foreach (var parent in target.Parents)
                            {
                                secObj.Parents.Add(parent);
                            }

                        }
                        else
                        {
                            target.Birthday = birthday;
                        }
                    }
                    else if(people.Any(p => p.Birthday == birthday))    //check if object with this birthday already exist in collection
                    {
                        target = people.First(p => p.Birthday == birthday);
                        target.FirstName = name[0];
                        target.LastName = name[1];
                    }
                }
            }


            Person toPrint = people.First(p => p.FirstName == toGather.FirstName && p.LastName == toGather.LastName
                                          || p.Birthday == toGather.Birthday);

            Console.WriteLine(toPrint);
        }
    }
}