using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Models
{
    public class AppUser : IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}
