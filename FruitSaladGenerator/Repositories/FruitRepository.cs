using FruitSaladGenerator.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace FruitSaladGenerator.Repositories
{
    public class FruitRepository : IFruitRepository
    {
        private const string FRUITS_KEY = "fruits";
        private List<Fruit> _fruits;
        private readonly IMemoryCache _memoryCache;
        public FruitRepository(IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
            LoadFruitsFromJSON();
        }
        private void LoadFruitsFromJSON()
        {
            if (_memoryCache.TryGetValue(FRUITS_KEY, out List<Fruit> fruits))
            {
                _fruits = fruits;
                return;
            }
            var fileName = "fruits.json";
            var fruitsJson = File.ReadAllText(fileName);
            _fruits = JsonSerializer.Deserialize<List<Fruit>>(fruitsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var memoryCacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3),
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };

            _memoryCache.Set(FRUITS_KEY, _fruits, memoryCacheEntryOptions);
        }

        public Fruit Get(int id)
        {
            return _fruits.SingleOrDefault(f => f.Id == id);
        }

        public async Task<IList<Fruit>> Get()
        {
            return _fruits.ToList();
        }

        public void Add(Fruit fruit)
        {
            _fruits.Add(fruit);
        }

        public void AddAll(List<Fruit> fruits)
        {
            _fruits = fruits;
        }
    }
}
