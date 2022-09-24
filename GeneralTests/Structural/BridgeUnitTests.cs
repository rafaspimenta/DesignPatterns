using NUnit.Framework;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Structural.Bridge;

namespace GeneralTests.Structural
{
    public class BridgeUnitTests
    {
        [Test]
        public void ConventionalUnitTest()
        {
            var raster = new RasterRenderer();
            var vector = new VectorRenderer();
            var circle = new Circle(raster, 10);
            var circle2 = new Circle(vector, 10);
            circle.Draw();
            circle2.Draw();
            Assert.That(true);
        }
    }
}
