using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Group_by_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input;
            List<Student> names = new List<Student>();

            while ((input = Console.ReadLine().Split())[0] != "END")
            {
                string name = input[0] + " " + input[1];
                int group = int.Parse(input[2]);

                names.Add(new Student(name, group));
            }

            var output = names.GroupBy(g => g.Group, g =>
                               new { Name = g.Name },
                               (groupId, studs) =>
                               new { id = groupId, sts = studs.ToList() })
                               .ToList();

            foreach (var group in output.OrderBy(g => g.id))
            {
                Console.WriteLine($"{group.id} - {string.Join(", ", group.sts.Select(st => st.Name))}");
            }
        }
    }

    class Student
    {
        public Student(string firstName, int group)
        {
            this.Name = firstName;
            this.Group = group;
        }
        public string Name { get; set; }

        public int Group { get; set; }
    }
}
