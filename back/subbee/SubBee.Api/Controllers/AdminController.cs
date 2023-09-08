using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubBee.Api.FilterAttributes;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    [Authorize(Roles="admin")]
    public class AdminController : ControllerBase
    {
        public IActionResult GetDate()
        {
            return Ok("data from admin controller");
        }
    }
}
