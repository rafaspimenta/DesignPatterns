using System;
using System.Collections.Generic;
using System.Linq;

namespace Structural.Flyweight
{
    public class User
    {
        public string FullName { get; }
        public User(string fullName)
        {
            FullName = fullName;
        }
    }

    public class User2
    {
        private static List<string> strings = new();
        private int[] names; //flyweight

        public User2(string fullName)
        {
            names = fullName.Split(' ').Select(GetOrAdd).ToArray();

            int GetOrAdd(string s)
            {
                if (string.IsNullOrEmpty(s))
                {
                    throw new ArgumentNullException(s);
                }

                var idx = strings.IndexOf(s);
                if (idx == -1)
                {
                    idx = strings.Count + 1;
                    strings[idx] = s;
                }
                return idx;
            }
        }

        public string FullName => string.Join(" ", names.Select(i => strings[i]));
    }
}
