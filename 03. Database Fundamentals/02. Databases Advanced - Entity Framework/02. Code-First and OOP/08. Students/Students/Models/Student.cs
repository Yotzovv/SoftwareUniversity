using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class Student
    {
        public List<string> names { get; set; }
        public static int instances { get; set; }

        public void InstancesCount(List<string> names)
        {
            foreach (var name in names)
            {
                instances++;
            }
            Console.WriteLine(instances);
        }
    }
}
