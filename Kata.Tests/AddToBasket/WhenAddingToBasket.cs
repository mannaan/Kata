using Autofac;
using Kata.Checkout.Entities;
using Kata.Checkout.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace Kata.Tests.AddToBasket
{
    public class WhenAddingToBasket
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
        [Test, TestCaseSource(typeof(AddToBasketTestCaseFactory), "LineItemsTestCases")]
        public int ShouldHaveOneLineItemPerScan(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.LineItems.Count;
        }

        [Test, TestCaseSource(typeof(AddToBasketTestCaseFactory), "TotalQuantityTestCases")]
        public int TotalQuantityAddsUp(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.LineItems.Sum(i => i.Quanity);
        }
    }
}
