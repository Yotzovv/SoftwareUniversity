using MathUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmd = Console.ReadLine().Split();

            while(!cmd.Contains("End"))
            {
                float f = float.Parse(cmd[1]);
                float s = float.Parse(cmd[2]);

                if(cmd[0] == "Sum")
                {
                    MathUtil.Sum(f, s);
                }
                else if(cmd[0] == "Subtract")
                {
                    MathUtil.Subtract(f, s);
                }
                else if(cmd[0] == "Multiply")
                {
                    MathUtil.Multiply(f, s);
                }
                else if(cmd[0] == "Divide")
                {
                    MathUtil.Divide(f, s);
                }
                else if(cmd[0] == "Percentage")
                {
                    MathUtil.Percentage(f, s);
                }

                cmd = Console.ReadLine().Split();
            }
        }
    }
}
