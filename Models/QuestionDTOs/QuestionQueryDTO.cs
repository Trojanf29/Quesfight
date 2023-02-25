namespace QuesFight.Models.QuestionDTOs
{
    public class QuestionQueryDTO
    {
        public string? Categories { get; set; }
        public int? Limit { get; set; }
        public string? Difficulty { get; set; }
    }
}
