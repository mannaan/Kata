using Kata.Checkout.Entities;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Kata.Tests.Discount
{
    public class DiscountTestCaseFactory
    {
        public static IEnumerable ScanTestCases
        {
            get
            {
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 2
                    }

                }).Returns(2);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 3
                    }

                }).Returns(2);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="B15",
                        UnitPrice=0.3m,
                        Quantity = 1
                    },

                }).Returns(4);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 3
                    },
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 4
                    },
                    new
                    {
                        Sku="B15",
                        UnitPrice=0.3m,
                        Quantity = 2
                    },

                }).Returns(6);
            }
        }
        public static IEnumerable TotalPriceTestCases
        {
            get
            {
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 2
                    }

                }).Returns(0.45m);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 3
                    }

                }).Returns(1.3m);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="B15",
                        UnitPrice=0.3m,
                        Quantity = 1
                    },

                }).Returns(0.95);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 3
                    },
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 4
                    },
                    new
                    {
                        Sku="B15",
                        UnitPrice=0.3m,
                        Quantity = 2
                    },

                }).Returns(3);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="B15",
                        Name="B15",
                        UnitPrice=0.3m,
                        Quantity = 3
                    },
                    new
                    {
                        Sku="A99",
                        Name="A99",
                        UnitPrice=0.5m,
                        Quantity = 4
                    },
                    new
                    {
                        Sku="B15",
                        UnitPrice=0.3m,
                        Quantity = -2
                    },

                }).Returns(2.1);
            }
        }

        public static IEnumerable BasketItemsTestCases
        {
            get
            {
                yield return new TestCaseData(new Basket()
                {
                    LineItems = new List<LineItem>()
                    {
                       new LineItem{Name="B15",Quanity=1,Sku="B15",UnitPrice=0.3m},
                       new LineItem{Name="B15",Quanity=1,Sku="B15",UnitPrice=0.3m},
                    }
                }).Returns(3);
                yield return new TestCaseData(new Basket()
                {
                    LineItems = new List<LineItem>()
                    {
                       new LineItem{Name="B15",Quanity=5,Sku="B15",UnitPrice=0.3m},
                       new LineItem{Name="B15",Quanity=2,Sku="B15",UnitPrice=0.3m},
                    }
                }).Returns(5);
                yield return new TestCaseData(new Basket()
                {
                    LineItems = new List<LineItem>()
                    {
                       new LineItem{Name="B15",Quanity=5,Sku="B15",UnitPrice=0.3m},
                       new LineItem{Name="A99",Quanity=2,Sku="A99",UnitPrice=0.3m},
                       new LineItem{Name="B15",Quanity=2,Sku="B15",UnitPrice=0.3m},

                    }
                }).Returns(6);
            }
        }
    }
}
