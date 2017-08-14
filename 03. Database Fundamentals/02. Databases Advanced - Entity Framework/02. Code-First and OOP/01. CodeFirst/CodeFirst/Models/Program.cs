using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirs.Models
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            family.FamilyMembers = new List<Person>();

            for (int i = 0;i < n;i++)
            {
                Person person = new Person();
                string[] input = Console.ReadLine().Split();
                person.name = input[0];
                person.age = int.Parse(input[1]);
                
                family.AddMember(person);
            }

            family.GetOldestMember(family.FamilyMembers);
        }
    }
}
