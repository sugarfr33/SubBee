using SubBee.Models.ResultModel;
using SubBee.Models.User;

namespace SubBee.Services.Register
{
    public interface IRegisterService
    {
        ResultModel RegisterUser(UserDto user, CancellationToken cancellationToken);
    }
}