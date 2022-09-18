namespace Creational.AbstractFactoryGeneric
{
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

    public class SimpleShapeFactory
    {
        public static IShape Create<T>()
            where T : IShape, new()
        {
            return new T();
        }
    }  
}
