using Kata.Checkout.Entities;
using System.Collections.Generic;

namespace Kata.Checkout.Services
{
    public class DiscountManager : IDiscountManager
    {
        private readonly IEnumerable<IDiscountProcessor> _discProcessor;

        public DiscountManager(IEnumerable<IDiscountProcessor> discProcessor)
        {
            _discProcessor = discProcessor;
        }

        public Basket ApplyDiscounts(Basket basket)
        {
            foreach (var discountProcessor in _discProcessor)
            {
                basket = discountProcessor.Apply(basket);
            }
            return basket;
        }
    }
}
