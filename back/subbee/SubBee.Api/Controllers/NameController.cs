using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubBee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            return Ok();
        }
    }
}
