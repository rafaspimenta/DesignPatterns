using NUnit.Framework;
using Structural.Composite;
using System.Net.Http.Headers;

namespace GeneralTests.Structural
{
    public class CompositeUnitTests
    {
        [Test]
        public void GroupingGraphicObjectsUnitTest()
        {
            var drawing = new GraphicObject() { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });

            drawing.Children.Add(group);

            Assert.That(drawing.ToString(), Is.Not.Empty);
        }

        [Test]
        public void NeuralNetworksTest()
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            var layer1 = new NeuronLayer(3);
            var layer2 = new NeuronLayer(4);
            neuron1.ConnectTo(neuron2);
            neuron1.ConnectTo(layer1);
            layer2.ConnectTo(neuron1);
            layer1.ConnectTo(layer2);            

            Assert.That(true);
        }
    }
}
