using Creational.Factory;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Inner = Creational.InnerFactory;
using Abstract = Creational.AbstractFactoryGeneric;

namespace GeneralTests.Creational.Factory
{
    public class FactoryUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FactoryMethod()
        {
            var cartesian =  Point.NewCartesianPoint(10, 20);
            var polar = Point.NewPolarPoint(20, 30);

            Assert.True(true);
        }

        [Test]
        public void InnerFactoryMethod()
        {
            var cartesian = Inner.Point.Factory.NewCartesianPoint(10, 20);
            var polar = Point.NewPolarPoint(20, 30);

            Assert.True(true);
        }

        [Test]
        public void AbstractFactory()
        {
            var shape = Square.GetFactory(false).Create(Shape.Square);
            Assert.True(true);
        }

        [Test]
        public void GenericAbstractFactory()
        {
            var shape = Abstract.SimpleShapeFactory.Create<Abstract.RoundedSquare>();
            shape.Draw();
            Assert.True(true);
        }

        [Test]
        public void DelegateFactory()
        {
            var services = new ServiceCollection();
            services.AddTransient<Service>();
            services.AddTransient(x => new DomainObject(x.GetService<Service>(), 40));

            var obj = services.BuildServiceProvider().GetService<DomainObject>();

            Assert.That(obj.ToString(), Is.EqualTo("I have 40"));
        }
    }
}