using NUnit.Framework;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System;
using Structural;
using System.Xml;
using Structural.Adapter;
using System.Collections.Generic;
using System.Linq;

namespace GeneralTests.Structural
{
    public class AdapterUnitTests
    {
        [Test]
        public void ProptertyAdapterTest()
        {
            var stats = new CountryStats();
            stats.Capitals.Add("France", "Paris");
            var xs = new XmlSerializer(typeof(CountryStats));
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);
            xs.Serialize(stringWriter, stats);

            var xml = new XmlDocument();
            xml.LoadXml(stringBuilder.ToString());
            Assert.That(xml, Is.Not.EqualTo(null));

            var newStats = (CountryStats)xs.Deserialize(new StringReader(stringWriter.ToString()));
            Assert.That(newStats.Capitals["France"], Is.EqualTo("Paris"));
        }

        [Test]
        public void AdaterTest()
        {

            List<VectorObject> vectorObjects = new()
            {
                new VectorRectangle(1, 1, 10, 10),
                new VectorRectangle(3, 3, 6, 6)
            };


            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ToList().ForEach(p => Console.WriteLine($"X:{p.X} - Y:{p.Y}"));
                }
            }

            Assert.That(true, Is.True);
        }

        [Test]
        public void GenericValueAdaterTest()
        {
            var v = Vector2i.Create(8, 9);
            var vv = Vector2i.Create(3, 2);
            var result = vv + v;
            Assert.That(true, Is.True);
        }
    }
}
