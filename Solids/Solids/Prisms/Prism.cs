namespace Solids.Prisms
{
    public abstract class Prism : Solid
    {
        protected Prism(double height) : base(height)
        {
        }

        public override double GetVolume()
        {
            return Height * GetBaseArea();
        }

        protected abstract double GetBaseArea();
    }
}
