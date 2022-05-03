using System;

namespace Commons.Geometry
{
    /// <summary>
    /// Simple point class used to store coordinates of a entity on the game. 
    /// </summary>
    public sealed class Point
    {
        /// <summary>
        /// Create a new Point
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
        public float X { get; set; }
        public float Y { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
