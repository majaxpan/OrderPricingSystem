namespace OrderPricingSystem.Models
{
    public class Discount
    {
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }

        public Discount(decimal Percentage, decimal Amount) {
            this.Percentage = Percentage;
            this.Amount = Amount;
        }
    }
}
