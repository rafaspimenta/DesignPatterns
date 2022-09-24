using System;

namespace Structural.Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public abstract class Shape
    {
        protected IRenderer _renderer;

        // a bridge between the shape that's being drawn an the renderer which actually draws it
        public Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float radius);
    }

    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            _renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for circle of radius {radius}");
        }
    }
}
