using System.Text.Json.Serialization;

namespace OrderPricingSystem.Models
{
    public class Product
    {
        
        public string Id { get; set; }

        
        public string Name { get; set; }

        
        public decimal Price { get; set; }
    }
}
