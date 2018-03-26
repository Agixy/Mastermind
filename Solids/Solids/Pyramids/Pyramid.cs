namespace Solids.Pyramids
{
    public abstract class Pyramid : Solid
    {
        protected Pyramid(double height) : base(height)
        {
        }

        public override double GetVolume()
        {
            return GetBaseArea() * Height / 3;
        }

        protected abstract double GetBaseArea();
    }
}
