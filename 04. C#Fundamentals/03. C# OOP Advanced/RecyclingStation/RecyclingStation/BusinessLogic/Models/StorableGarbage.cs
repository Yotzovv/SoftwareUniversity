using RecyclingStation.BusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.BusinessLogic.Models
{
    [Storable]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volume) : base(name, weight, volume)
        {
        }
    }
}
