using NUnit.Framework;
using Structural.Bridge;
using Structural.Proxy;

namespace GeneralTests.Structural
{
    public class ProxyUnitTests
    {
        [Test]
        public void ProxyTest()
        {
            MasonrySettings masonrySettings = new();
            Assert.That(masonrySettings.All, Is.False.Or.Null);
            masonrySettings.Pillars = true;
            Assert.That(masonrySettings.All, Is.False.Or.Null);
            masonrySettings.Floors = true;
            Assert.That(masonrySettings.All, Is.False.Or.Null);
            masonrySettings.Walls = true;
            Assert.That(masonrySettings.All, Is.True);
        }

        [Test]
        public void DynamicProxy()
        {
            var ba = Log<BankAccount>.As<IBankAccount>();
            ba.Withdraw(100);
            ba.Withdraw(200);
            ba.Deposit(500);
            System.Console.WriteLine();
        }
    }
}
