using SubBee.Models.Authentication;
using SubBee.Models.ResultModel.Register;
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
        public RegisterResultModel RegisterUser(UserDto user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var resultModel = new RegisterResultModel();

            if (user is null)
            {
                resultModel.IsSuccess = true;
                resultModel.Message = nameof(user) + " parameter is null";

                return new RegisterResultModel();
            }

            var userModel = new UserModel();

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            userModel.UserName = user.UserName;
            userModel.PasswordHash = passwordHash;

            resultModel.IsSuccess = true;
            resultModel.Message = passwordHash;

            return resultModel;
        }
    }
}
