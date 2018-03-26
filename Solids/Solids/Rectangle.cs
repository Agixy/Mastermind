namespace Solids
{
    using System;

    internal class Rectangle
    {
        public Rectangle(double a, double b)
        {
            if (double.IsNaN(a) || a < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), a, "wymiary powinny być dodatnie");
            }

            if (double.IsNaN(b) || b < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), b, "wymiary powinny być dodatnie");
            }

            A = Math.Min(a, b);
            B = Math.Max(a, b);
        }

        public double B { get; }

        public double A { get; }

        public double GetBaseArea()
        {
            return A * B;
        }
    }
}