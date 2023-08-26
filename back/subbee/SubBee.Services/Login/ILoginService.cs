using SubBee.Models.User;

namespace SubBee.Services.Login
{
    public interface ILoginService
    {
        bool Login(UserDto userDto, CancellationToken cancellationToken = default);
    }
}