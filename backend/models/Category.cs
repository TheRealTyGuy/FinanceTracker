namespace Models {
    public class Category
    {
        public int Id { get; set; }
        
        public required string Name { get; set; }

        /* 
        private ICollection<Transaction> _transactions = new List<Transaction>();

        public ICollection<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; }
        }
        */
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}