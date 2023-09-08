using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubBee.Api.Models.Domain;
using SubBee.Api.Models.Dtos;
using SubBee.Api.Repositories.Abstract;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ITokenService _tokenService;

        public TokenController(DatabaseContext databaseContext, ITokenService tokenService)
        {
            _databaseContext = databaseContext;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Refresh(RefreshTokenRequestDto refreshTokenRequestDto)
        {
            if (refreshTokenRequestDto is null)
                return BadRequest("Invalid client request");

            var accessToken = refreshTokenRequestDto.AccessToken;
            var refreshToken = refreshTokenRequestDto.RefreshToken;
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity?.Name;
            var user = _databaseContext.TokenInfo.SingleOrDefault(u => u.Username == username);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiry <= DateTime.Now)
                return BadRequest("Invalid client request");

            var newAccessToken = _tokenService.GetToken(principal.Claims);
            var newRefreshToken = _tokenService.GetRefreshToken();

            user.RefreshToken = newRefreshToken;
            _databaseContext.SaveChanges();

            return Ok(new RefreshTokenRequestDto { AccessToken = newAccessToken.TokenString, RefreshToken = newRefreshToken });
        }

        [HttpPost, Authorize]
        public IActionResult Revoke()
        {
            try
            {
                var username = User.Identity?.Name;
                var result = _tokenService.Revoke(username ?? string.Empty);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
