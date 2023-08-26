using SubBee.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubBee.Services.Login
{
    public class LoginService : ILoginService
    {
        public bool Login(UserDto userDto, CancellationToken cancellationToken = default)
        {
            return true;
        }
    }
}
