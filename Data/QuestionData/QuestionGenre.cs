using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuesFight.Data.QuestionData
{
    public class QuestionGenre
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(45)")]
        public string Name { get; set; }
    }
}
