using SubBee.Models.Authentication;
using SubBee.Models.ResultModel;
using SubBee.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubBee.Services.Register.Dal
{
    public class RegisterDal : IRegisterDal
    {
        public ResultModel RegisterUser(UserDto userDto, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var resultModel = new ResultModel();

            if (userDto is null)
            {
                resultModel.IsSuccess = true;
                resultModel.Message = nameof(userDto) + " parameter is null";

                return new ResultModel();
            }

            var userModel = new UserModel();

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            userModel.UserName = userDto.UserName;
            userModel.PasswordHash = passwordHash;

            resultModel.IsSuccess = true;
            resultModel.Message = passwordHash;

            return resultModel;
        }
    }
}
