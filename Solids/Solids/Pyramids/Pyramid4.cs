namespace Solids.Pyramids
{
    public class Pyramid4 : Pyramid
    {
        private readonly Rectangle _baseRectangle;

        public Pyramid4(double height, double a, double b) : base(height)
        {
            _baseRectangle = new Rectangle(a, b);
        }

        public double A => _baseRectangle.A;
        public double B => _baseRectangle.B;

        protected override double GetBaseArea()
        {
            return _baseRectangle.GetBaseArea();
        }

        protected override bool EqualLocalDimensions(Solid other)
        {
            return _baseRectangle.Equals((other as Pyramid4)?._baseRectangle);
        }
    }
}
