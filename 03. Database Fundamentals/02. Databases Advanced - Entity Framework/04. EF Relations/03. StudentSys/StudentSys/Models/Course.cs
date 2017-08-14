using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSys.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //NULL
        public string Discription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public virtual List<Student> Students { get; set; }
        public virtual List<Resource> Resources { get; set; }
        public virtual List<Homework> Homeworks { get; set; }
    }
}
