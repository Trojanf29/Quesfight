using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuesFight.Data.QuestionData
{
    public class QuesCollection
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(45)")]
        public string? CollectionName { get; set; }

        public int RestrictTime { get; set; }

        public int NumberOfQuestion { get; set; }

        public DateTime CreatedAt { get; set; }



        public ICollection<Collection_Question> Collection_Questions { get; set; }
    }
}
