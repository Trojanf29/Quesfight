using System.ComponentModel.DataAnnotations.Schema;

namespace QuesFight.Data
{
    public class Message
    {
        public int Id { get; set; }

        public User User { get; set; }

        [Column(TypeName = "NVARCHAR(255)")]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
