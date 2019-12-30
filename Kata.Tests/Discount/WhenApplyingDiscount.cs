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
        private IDiscountProcessor _discountProcessor;
        private Basket _basket;
        [SetUp]
        public void Setup()
        {
            var registry = new Ioc();
            _basket = new Basket();
            _scanner = registry.Container.Resolve<IScanner>();
            _discountProcessor = registry.Container.Resolve<IDiscountProcessor>();
        }
        [Test, TestCaseSource(typeof(DiscountTestCaseFactory), "BasketItemsTestCases")]
        public decimal ShouldAddOneLinePerDiscount(Basket basket)
        {
            _basket = _discountProcessor.Apply(basket);
            return _basket.LineItems.Count;
        }
        [Test, TestCaseSource(typeof(DiscountTestCaseFactory), "ScanTestCases")]
        public decimal ShouldCheckForDiscountOnEachScan(IList<dynamic> items)
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
