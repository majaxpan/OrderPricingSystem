using OrderPricingSystem.Models;
using System.Text.Json;

namespace OrderPricingSystem.Services
{
    public class PricingService
    {
        public PricingResponse CalculatePrice(OrderRequest request)
        {
            var product = GetProduct(request.ProductId);
            decimal subtotal = request.Quantity * product.Price;
            // Calculate discount
            decimal discountPct = CalculateDiscount(request.Quantity, subtotal);
            decimal discountAmount = subtotal * discountPct;

            decimal subtotalAfterDiscount = subtotal - discountAmount; //Tax is calculated on the amount AFTER discounts, so i needed subtotal minus the calculated discount

            // Calculate tax
            decimal taxRate = GetTaxRate(request.Country);
            decimal taxAmount = subtotalAfterDiscount * taxRate;
            decimal finalPrice = subtotalAfterDiscount + taxAmount;
            return BuildResponse(product, request, subtotal, discountPct, discountAmount, subtotalAfterDiscount, taxRate, taxAmount, finalPrice);
        }
        private decimal CalculateDiscount(int quantity, decimal subtotal)
        {
            decimal discount = 0;
            if (subtotal >= 500) //Discounts only apply if subtotal ≥ 500 EUR, so i check >= instead od >
            {
                if (quantity >= 10 && quantity <50) // Apply 5% discount if quantity is within 10-49
                    discount = 0.05m;
                else if (quantity >= 50 && quantity <100) //10% discount if quantity is within 50-99
                    discount = 0.10m;
                else if (quantity == 100) //15% discount if quantity is 100
                    discount = 0.15m;
            }
            return discount;
        }
        private decimal GetTaxRate(string country)
        {
            return country switch
            {
                "MK" => 0.18m,
                "DE" => 0.20m,
                "FR" => 0.20m,
                "USA" => 0.10m,
                _ => 0.20m
            };
        }
        private Product GetProduct(string productId)
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "products.json");
                if (!File.Exists(filePath))
                    throw new Exception($"Products file not found: {filePath}");

                string file = File.ReadAllText(filePath);

                ProductList products = JsonSerializer.Deserialize<ProductList>(file, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                Product product = products.Products.FirstOrDefault(p => p.Id == productId);

                if (product == null)
                    throw new Exception($"Product with id {productId} was not found.");

                return product;
            }
            catch (Exception ex) {
                throw new Exception("An error occurred while loading the product.", ex);
            }
        }
        private PricingResponse BuildResponse(Product product, OrderRequest request, decimal subtotal, decimal discountPct, 
            decimal discountAmount, decimal subtotalAfterDiscount, decimal taxRate, decimal taxAmount, decimal finalPrice)
        {
            Discount discount = new Discount(discountPct, discountAmount);
            Tax tax = new Tax(request.Country, taxRate, taxAmount);
            
            PricingResponse response = new PricingResponse(product.Id, product.Name, request.Quantity, product.Price, request.Country, 
                subtotal, discount, subtotalAfterDiscount, tax, finalPrice);
            return response;
        }
    }
}
