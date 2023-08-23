using SubBee.Models.ResultModel.Register;
using SubBee.Models.User;

namespace SubBee.Services.Register.Dal
{
    public interface IRegisterDal
    {
        RegisterResultModel RegisterUser(UserDto user, CancellationToken cancellationToken);
    }
}