using System.Collections.Generic;

namespace _04.Work_Force
{
    public class JobsList : List<Job>
    {
        public void OnJobDone(object sender, JobEventArgs args)
        {
            this.Remove(args.Job);
        }
    }
}
