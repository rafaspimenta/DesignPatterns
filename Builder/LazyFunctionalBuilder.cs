using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder
{
    /// <summary>
    /// We’ll define a lazy builder that only constructs the object when its Build() method is called. 
    /// Until that time, it will simply keep a list of Actions that need to be performed when an object is built
    /// </summary>
    public class PersonBuilder
    {
        private readonly List<Func<Person, Person>> _actions = new();

        public PersonBuilder Do(Action<Person> action)
        {
            _actions.Add(p => { action(p); return p; });
            return this;
        }

        public Person Build()
        {
            var person = new Person();
            _actions.ForEach(a => a(person));
            return person;
        }

        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    public class Person
    {
        public string Name, Position;
    }

}
