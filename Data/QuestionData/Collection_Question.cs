namespace QuesFight.Data.QuestionData
{
    public class Collection_Question
    {
        public int CollectionId { get; set; }
        public string QuestionId { get; set; }

        public QuesCollection QuesCollection { get; set; }
        public Question Question { get; set; }
    }
}
