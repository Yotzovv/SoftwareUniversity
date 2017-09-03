using RecyclingStation.BusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.BusinessLogic.Models
{
    [Recyclable]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double weight, double volume) : base(name, weight, volume)
        {
        }
    }
}
