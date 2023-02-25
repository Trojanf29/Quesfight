using QuesFight.Models.UserDTOs;

namespace QuesFight.Models.QuestionDTOs.Learning
{
    public class LearnRecordDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public QuesCollectionDTO QuesCollection { get; set; }

        public int FinishTime { get; set; }

        public int CompletedQuestion { get; set; }

        public int Point { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
