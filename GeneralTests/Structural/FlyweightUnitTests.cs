using NUnit.Framework;
using Structural.Decorator;
using Structural.Facade;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
using Structural.Flyweight;

namespace GeneralTests.Structural
{
    public class FlyweightUnitTests
    {
        public static string RandomString()
        {
            Random rand = new Random();
            return new string(
            Enumerable.Range(0, 10)
                     .Select(i => (char)('a' + rand.Next(26))).ToArray());
        }

        [Test]
        public void TestMagicSquare()
        {
            var firstNames = Enumerable.Range(0, 10).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 10).Select(_ => RandomString());

            var users = new List<User2>();
            foreach (var firstName in firstNames)
                foreach (var lastName in lastNames)
                    users.Add(new User2($"{firstName} {lastName}"));

            Assert.IsTrue(true, "");
        }

        [Test]
        public void TestTextFormmating()
        {
            var bft = new FormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;
            Assert.That(bft.ToString().Substring(10, 5), Is.EqualTo("BRAVE"));
        }
    }
}
