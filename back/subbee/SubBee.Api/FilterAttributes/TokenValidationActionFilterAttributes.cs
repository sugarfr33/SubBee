
using System.Web.Http.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SubBee.Api.Repositories.Abstract;

namespace SubBee.Api.FilterAttributes
{
    public class TokenValidationActionFilterAttributes : ActionFilterAttribute
    {
        private readonly ITokenService _tokenService;
        public TokenValidationActionFilterAttributes(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            
        }
    }
}
