using SubBee.Models.ResultModel.Register;
using SubBee.Models.User;
using SubBee.Services.Login;
using SubBee.Services.Register.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubBee.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterDal _registerDal;

        public RegisterService(IRegisterDal registerDal)
        {
            _registerDal = registerDal;
        }

        public RegisterResultModel RegisterUser(UserDto user, CancellationToken cancellationToken)
        {
            return _registerDal.RegisterUser(user, cancellationToken);
        }

    }
}
