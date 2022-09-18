namespace InnerFactory
{
    public class Point
    {
        private Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; }
        public double Y { get; }

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y) => new(x, y);
            public static Point NewPolarPoint(double rho, double theta) => new(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }
}