using Autofac;
using Kata.Checkout.Entities;
using Kata.Checkout.Services;
using Kata.Tests.TotalPrice;
using NUnit.Framework;
using System.Collections.Generic;

namespace Kata.Tests.AddToBasket
{
    public class WhenCalculatingTotalWithoutDiscount
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
        [Test, TestCaseSource(typeof(TotalPriceTestCaseFactory), "SingleUnitTestCases")]
        public decimal ShouldAddAllLineItems(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.Total();
        }
        [Test, TestCaseSource(typeof(TotalPriceTestCaseFactory), "MultipleUnitTestCases")]
        public decimal ShouldMultipleWithQuanitties(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.Total();
        }
        [Test, TestCaseSource(typeof(TotalPriceTestCaseFactory), "UnScanUnitTestCases")]
        public decimal ShouldDeductUnScannedItems(IList<dynamic> items)
        {
            foreach (var item in items)
            {
                _basket = _scanner.Scan(_basket, new Item() { Sku = item.Sku, UnitPrice = item.UnitPrice }, item.Quantity);
            }
            return _basket.Total();
        }
    }
}
