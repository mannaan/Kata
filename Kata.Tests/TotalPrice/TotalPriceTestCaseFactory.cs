using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Kata.Tests.TotalPrice
{
    public class TotalPriceTestCaseFactory
    {
        public static IEnumerable SingleUnitTestCases
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
                        Quantity = 1
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.55m,
                        Quantity = 1
                    },

                }).Returns(1.45);

            }
        }
        public static IEnumerable MultipleUnitTestCases
        {
            get
            {
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 2
                    },
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 1
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.55m,
                        Quantity = 3
                    },

                }).Returns(3);

            }
        }

        public static IEnumerable UnScanUnitTestCases
        {
            get
            {
                yield return new TestCaseData(new List<dynamic>() {
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = 2
                    },
                    new
                    {
                        Sku="C40",
                        Name="C40",
                        UnitPrice=0.45m,
                        Quantity = -1
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.55m,
                        Quantity = 3
                    },
                    new
                    {
                        Sku="B99",
                        Name="B99",
                        UnitPrice=0.55m,
                        Quantity = -3
                    },

                }).Returns(0.45);
            }
        }
    }
}
