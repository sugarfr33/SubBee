using SubBee.Api.Models.Dtos;
using System.Security.Claims;

namespace SubBee.Api.Repositories.Abstract
{
    public interface ITokenService
    {
        TokenResponse GetToken(IEnumerable<Claim> claim);

        string GetRefreshToken();

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        bool Revoke(string username);

        bool IsTokenExpired(string token);
    }
}
