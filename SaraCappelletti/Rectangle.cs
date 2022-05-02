using System;

namespace SaraCappelletti
{
    internal class Rectangle
    {
        public Rectangle(double minX, double minY, double width, double height)
        {
            MinX = minX;
            MinY = minY;
            Width = width;
            Height = height;
        }

        public double MinX { get; }
        public double MinY { get; }
        public double Width { get; }
        public double Height { get; }
        public double MaxX => MinX + Width;
        public double MaxY => MinY + Height;

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle &&
                   MinX == rectangle.MinX &&
                   MinY == rectangle.MinY &&
                   Width == rectangle.Width &&
                   Height == rectangle.Height;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MinX, MinY, Width, Height);
        }
    }
}
