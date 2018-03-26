namespace Solids
{
    using System;

    public class Ball : Solid
    {
        public Ball(double radius) : base(radius * 2)
        {
        }

        public override double GetVolume()
        {
            return 4 * Math.PI * Math.Pow(Height / 2, 3) / 3;
        }

        protected override bool EqualLocalDimensions(Solid other)
        {
            return true;
        }
    }
}
