using Kata.Checkout.Entities;
using Kata.Checkout.Repos;
using System.Collections.Generic;
using System.Linq;

namespace Kata.Checkout.Services
{
    public class QuantityDiscountProcessor : IDiscountProcessor
    {
        private IEnumerable<QuantityDiscountRule> _discountRules;

        public QuantityDiscountProcessor(IDiscountRuleRepository discounRepository)
        {
            _discountRules = discounRepository.GetQuantityDiscounts();
        }

        public Basket Apply(Basket basket)
        {
            if (_discountRules == null || !_discountRules.Any())
                return basket;
            if (basket == null || !basket.LineItems.Any())
                return basket;
            foreach (var scannedSku in basket.LineItems.Select(i => i.Sku).Distinct().ToList())
            {
                var rule = _discountRules.FirstOrDefault(r => r.ProductSku.Equals(scannedSku));
                if (rule == null)
                    continue;
                var totalItem = basket.LineItems.Where(i => i.Sku.Equals(rule.ProductSku)).Sum(i => i.Quanity);
                var appliedDiscounts = basket.LineItems.Count(i => i.Sku.Equals(rule.OfferSku));
                var expectedDiscounts = (int)totalItem / rule.Quantity;
                if (expectedDiscounts == appliedDiscounts) continue;
                if (expectedDiscounts < appliedDiscounts)
                {
                    AddDiscountLineItems(basket, appliedDiscounts - expectedDiscounts, rule,true);
                }
                else
                {
                    AddDiscountLineItems(basket, expectedDiscounts - appliedDiscounts, rule);
                }


            }

            return basket;
        }

        private void AddDiscountLineItems(Basket basket, int itemsToBeAdded, QuantityDiscountRule rule,bool reverse = false)
        {
            for (var i = 0; i < itemsToBeAdded; i++)
            {
                basket.LineItems.Add(new LineItem()
                {
                    Quanity = 1,
                    Sku = rule.OfferSku,
                    UnitPrice = reverse? rule.DiscountAmount : -1 * rule.DiscountAmount
                });
            }
        }
    }
}
