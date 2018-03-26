namespace Solids
{
    using System;

    internal class Triangle
    {
        public Triangle(double a, double b, double c)
        {
            var edges = new[] { a, b, c };
            Array.Sort(edges);

            A = edges[0];
            B = edges[1];
            C = edges[2];
        }

        public double A { get; }
        public double B { get; }
        public double C { get; }

        public double GetBaseArea()
        {
            double p = (A + B + C) / 2;

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}