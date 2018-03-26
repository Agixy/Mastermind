namespace Solids.Prisms
{
    public class Prism3 : Prism
    {
        private readonly Triangle _baseTriangle;

        public Prism3(double height, double a, double b, double c) : base(height)
        {
            _baseTriangle = new Triangle(a,b,c);
        }

        public double A => _baseTriangle.A;

        public double B => _baseTriangle.B;
        public double C => _baseTriangle.C;

        protected override double GetBaseArea()
        {
            return _baseTriangle.GetBaseArea();
        }

        protected override bool EqualLocalDimensions(Solid other)
        {
            return _baseTriangle.Equals((other as Prism3)?._baseTriangle);
        }
    }
}
