using Commons.Geometry;

namespace DavideTonelli.Marker
{
    /// <summary>
    /// Interface that identifies a notification during the game run.
    /// </summary>
    interface IMarker
    {
        /// <summary>
        /// Point property of the marker.
        /// </summary>
        public Point Coordinates { get; }

        /// <summary>
        /// Image property of the marker.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Dimension property of the marker.
        /// </summary>
        public Size Dimension { get; }

        /// <summary>
        /// Gets the marker's notice.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Updates the marker's coordinates of the given size of movement.
        /// </summary>
        /// <param name="velocity">The amount of size of the movement.</param>
        void Update(float velocity);

        /// <summary>
        /// Checks if the marker is out of the screen.
        /// </summary>
        /// <returns>True if the marker is out of the screen, false otherwise.</returns>
        bool IsOutOfScreen();

    }
}
