namespace QuesFight.Models.QuestionDTOs.Learning
{
    public class UpdateLearnRecordDTO
    {
        public int Id { get; set; }

        public int FinishTime { get; set; }

        public int CompletedQuestion { get; set; }

        public int Point { get; set; }
    }
}
