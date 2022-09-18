using Factory;
using NUnit.Framework;

namespace GeneralTests.Factory
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
            var cartesian = Point.NewCartesianPoint(10, 20);
            var polar = Point.NewPolarPoint(20, 30);

            Assert.True(true);
        }

        [Test]
        public void InnerFactoryMethod()
        {
            var cartesian = InnerFactory.Point.Factory.NewCartesianPoint(10, 20);
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
            var shape = AbstractFactoryGeneric.SimpleShapeFactory.Create<AbstractFactoryGeneric.RoundedSquare>();
            shape.Draw();
            Assert.True(true);
        }
    }
}