using Kata.Checkout.Entities;

namespace Kata.Checkout.Services
{
    public class Scanner : IScanner
    {
        private readonly IDiscountManager _discountManager;
        public Scanner(IDiscountManager discountManager)
        {
            _discountManager = discountManager;
        }
        public Basket Scan(Basket basket, Item item, int quantity)
        {
            if (quantity == 0)
                return basket;
            basket.LineItems.Add(new LineItem()
            {
                Quanity = quantity,
                UnitPrice = item.UnitPrice,
                Sku = item.Sku,
                Name = item.Name
            });
            basket = _discountManager.ApplyDiscounts(basket);
            return basket;
        }
    }
}
