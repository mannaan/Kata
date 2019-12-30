using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
namespace Kata.Tests.AddToBasket
{
    public class AddToBasketTestCaseFactory
    {
        public static IEnumerable LineItemsTestCases
        {
            get
            {
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 0
                    }

                }).Returns(0);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 2
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.45m,
                        Quantity = 4
                    },

                }).Returns(3);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 4
                    },
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = -2
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.45m,
                        Quantity = 3
                    }

                }).Returns(3);
            }
        }

        public static IEnumerable TotalQuantityTestCases
        {
            get
            {
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 0
                    }

                }).Returns(0);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 4
                    },
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = -2
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.45m,
                        Quantity = 3
                    }

                }).Returns(5);
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 2
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.45m,
                        Quantity = 4
                    },

                }).Returns(7);
            }
        }
    }
}
