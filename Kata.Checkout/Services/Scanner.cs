using Kata.Checkout.Entities;
using System;

namespace Kata.Checkout.Services
{
    public class Scanner : IScanner
    {
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
            return basket;
        }
    }
}
