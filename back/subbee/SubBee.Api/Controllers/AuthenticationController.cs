using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubBee.Models.ResultModel.Register;
using SubBee.Models.User;
using SubBee.Services.Login;
using SubBee.Services.Register;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;

        public AuthenticationController(ILoginService loginService, IRegisterService registerService)
        {
            _loginService = loginService;
            _registerService = registerService;
        }

        [HttpGet]
        public ActionResult<bool> Get()
        {
            var isAuthenticate = _loginService.Logins();
            return Ok(isAuthenticate);
        }

        [HttpPost("register")]
        public ActionResult<RegisterResultModel> RegisterUser(UserDto user, CancellationToken cancellationToken)
        {
            var restult = _registerService.RegisterUser(user, cancellationToken);

            return Ok(restult);
        }
    }
}
