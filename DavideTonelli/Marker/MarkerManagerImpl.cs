using NOptional;
using System.Collections.Generic;

namespace DavideTonelli.Marker
{
    /// <summary>
    /// Implementation of MarkerManager.
    /// </summary>
    class MarkerManagerImpl : IMarkerManager
    {
        const int DistanceBetweenMarkers = 10;

        private readonly int _lastDeathDistance;
        private readonly int _recordDistance;
        private int _numberNextMarker;
        private readonly IMarkerFactory _markerFactory;
        private IOptional<IMarker> _lastDeathMarker;
        private IOptional<IMarker> _recordMarker;
        private readonly List<IOptional<IMarker>> _markers;

        /// <summary>
        /// Creates a new MarkerManagerImpl.
        /// </summary>
        /// <param name="lastDeathDistance">The distance reached in the last run.</param>
        /// <param name="recordDistance">The record distance.</param>
        public MarkerManagerImpl(int lastDeathDistance, int recordDistance)
        {
            _lastDeathDistance = lastDeathDistance;
            _recordDistance = recordDistance;
            _numberNextMarker = 1;
            _markerFactory = new MarkerFactoryImpl();
            _lastDeathMarker = Optional.Empty<IMarker>();
            _recordMarker = Optional.Empty<IMarker>();
            _markers = new List<IOptional<IMarker>>();
        }

        public void CheckCreateMarker(int distance)
        {
            if (IsCommonMarkerToBeCreated(distance))
            {
                _markers.Add(Optional.Of(_markerFactory.CreateCommonMarker(ApproximateDistance().ToString())));
            }

            if (_lastDeathMarker.IsEmpty() && distance > 0 && distance >= CalculateSpawn(_lastDeathDistance))
            {
                _lastDeathMarker = Optional.Of(_markerFactory.CreateLastDeathMarker());
                _markers.Add(_lastDeathMarker);
            }

            if (_recordMarker.IsEmpty() && distance > 0 && distance >= CalculateSpawn(_recordDistance))
            {
                _recordMarker = Optional.Of(_markerFactory.CreateRecordMarker());
                _markers.Add(_recordMarker);
            }
        }

        public List<IOptional<IMarker>> GetMarkers()
        {
            _markers.RemoveAll(op => op.GetValueOrElseThrow().IsOutOfScreen());
            return _markers;
        }

        public bool IsCommonMarkerToBeCreated(int distance)
        {
            int nextMarkerDist = _numberNextMarker * DistanceBetweenMarkers;

            if (distance >= nextMarkerDist && distance % nextMarkerDist >= 0)
            {
                _numberNextMarker++;
                return true;
            }
            return false;
        }

        public void Update(float difficulty) => _markers.ForEach(op => op.DoIfPresent(m => m.Update(difficulty)));

        /// <summary>
        /// Calculate the distance that common marker must notify. 
        /// </summary>
        /// <returns>The approximate distance.</returns>
        private int ApproximateDistance() => _numberNextMarker * DistanceBetweenMarkers;

        /// <summary>
        /// Calculate the spawn distance that special marker must to use. 
        /// </summary>
        /// <param name="distance">The covered distance.</param>
        /// <returns>The spawn distance.</returns>
        private int CalculateSpawn(int distance) => distance - DistanceBetweenMarkers;
    }
}
