namespace Solids.Prisms
{
    using System.Collections.Generic;
    using System.Linq;

    public class Prism4 : Prism
    {
        private readonly Rectangle _baseRectangle;

        public Prism4(double a, double b, double c) : base( new []{a,b,c}.Max())
        {
            var edges = new List<double> {a,b,c};
            edges.Remove(Height);

            _baseRectangle = new Rectangle(edges[0], edges[1]);
        }

        public double A => _baseRectangle.A;
        public double B => _baseRectangle.B;

        protected override double GetBaseArea()
        {
            return _baseRectangle.GetBaseArea();
        }

        protected override bool EqualLocalDimensions(Solid other)
        {
            return _baseRectangle.Equals((other as Prism4)?._baseRectangle);
        }
    }
}
