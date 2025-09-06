using AuthourizationApi.Models;

namespace AuthourizationApi.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles); // person can have multiple roles
    }
}
