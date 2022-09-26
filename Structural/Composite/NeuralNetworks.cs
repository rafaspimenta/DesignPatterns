using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Composite
{
    public class Neuron : IEnumerable<Neuron>
    {
        public List<Neuron> In = new(), Out = new();

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {
        public NeuronLayer(int count)
        {
            while (count-- > 0)
                Add(new Neuron());
        }
    }

    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;
            foreach (var from in self)
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
        }
    }

    public interface IScalar<out T> where T : IScalar<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            yield return (T)this;
        }
    }

    public class Foo : IScalar<Foo> 
    {
        public Foo()
        {
            var foo = new Foo();
            foreach (var item in foo as IScalar<Foo>)
            {

            }
        }
    }
}