using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialHubAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetFeed()
        {
            return Ok(new { message = "Conteúdo do feed protegido!" });
        }
    }
}
