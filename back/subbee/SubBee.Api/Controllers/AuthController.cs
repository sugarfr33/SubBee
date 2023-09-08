using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using SubBee.Api.Models;
using SubBee.Api.Models.Domain;
using SubBee.Api.Models.Dtos;
using SubBee.Api.Repositories.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthController(
            DatabaseContext databaseContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            var status = new StatusDto();

            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the valid fields";

                return Ok(status);
            }

            var user = await _userManager.FindByNameAsync(changePasswordDto.Username);
            if (user is null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";

                return Ok(status);
            }

            if (!await _userManager.CheckPasswordAsync(user, changePasswordDto.CurrentPassword))
            {
                status.StatusCode = 0;
                status.Message = "Invalid current password";

                return Ok(status);
            }

            var changePassword = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            if (!changePassword.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Failed to change password";

                return Ok(status);
            }

            status.StatusCode = 1;
            status.Message = "Password has been successfully changed";
            var username = User.Identity?.Name;
            _tokenService.Revoke(username ?? string.Empty);
            return Ok(changePassword);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
        {
            // 1:27:36
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            var loginResponse = new LoginResponse();

            if (user is not null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = _tokenService.GetToken(authClaims);
                var refreshToken = _tokenService.GetRefreshToken();
                var tokenInfo = _databaseContext.TokenInfo.FirstOrDefault(x => x.Username == loginDto.Username);

                if (tokenInfo is null)
                {
                    var info = new TokenInfo
                    {
                        Username = user.UserName!,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiry = token.ValidTo.AddHours(12),
                    };
                    _databaseContext.TokenInfo.Add(info);
                }
                else
                {
                    tokenInfo!.RefreshToken = refreshToken;
                    tokenInfo.RefreshTokenExpiry = token.ValidTo.AddHours(12);
                }

                try
                {
                    _databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                loginResponse = new LoginResponse
                {
                    Name = user.Name,
                    Username = user.UserName!,
                    Token = token.TokenString,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    StatusCode = 1,
                    Message = "Logged In"
                };

                return Ok(loginResponse);
            }

            loginResponse.Token = string.Empty;
            loginResponse.Expiration = null;
            loginResponse.StatusCode = 0;
            loginResponse.Message = "Invalid username or password";

            return Ok(loginResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto registrationDto)
        {
            var status = new StatusDto();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";

                return Ok(status);
            }

            var userExists = await _userManager.FindByNameAsync(registrationDto.Username);
            if (userExists is not null)
            {
                status.StatusCode = 0;
                status.Message = "Username already exists";

                return Ok(status);
            }

            var user = new ApplicationUser
            {
                UserName = registrationDto.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registrationDto.Email,
                Name = registrationDto.Name
            };

            // create a user here
            var createUser = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!createUser.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";

                return Ok(status);
            }

            // add roles here
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            status.StatusCode = 1;
            status.Message = "Successfully registered";

            return Ok(status);
        }

        [HttpPost]
        public async Task<IActionResult> RegistrationAdmin([FromBody] RegistrationDto registrationDto)
        {
            return Ok();

            var status = new StatusDto();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";

                return Ok(status);
            }

            var userExists = await _userManager.FindByNameAsync(registrationDto.Username);
            if (userExists is not null)
            {
                status.StatusCode = 0;
                status.Message = "Username already exists";

                return Ok(status);
            }

            var user = new ApplicationUser
            {
                UserName = registrationDto.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registrationDto.Email,
                Name = registrationDto.Name
            };

            // create a user here
            var createUser = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!createUser.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";

                return Ok(status);
            }

            // add roles here
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            status.StatusCode = 1;
            status.Message = "Admin role has been successfully registered";

            return Ok(status);
        }
    }
}
