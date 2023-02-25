using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuesFight.Data.TransactionData
{
    public class Transaction
    {
        [Column(TypeName = "VARCHAR(45)")]
        public string Id { get; set; }

        public User User { get; set; }

        public string Action { get; set; }

        public int Amount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
