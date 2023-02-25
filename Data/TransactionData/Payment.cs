namespace QuesFight.Data.TransactionData
{
    public class Payment
    {
        public int Id { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int TotalPrice { get; set; }
    }
}
