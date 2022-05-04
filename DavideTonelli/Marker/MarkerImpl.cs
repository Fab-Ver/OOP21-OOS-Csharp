using Commons.Geometry;

namespace DavideTonelli.Marker
{
    /// <summary>
    /// A simple marker.
    /// Implements marker.
    /// </summary>
    class MarkerImpl : IMarker
    {
        /// <summary>
        /// Creates a new MarkerImpl.
        /// </summary>
        /// <param name="coordinates">The position of the marker.</param>
        /// <param name="image">The image of the marker.</param>
        /// <param name="text">The notice of the marker.</param>
        public MarkerImpl(Point coordinates, Image image, string text)
        {
            Coordinates = coordinates;
            Image = image;
            Dimension = new Size(Image.Width, Image.Height);
            Text = text;
        }

        public Point Coordinates { get; }

        public Image Image { get; }

        public Size Dimension { get; }

        public string Text { get; }

        public bool IsOutOfScreen() => Coordinates.X < -Dimension.Width;

        public void Update(float velocity) => Coordinates.X -= velocity;

    }
}
