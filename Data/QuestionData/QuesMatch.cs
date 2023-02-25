namespace QuesFight.Data.QuestionData
{
    public class QuesMatch
    {
        public int Id { get; set; }

        public QuesCollection QuesCollection { get; set; }

        public User Winner { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
