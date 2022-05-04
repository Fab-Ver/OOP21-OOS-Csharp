using Commons.Geometry;
using System;

namespace DavideTonelli.Marker
{
    /// <summary>
    /// Implementation of MarkerFactory.
    /// </summary>
    class MarkerFactoryImpl : IMarkerFactory
    {
        private const float MarkerX = 980.0f;
        private const float LowMarkerY = 365.0f;
        private const float HighMarkerY = 40.0f;

        public IMarker CreateCommonMarker(string text) =>
            new Random().Next(1, 3) % 2 == 0 ? CreateHighMarker(new Image(), text) : CreateLowMarker(new Image(), text);

        public IMarker CreateLastDeathMarker() => CreateLowMarkerWithoutText(new Image());

        public IMarker CreateRecordMarker() => CreateLowMarkerWithoutText(new Image());

        /// <summary>
        /// Creates a general marker.
        /// </summary>
        /// <param name="point">The marker's coordinates.</param>
        /// <param name="image">The marker's image.</param>
        /// <param name="text">The marker's notice.</param>
        /// <returns>A general marker.</returns>
        private IMarker CreateGeneralised(Point point, Image image, string text) => new MarkerImpl(point, image, text);

        /// <summary>
        /// Creates a general marker without a text notice.
        /// </summary>
        /// <param name="point">The marker's coordinates.</param>
        /// <param name="image">The marker's image.</param>
        /// <returns>A general marker without a text notice.</returns>
        private IMarker CreateGeneralisedWithoutText(Point point, Image image) => new MarkerImpl(point, image, "");

        /// <summary>
        /// Creates a marker at the bottom right.
        /// </summary>
        /// <param name="image">The marker's image.</param>
        /// <param name="text">The marker's notice.</param>
        /// <returns>A marker at the bottom right.</returns>
        private IMarker CreateLowMarker(Image image, string text) => 
            CreateGeneralised(new Point(MarkerX, LowMarkerY), image, text);

        /// <summary>
        /// Creates a marker at the top right.
        /// </summary>
        /// <param name="image">The marker's image.</param>
        /// <param name="text">The marker's notice.</param>
        /// <returns>A marker at the top right.</returns>
        private IMarker CreateHighMarker(Image image, string text) => 
            CreateGeneralised(new Point(MarkerX, HighMarkerY), image, text);

        /// <summary>
        /// Creates a marker at the bottom right without a text notice.
        /// </summary>
        /// <param name="image">the marker's image.</param>
        /// <returns>A marker at the top right without a text notice.</returns>
        private IMarker CreateLowMarkerWithoutText(Image image) => 
            CreateGeneralisedWithoutText(new Point(MarkerX, LowMarkerY), image);
    }
}
