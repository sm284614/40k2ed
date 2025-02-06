using Microsoft.AspNetCore.Identity;
namespace _40k2ed.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
