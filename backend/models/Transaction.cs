namespace Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public required DateTime Date { get; set; }
        public required string Description { get; set; }
        public required decimal Amount { get; set; }

        public int AccountId { get; set; }
        public int CategoryId { get; set; }

        public Account Account { get; set; } = null!;
        public Category Category { get; set; } = null!;
}
}