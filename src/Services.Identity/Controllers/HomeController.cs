using Microsoft.AspNetCore.Mvc;

namespace Services.Identity.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Services.Identity API!");
    }
}