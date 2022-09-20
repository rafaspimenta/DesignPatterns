using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private readonly Dictionary<string, int> capitals;
        private SingletonDatabase()
        {
            capitals = new Dictionary<string, int>()
            {
                { "minas", 2 },
                { "sao paulo", 5 }
            };
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
        private static readonly Lazy<SingletonDatabase> instance = new(new SingletonDatabase());

        public static IDatabase Instance => instance.Value;
    }
}
