using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Food_Shortage
{
    public interface IBuyer
    {
        int Food { get; }
        void BuyFood();
    }
}
