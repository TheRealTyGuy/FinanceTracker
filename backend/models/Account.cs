namespace Models
{
    public class Account
    {
        public int Id { get; set; }
        
        public required string CurrencyType { get; set; }
        public required string Name { get; set; }

        public required string UserId { get; set; }

        public User User { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
