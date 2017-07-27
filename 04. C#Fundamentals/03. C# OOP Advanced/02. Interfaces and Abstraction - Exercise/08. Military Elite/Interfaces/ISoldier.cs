using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Military_Elite
{
    public interface ISoldier
    {
        string Id { get; }
        string FirstName { get; }
        string Lastname { get; }
    }
}
