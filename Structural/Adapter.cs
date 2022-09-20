using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Structural.Adapter
{
    public class Point
    {
        public int X, Y;

        public Point(int y, int x)
        {
            Y = y;
            X = x;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public override bool Equals(object obj)
        {
            return obj is Line line &&
                   EqualityComparer<Point>.Default.Equals(Start, line.Start) &&
                   EqualityComparer<Point>.Default.Equals(End, line.End);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }
    }

    public abstract class VectorObject : Collection<Line> { }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(start: new Point(x, y), end: new Point(x + width, y)));
            Add(new Line(start: new Point(x + width, y), end: new Point(x + width, y + height)));
            Add(new Line(start: new Point(x, y), end: new Point(x, y + height)));
            Add(new Line(start: new Point(x, y + height), end: new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count = 0;
        private static readonly Dictionary<int, List<Point>> cache = new();
        private readonly int hash;

        public LineToPointAdapter(Line line)
        {
            hash = line.GetHashCode();
            if (cache.ContainsKey(hash)) return;

            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X},{line.Start.Y}]" +
                $"-[{line.End.X},{line.End.Y}] (with caching)");


            List<Point> points = new();

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);
            int dx = right - left;
            int dy = line.End.Y - line.Start.Y;

            if (dx == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (dy == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }

            cache.Add(hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return cache[hash].GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
