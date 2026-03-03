namespace OrderPricingSystem.Models
{
    public class PricingResponse
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string Country { get; set; }

        public decimal Subtotal { get; set; }

        public Discount Discount { get; set; }

        public decimal SubtotalAfterDiscount { get; set; }
        public Tax Tax { get; set; }

        public decimal finalPrice { get; set; }
        
        public PricingResponse(string ProductId, string ProductName, int Quantity, decimal UnitPrice, 
            string Country, decimal Subtotal, Discount Discount, decimal SubtotalAfterDiscount, Tax Tax, decimal finalPrice)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Quantity = Quantity;
            this.UnitPrice = UnitPrice;
            this.Country = Country;
            this.Subtotal = Subtotal;
            this.Discount = Discount;
            this.SubtotalAfterDiscount = SubtotalAfterDiscount;
            this.Tax = Tax;
            this.finalPrice = finalPrice;
        }
    }
}
