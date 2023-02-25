using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuesFight.Data.TransactionData
{
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(45)")]
        public string Name { get; set; }

        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
