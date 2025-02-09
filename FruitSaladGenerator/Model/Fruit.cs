using System.Text.Json.Serialization;

namespace FruitSaladGenerator.Model
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("nutritions")]
        public Nutrition Nutrition { get; set; }
    }
}
