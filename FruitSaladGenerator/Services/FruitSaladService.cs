using FruitSaladGenerator.Model;
using FruitSaladGenerator.Repositories;

namespace FruitSaladGenerator.Services
{
    public class FruitSaladService : IFruitSaladService
    {
        private readonly IFruitRepository fruitRepository;
        public FruitSaladService(IFruitRepository fruitRepository) 
        { 
            this.fruitRepository = fruitRepository;
        }
    }
}
