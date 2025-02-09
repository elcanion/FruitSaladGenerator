using FruitSaladGenerator.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace FruitSaladGenerator.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class FruitSaladController : Controller
    {
        private List<Fruit> fruits;
        private const string FRUITS_KEY = "Fruits";
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IMemoryCache memoryCache;

        public FruitSaladController(IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            this.httpClientFactory = httpClientFactory;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (this.memoryCache.TryGetValue(FRUITS_KEY, out List<Fruit> fruits))
            {
                return Ok(fruits);
            }
            var httpClient = httpClientFactory.CreateClient("FruityViceAPI");
            var response = await httpClient.GetAsync("api/fruit/all");
            var responseData = await response.Content.ReadAsStringAsync();
            fruits = JsonSerializer.Deserialize<List<Fruit>>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3),
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };

            this.memoryCache.Set(FRUITS_KEY, fruits, memoryCacheEntryOptions);
            return Ok(fruits);
        }
    }
}
