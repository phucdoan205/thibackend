using Microsoft.AspNetCore.Mvc;

namespace thibackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("hello")]
        public IActionResult GetHello()
        {
            return Ok("Xin chào Swagger đã hoạt động!");
        }
    }
}
