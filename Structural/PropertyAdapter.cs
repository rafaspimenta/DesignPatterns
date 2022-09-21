using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Structural
{
    public class CountryStats
    {
        public (string, string)[] CapitalsSerializable
        {
            get
            {
                return Capitals.Keys.Select(country =>
                      (country, Capitals[country])).ToArray();
            }
            set
            {
                Capitals = value.ToDictionary(x => x.Item1, x => x.Item2);
            }
        }

        [XmlIgnore]
        public Dictionary<string, string> Capitals { get; private set; } = new();
    }
}
