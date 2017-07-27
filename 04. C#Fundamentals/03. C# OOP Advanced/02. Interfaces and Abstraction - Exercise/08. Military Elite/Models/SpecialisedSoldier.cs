using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _08.Military_Elite.Enums;

namespace _08.Military_Elite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, Corps corps)
            : base (id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; protected set; }
    }
}
