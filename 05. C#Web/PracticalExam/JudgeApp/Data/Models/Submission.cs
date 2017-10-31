namespace JudgeApp.Data.Models
{
    public class Submission
    {
        public int Id { get; set; }

        public int ContestId { get; set; }

        public Contest Contest { get; set; }

        public string Code { get; set; }
    }
}