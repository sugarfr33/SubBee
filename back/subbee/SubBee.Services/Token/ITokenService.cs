using SubBee.Models.Authentication;

namespace SubBee.Services.Token
{
    public interface ITokenService
    {
        string CreateToken(UserModel user, byte[] secretKeyToken);
    }
}