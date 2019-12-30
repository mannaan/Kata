using Kata.Checkout.Entities;
using System.Collections.Generic;

namespace Kata.Checkout.Repos
{
    public class DiscountRuleRepository : IDiscountRuleRepository
    {
        public IEnumerable<QuantityDiscountRule> GetQuantityDiscounts()
        {
            throw new System.NotImplementedException();
        }
    }
}
