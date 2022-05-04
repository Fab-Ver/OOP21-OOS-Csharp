using System;

namespace DavideTonelli.Marker
{
    /// <summary>
    /// A factory of marker.
    /// </summary>
    interface IMarkerFactory
    {
        /// <summary>
        /// Creates a simple marker with the given notice.
        /// </summary>
        /// <param name="text">The marker's notice.</param>
        /// <returns>A common marker.</returns>
        IMarker CreateCommonMarker(String text);

        /// <summary>
        /// Creates a special marker that notify the last death distance.
        /// </summary>
        /// <returns>A last death marker.</returns>
        IMarker CreateLastDeathMarker();

        /// <summary>
        /// Creates a special marker that notify the record distance.
        /// </summary>
        /// <returns>A record marker.</returns>
        IMarker CreateRecordMarker();

    }
}
