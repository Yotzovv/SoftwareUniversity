using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string Gas();

        string Brake();
    }
}
