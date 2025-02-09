using FruitSaladGenerator.Model;

namespace FruitSaladGenerator.Repositories
{
    public interface IFruitRepository
    {
        Fruit Get(int id);
        Task<IList<Fruit>> Get();
        void Add(Fruit fruit);
        void AddAll(List<Fruit> fruits);
    }
}