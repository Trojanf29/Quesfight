namespace QuesFight.Data.QuestionData
{
    public class MatchRecord
    {
        public int Id { get; set; }

        public QuesMatch QuesMatch { get; set; }

        public User Player { get; set; }

        public int FinishTime { get; set; }

        public int CompletedQuestion { get; set; }

        public int Point { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
