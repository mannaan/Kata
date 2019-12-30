using Kata.Checkout.Entities;
using System;

namespace Kata.Checkout.Services
{
    public class Scanner : IScanner
    {
        private readonly IDiscountProcessor _discountProcessor;
        public Scanner(IDiscountProcessor discountProcessor)
        {
            _discountProcessor = discountProcessor;
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
            basket = _discountProcessor.Apply(basket);
            return basket;
        }
    }
}
