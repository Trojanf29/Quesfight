using QuesFight.Data.QuestionData;

namespace QuesFight.Models.QuestionDTOs
{
    public class QuesCollectionDTO
    {
        public int Id { get; set; }

        public string? CollectionName { get; set; }

        public int RestrictTime { get; set; }

        public int NumberOfQuestion { get; set; }

        public List<Question> Questions { get; set; }
    }
}
