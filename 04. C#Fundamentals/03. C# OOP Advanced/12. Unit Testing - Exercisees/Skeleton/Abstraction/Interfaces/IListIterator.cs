using System.Collections.Generic;

namespace Skeleton.Abstraction.Interfaces
{
    public interface IListIterator
    {
        List<string> Collection { get; }

        bool Move();

        bool HasNext();

        void Print();
    }
}
