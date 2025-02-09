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

        public FruitSaladController()
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            const string endpoint = "https://www.fruityvice.com/api/fruit/all";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(endpoint);
                var responseData = await response.Content.ReadAsStringAsync();
                fruits = JsonSerializer.Deserialize<List<Fruit>>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return Ok(fruits);
        }
    }
}
