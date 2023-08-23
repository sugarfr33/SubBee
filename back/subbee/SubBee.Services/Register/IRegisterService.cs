using SubBee.Models.ResultModel.Register;
using SubBee.Models.User;

namespace SubBee.Services.Register
{
    public interface IRegisterService
    {
        RegisterResultModel RegisterUser(UserDto user, CancellationToken cancellationToken);
    }
}