using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<char, char> exchangable = new Dictionary<char, char>();
            bool isExchangeable = true;

            for (int i = 0; i < input[0].Length; i++)
            {
                if (!exchangable.ContainsKey(input[0][i]))
                {
                    exchangable[input[0][i]] = input[1][i];
                }
                else if(exchangable[input[0][i]] != input[1][i])
                {
                    isExchangeable = false;
                }
            }


            //for (int i = 0; i < input[1].Length; i++)
            //{
            //    if (!exchangable.ContainsValue(input[1][i]))
            //    {
            //        isExchangeable = false;
            //    }
            //}

            Console.WriteLine(isExchangeable.ToString().ToLower());
        }
    }
}
