using Microsoft.AspNetCore.Identity;

namespace SubBee.Api.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
