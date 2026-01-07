namespace Models
{
    public class User
    {
        public string? ExternalProviderId { get; set; }

        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; } 

        public string? PasswordHash { get; set; }
        public string? Salt { get; set; } 
        
        public DateTime? CreationDate { get; set; }
        
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }   
}