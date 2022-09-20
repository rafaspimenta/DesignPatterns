using Structural.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Structural
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo.Draw();
            Demo.Draw();
        }
    }

    public class Demo
    {

        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
            new VectorRectangle(1, 1, 10, 10),
            new VectorRectangle(3, 3, 6, 6)
        };

        public static void DrawPoint(Point p)
        {
            // fake draw point
            Console.WriteLine($"X:{p.X} - Y:{p.Y}");
        }

        public static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ToList().ForEach(DrawPoint);
                }
            }
        }
    }
}