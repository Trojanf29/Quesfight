namespace QuesFight.Data.QuestionData
{
    public class LearnRecord
    {
        public int Id { get; set; }

        public User User { get; set; }

        public QuesCollection QuesCollection { get; set; }

        public int FinishTime { get; set; }

        public int CompletedQuestion { get; set; }

        public int Point { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
