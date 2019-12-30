using Autofac;
using Kata.Checkout.Entities;
using Kata.Checkout.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Kata.Tests.Discount
{
    public class WhenApplyingDiscount
    {
        private IScanner _scanner;
        private Basket _basket;
        [SetUp]
        public void Setup()
        {
            var registry = new Ioc();
            _basket = new Basket();
            _scanner = registry.Container.Resolve<IScanner>();
        }
        [Test, TestCaseSource(typeof(DiscountTestCaseFactory), "LineItemTestCases")]
        public decimal ShouldAddOneLinePerDiscount(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.LineItems.Count;
        }
        [Test, TestCaseSource(typeof(DiscountTestCaseFactory), "TotalPriceTestCases")]
        public decimal ShouldReturnDiscountedTotal(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.Total();
        }
    }
}
