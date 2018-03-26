namespace Solids
{
    using System;
    public abstract class Solid : IComparable<Solid>, IEquatable<Solid>
    {
        protected Solid(double height)
        {
            if(double.IsNaN(height) || height<0)
                throw new ArgumentOutOfRangeException(nameof(height), height, "wymary powinny być dodatnie");
            Height = height;
        }

        public double Height { get; }
        public abstract double GetVolume();

        public int CompareTo(Solid other)
        {
            return other == null 
                ? 1 
                : GetVolume().CompareTo(other.GetVolume());
        }

        public bool Equals(Solid other)
        {
            if (ReferenceEquals(null, other)) return false;
            return Height.Equals(other.Height) && EqualLocalDimensions(other);
        }

        public sealed override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Solid)obj);
        }

        public override int GetHashCode()
        {
            return GetVolume().GetHashCode();
        }

        protected abstract bool EqualLocalDimensions(Solid other);
    }
}
