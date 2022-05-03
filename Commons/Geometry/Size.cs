using System;

namespace Commons.Geometry
{
    /// <summary>
    /// Simpe size class used to store width and height of the entity.
    /// </summary>
    public sealed class Size
    {
        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; set; }
        public float Height { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Size size &&
                   Width == size.Width &&
                   Height == size.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height);
        }
    }
}
