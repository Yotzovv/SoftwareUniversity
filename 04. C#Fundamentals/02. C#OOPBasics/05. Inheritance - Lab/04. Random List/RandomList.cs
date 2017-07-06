using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class RandomList : ArrayList
    {
        public static string RandomString(List<string> stringz)
        {
            Random random = new Random();

            var n = random.Next(0, stringz.Count);

            string str = stringz[n];
            stringz.Remove(stringz[n]);

            return str;
        }

    }
