using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirs.Models
{
    class Family
    {
        public List<Person> FamilyMembers { get; set; }

        public void AddMember(Person member)
        {
           FamilyMembers.Add(member);
        }

        public void GetOldestMember(List<Person> FamilyMembers)
        {
            Person oldestMember = new Person();
            foreach (var member in FamilyMembers)
            {
                if(member.age > oldestMember.age)
                {
                    oldestMember.age = member.age;
                    oldestMember.name = member.name;
                }
            }
            Console.WriteLine($"{oldestMember.name} {oldestMember.age}");
        }
    }
}
