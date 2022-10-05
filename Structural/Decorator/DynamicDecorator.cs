using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Decorator
{
    public abstract class Shape
    {
        public virtual string AsString() => string.Empty;
    }

    public sealed class Circle : Shape
    {
        private float radius;
        public Circle() : this(0)
        { }
        public Circle(float radius)
        {
            this.radius = radius;
        }
        public void Resize(float factor)
        {
            radius *= factor;
        }
        public override string AsString() => $"A circle of radius {radius}";
    }

    public sealed class Square : Shape
    {
        private readonly float side;

        public Square() : this(0)
        { }
        public Square(float side)
        {
            this.side = side;
        }
        public override string AsString() => $"A square with side {side}";
    }

    public class ColoredShape : Shape
    {
        private readonly Shape shape;
        private readonly string color;

        public ColoredShape(Shape shape, string color)
        {
            this.color = color;
            this.shape = shape;
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }

    public class TransparentShape : Shape
    {
        private readonly Shape shape;
        private readonly float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString() =>
          $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }
}
