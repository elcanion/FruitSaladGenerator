using Microsoft.AspNetCore.Mvc;

namespace FruitSaladGenerator.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class FruitSaladController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
