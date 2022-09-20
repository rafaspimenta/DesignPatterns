using Creational.Singleton;
using NUnit.Framework;

namespace GeneralTests.Creational.Singleton
{
    public class SingletonUnitTests
    {
        [Test]
        public void SingletonTotalPopulationTest()
        {
            // testing on a live database
            var instance = SingletonDatabase.Instance;
            var instance2 = SingletonDatabase.Instance;
            Assert.That(instance, Is.EqualTo(instance2));
        }
    }
}
