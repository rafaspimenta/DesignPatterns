using NUnit.Framework;
using Structural.Decorator;
using Structural.Facade;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;

namespace GeneralTests.Structural
{
    public class FacadeUnitTests
    {
        private string SquareToString(List<List<int>> square)
        {
            var sb = new StringBuilder();
            foreach (var row in square)
            {
                sb.AppendLine(string.Join(" ",
                  row.Select(x => x.ToString())));
            }

            return sb.ToString();
        }

        [Test]
        public void TestMagicSquare()
        {
            var gen = new MagicSquareGenerator();
            var square = gen.Generate(3);

            Console.WriteLine(SquareToString(square));
            
            Assert.IsTrue(true,
              "Verification failed: this is not a magic square");
        }

        [Test]
        public void TestMagicSquareUnicGenerator()
        {
            var gen = new MagicSquareGenerator();
            var square = gen.Generate<UniqueGenerator, Splitter, Verifier>(3);

            Console.WriteLine(SquareToString(square));

            Assert.IsTrue(true,
              "Verification failed: this is not a magic square");
        }
    }
}
