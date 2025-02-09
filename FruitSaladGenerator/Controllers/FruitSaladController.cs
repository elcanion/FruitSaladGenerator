using FruitSaladGenerator.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FruitSaladGenerator.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class FruitSaladController : Controller
    {
        private List<Fruit> fruits;
        private readonly IHttpClientFactory httpClientFactory;

        public FruitSaladController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = httpClientFactory.CreateClient("FruityViceAPI");
            var response = await httpClient.GetAsync("api/fruit/all");
            var responseData = await response.Content.ReadAsStringAsync();
            fruits = JsonSerializer.Deserialize<List<Fruit>>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Ok(fruits);
        }
    }
}
