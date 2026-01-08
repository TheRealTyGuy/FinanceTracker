namespace Models
{
    public class Account
    {
        public int Id { get; set; }
        
        public string? CurrencyType { get; set; }
        public string? Name { get; set; }

        // warning!
        public string UserId { get; set; }

        public User User { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
