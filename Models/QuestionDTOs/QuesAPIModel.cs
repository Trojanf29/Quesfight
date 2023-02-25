namespace QuesFight.Models.QuestionDTOs
{
    public class QuesAPIModel
    {
        public string Category { get; set; }
        public string Id { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> IncorrectAnswers { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public string Difficulty { get; set; }
        public List<string> Regions { get; set; }
        public bool IsNiche { get; set; }
    }
}
