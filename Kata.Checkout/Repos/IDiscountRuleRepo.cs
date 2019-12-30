using Kata.Checkout.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Checkout.Repos
{
    public interface IDiscountRuleRepository
    {
        IEnumerable<QuantityDiscountRule> GetQuantityDiscounts();
    }
}
