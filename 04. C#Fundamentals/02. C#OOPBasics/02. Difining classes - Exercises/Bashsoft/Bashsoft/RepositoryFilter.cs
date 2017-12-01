using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bashsoft
{
    public class RepositoryFilter
    {
        //public void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake) { }
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> wantedFilter, int studentsToTake)
        {
            if(wantedFilter == "excellent")
            {
                this.FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake);
            }
            else if(wantedFilter == "avarage")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if(wantedFilter == "poor")
            {
                this.FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentsFilter);
            }
        }    
    }
}
