using NOptional;
using System.Collections.Generic;

namespace DavideTonelli.Marker
{
    /// <summary>
    /// Interface that identifies a manager of marker.
    /// </summary>
    interface IMarkerManager
    {
        /// <summary>
        /// Checks if a common marker must to be created.
        /// </summary>
        /// <param name="distance">The covered distance by player.</param>
        /// <returns>True if marker has to be created, false otherwise.</returns>
        bool IsCommonMarkerToBeCreated(int distance);

        /// <summary>
        ///  Checks and creates marker that must to be created.
        /// </summary>
        /// <param name="distance">The covered distance by player.</param>
        void CheckCreateMarker(int distance);

        /// <summary>
        /// Updates markers' positions of the given amount.
        /// </summary>
        /// <param name="difficulty">The amount of the movement.</param>
        void Update(float difficulty);

        /// <summary>
        /// Gets the list of Optional of marker.
        /// </summary>
        /// <returns>The list of Optional of marker.</returns>
        List<IOptional<IMarker>> GetMarkers();

    }
}
