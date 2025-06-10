using Microsoft.AspNetCore.Identity;

namespace BDWalks.API.Interfaces
{
    public interface ITokenRepository
    {
        public string GetJWTToken(IdentityUser user, List<string> roles);
    }
}
