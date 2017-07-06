using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Date_Modifier
{
    public class DateModifier
    {
        public static void CalculateDaysBetween(string firstDate, string secDate)
        {
            DateTime fDate = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime sDate = DateTime.ParseExact(secDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            List<DateTime> dates = new List<DateTime>(new[] { fDate, sDate });

            Console.WriteLine(Math.Abs((dates.Min() - dates.Max()).TotalDays));
        }
    }
}
