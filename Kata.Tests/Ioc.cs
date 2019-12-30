using Autofac;
using Kata.Checkout.Services;
using System;
using System.Collections.Generic;
using System.Text;

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
            _container = builder.Build();

        }
    }
}
