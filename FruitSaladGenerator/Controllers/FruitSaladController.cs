using FruitSaladGenerator.Model;
using FruitSaladGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace FruitSaladGenerator.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class FruitSaladController : Controller
    {
        private IList<Fruit> fruits;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IFruitSaladService fruitSaladService;

        public FruitSaladController(
            IHttpClientFactory httpClientFactory,
            IFruitSaladService fruitSaladService
            )
        {
            this.httpClientFactory = httpClientFactory;
            this.fruitSaladService = fruitSaladService;
        }

        [HttpGet(Name = "Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(fruits);
        }
    }
}
