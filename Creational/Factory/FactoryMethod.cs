using System;

namespace Creational.Factory
{
    public class Point
    {
        protected Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point NewCartesianPoint(double x, double y) => new(x, y);
        public static Point NewPolarPoint(double rho, double theta) => new(rho * Math.Cos(theta), rho * Math.Sin(theta));

        public double X { get; }
        public double Y { get; }
    }
}
