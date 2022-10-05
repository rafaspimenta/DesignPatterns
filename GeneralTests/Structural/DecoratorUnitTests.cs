using NUnit.Framework;
using Structural.Decorator;

namespace GeneralTests.Structural
{
    public class DecoratorUnitTests
    {
        [Test]
        public void CustomStringBuilderTest()
        {
            CodeBuilder cb = "hello";
            cb += " world";
            Assert.That(cb.ToString(), Is.EqualTo("hello world").NoClip);
        }

        [Test]
        public void MultipleInheritanceInterfacesTest()
        {
            var dragon = new Dragon(new Bird(), new Lizard()) { Age = 2 };

            Assert.That(dragon.Fly(), Is.EqualTo("too young"));
            Assert.That(dragon.Crawl(), Is.EqualTo("crawling"));
        }

        [Test]

        public void DynamicDecoratorTest()
        {
            var circle = new Circle(2);
            Assert.That(circle.AsString(), Is.EqualTo("A circle of radius 2"));

            var redCircle = new ColoredShape(circle, "red");
            Assert.That(redCircle.AsString(), Is.EqualTo("A circle of radius 2 has the color red"));

            var redHalfTransparentSquare = new TransparentShape(redCircle, 0.5f);
            Assert.That(redHalfTransparentSquare.AsString(), Is.EqualTo("A circle of radius 2 has the color red has 50% transparency"));
        }
    }
}
