using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubBee.Models.Authentication;
using SubBee.Models.ResultModel;
using SubBee.Models.User;
using SubBee.Services.Login;
using SubBee.Services.Register;
using SubBee.Services.Token;
using System.Text;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public static UserModel userModel = new UserModel();

        public AuthenticationController(ILoginService loginService, IRegisterService registerService, IConfiguration configuration, ITokenService tokenService)
        {
            _loginService = loginService;
            _registerService = registerService;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public ActionResult<bool> Login([FromBody] UserDto userDto)
        {
            var appSettingsToken = _configuration.GetSection("AppSettings:SecretKeyToken").Value;
            var secretKeyToken = Encoding.UTF8.GetBytes(appSettingsToken!);

            

            var jwtToken = _tokenService.CreateToken(userModel, secretKeyToken);


            //var isAuthenticate = _loginService.Login(userDto);
            return Ok(jwtToken);
        }

        [HttpPost("register")]
        public ActionResult<ResultModel> RegisterUser(UserDto user, CancellationToken cancellationToken)
        {
            var restult = _registerService.RegisterUser(user, cancellationToken);

            return Ok(restult);
        }

        [HttpPost("register2")]
        public ActionResult RegisterUser2()
        {
            userModel.UserName = "string";
            userModel.PasswordHash = BCrypt.Net.BCrypt.HashPassword("string");

            return Ok();
        }
    }
}
