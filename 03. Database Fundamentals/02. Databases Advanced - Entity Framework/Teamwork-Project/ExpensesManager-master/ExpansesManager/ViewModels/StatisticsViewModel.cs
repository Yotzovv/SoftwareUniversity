using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpansesManager.ViewModels
{
    public class StatisticsViewModel
    {
        public string GroupName { get; set; }
        public string SubGroupName { get; set; }
        public decimal TotalSubGroupPrice { get; set; }
        public decimal DayPrice { get; set; }
        public decimal WeekPrice { get; set; }
        public decimal MonthPrice { get; set; }
        public decimal YearPrice { get; set; }
    }
}
