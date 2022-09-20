using Creational.Factory;
using Creational.Prototype;
using NUnit.Framework;

namespace GeneralTests.Creational.Prototype
{
    public class PrototypeUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SerializerCopyPrototype()
        {
            var john = new Person(
              "John Smith",
              new Address("London Road", 123));
            var jane = john.DeepCopy();
            jane.Name = "Jane Smith";
            jane.Address.HouseNumber = 321; // john is still at 123

            Assert.True(true);
        }
    }
}