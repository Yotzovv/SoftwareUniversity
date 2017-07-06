using _01.Define_a_Class_Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Oldest_Family_Member
{
    public class Family
    {
        static List<Person> people = new List<Person>();

        public static List<Person> People
        {
            get
            {
                return people;
            }
            set
            {
                people = value;
            }
        }


        public static void AddMember(Person member)
        {
            people.Add(member);
        }

        public static void GetOldestMember()
        {
            Person oldestMember = people.OrderByDescending(a => a.Age).First();
            Console.WriteLine(oldestMember.Name + " " + oldestMember.Age);
        }
    }
}
