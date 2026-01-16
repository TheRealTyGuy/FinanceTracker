using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        
        public DateTime? CreationDate { get; set; }
        
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }   
}