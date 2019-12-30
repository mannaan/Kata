namespace Kata.Checkout.Entities
{
    public class LineItem
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quanity { get; set; }
        public decimal Total => Quanity * UnitPrice;
    }
}
