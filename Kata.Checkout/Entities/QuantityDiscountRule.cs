namespace Kata.Checkout.Entities
{
    public class QuantityDiscountRule
    {
        public string OfferSku { get; set; }
        public string Name { get; set; }
        public string ProductSku { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
