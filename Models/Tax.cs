namespace OrderPricingSystem.Models
{
    public class Tax
    {
        public string Country { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

        public Tax (string country, decimal rate, decimal amount)
        {
            this.Country = country;
            this.Rate = rate;
            this.Amount = amount;
        }
    }
}
