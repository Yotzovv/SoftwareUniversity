using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Military_Elite
{
    public interface ILeutenantGeneral
    {
        ICollection<IPrivate> Privates { get; }
    }
}
