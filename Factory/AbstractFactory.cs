namespace Factory
{
    public enum Shape
    {
        Square,
        Rectangle
    }
    public interface IShape
    {
        void Draw();
    }

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Basic square");
        }

        public static ShapeFactory GetFactory(bool rounded)
        {
            if (rounded)
                return new RoundedShapeFactory();
            else
                return new BasicShapeFactory();
        }
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Basic rectangle");
        }
    }

    public class RoundedSquare : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Rounded square");
        }
    }

    public class RoundedRectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Rounded rectangle");
        }
    }

    public abstract class ShapeFactory
    {
        public abstract IShape Create(Shape shape);
    }

    public class BasicShapeFactory : ShapeFactory
    {
        public override IShape Create(Shape shape)
        {
            if (shape == Shape.Square)
                return new Square();
            else
                return new Rectangle();
        }
    }

    public class RoundedShapeFactory : ShapeFactory
    {
        public override IShape Create(Shape shape)
        {
            if (shape == Shape.Square)
                return new RoundedSquare();
            else
                return new RoundedRectangle();
        }
    }
}
