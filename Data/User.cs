using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuesFight.Data
{
    public class User
    {
        [Column(TypeName = "VARCHAR(45)")]
        public string Id { get; set; }

        [Column(TypeName = "NVARCHAR(45)")]
        public string UserName { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR(64)")]
        public string Password { get; set; }

        //Just 1 role for each user
        [Column(TypeName = "VARCHAR(15)")]
        public string Role { get; set; }

        [Column(TypeName = "VARCHAR(45)")]
        public string? Avatar { get; set; }

        [Column(TypeName = "NVARCHAR(500)")]
        public string? Bio { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? Token { get; set; }

        public int Point { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
