using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuesFight.Data.QuestionData
{
    public class Question
    {
        public string Id { get; set; }

        public QuestionGenre Genre { get; set; }

        [Column(TypeName = "NVARCHAR(255)")]
        public string Content { get; set; }

        public string Difficulty { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string Choice1 { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string Choice2 { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string Choice3 { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string CorrectChoice { get; set; }

        public DateTime CreatedAt { get; set; }



        [JsonIgnore]
        public ICollection<Collection_Question>? Collection_Questions { get; set; }
    }
}
