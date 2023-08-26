using SubBee.Models.ResultModel;
using SubBee.Models.User;

namespace SubBee.Services.Register.Dal
{
    public interface IRegisterDal
    {
        ResultModel RegisterUser(UserDto user, CancellationToken cancellationToken);
    }
}