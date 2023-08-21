using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubBee.Services.Login;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult<bool> Get()
        {
            var isAuthenticate = _loginService.Logins();
            return Ok(isAuthenticate);
        }
    }
}
