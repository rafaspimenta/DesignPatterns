using System.Text.Json;

namespace Creational.Prototype
{
    public class Person
    {
        public string Name { get; set; }
        public Address Address { get; set; }

        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }
    }

    public class Address
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
    }

    public static class DeepCopyExtensionMethod
    {
        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonSerializer.Serialize(self);
            return JsonSerializer.Deserialize<T>(serialized);
        }
    }
}
