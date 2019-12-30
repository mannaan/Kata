using Autofac;
using Kata.Checkout.Entities;
using Kata.Checkout.Repos;
using Kata.Checkout.Services;
using Moq;
using System.Collections.Generic;

namespace Kata.Tests
{
    public class Ioc
    {
        private readonly IContainer _container;
        public IContainer Container
        {
            get { return _container; }
        }

        public Ioc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Scanner>().As<IScanner>();
            builder.RegisterType<QuantityDiscountProcessor>().As<IDiscountProcessor>();

            var discountMoq = new Mock<IDiscountRuleRepository>();

            discountMoq.Setup(x => x.GetQuantityDiscounts()).Returns(new List<QuantityDiscountRule>()
            {
                new QuantityDiscountRule(){Name = "A99 multi buy discount", OfferSku="OA99",ProductSku="A99",Quantity=3, DiscountAmount = 0.2m},
                new QuantityDiscountRule(){Name = "B15 multi buy discount",OfferSku="OB15",ProductSku="B15",Quantity=2, DiscountAmount = 0.15m}
            });
            builder.RegisterInstance(discountMoq.Object).As<IDiscountRuleRepository>();
            _container = builder.Build();

        }
    }
}
