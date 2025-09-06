using Microsoft.AspNetCore.Identity;

namespace AuthourizationApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
