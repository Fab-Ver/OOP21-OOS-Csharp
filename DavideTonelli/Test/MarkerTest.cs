using DavideTonelli.Marker;
using NOptional;
using NUnit.Framework;

namespace DavideTonelli
{
    public class MarkerTest
    {
        private const int LastDeathDistance = 53;
        private const int RecordDistance = 405;
        private const int DistanceBetweenMarkers = 10;
        private const int BigDistance = 100_000;
        private const int NumberOfMarkersLastDeathTest = (LastDeathDistance * 2) / DistanceBetweenMarkers + 1;
        private const int NumberOfMarkersRecordTest = (RecordDistance * 2) / DistanceBetweenMarkers + 1;
        private const float DifficultyFactor = 1.010f;
        private const float MaxDifficulty = 15.0f;

        private IMarkerManager _markerManager;
        private float _difficulty;
        private int _distance;

        [SetUp]
        public void Setup()
        {
            _markerManager = new MarkerManagerImpl(LastDeathDistance, RecordDistance);
            _difficulty = 2;
            _distance = 0;
        }

        [Test]
        public void InitialState()
        {
            Assert.AreEqual(0, _markerManager.GetMarkers().Count);
        }

        [Test]
        public void TestCommonMarker()
        {
            IMarkerFactory factory = new MarkerFactoryImpl();
            int tempDistance = 0;
            string markerString = "";
            while (tempDistance <= DistanceBetweenMarkers)
            {
                if (_markerManager.IsCommonMarkerToBeCreated(tempDistance))
                {
                    // Creates a common marker
                    _markerManager.GetMarkers().Add(Optional.Of(factory.CreateCommonMarker(DistanceBetweenMarkers.ToString())));
                    // Saves the string distance of the common marker
                    markerString = tempDistance.ToString();
                }
                IncreaseDifficulty();
                IncreaseDistance();
                tempDistance = _distance;
            }
            Assert.AreEqual(1, _markerManager.GetMarkers().Count);
            Assert.AreEqual(markerString, _markerManager.GetMarkers()[0].GetValueOrElseThrow().Text);
            // Moves markers out of the screen
            _markerManager.Update(BigDistance);
            Assert.AreEqual(0, _markerManager.GetMarkers().Count);
        }

        [Test]
        public void TestLastDeathMarker()
        {
            int tempDistance = 0;
            while (_distance <= LastDeathDistance * 2)
            {
                _markerManager.CheckCreateMarker(tempDistance);
                IncreaseDifficulty();
                IncreaseDistance();
                tempDistance = _distance;
            }
            Assert.AreEqual(NumberOfMarkersLastDeathTest, _markerManager.GetMarkers().Count);
            // Moves markers out of the screen
            _markerManager.Update(BigDistance);
            Assert.AreEqual(0, _markerManager.GetMarkers().Count);
        }

        [Test]
        public void TestRecordMarker()
        {
            int tempDistance = 0;
            while (tempDistance <= RecordDistance * 2)
            {
                _markerManager.CheckCreateMarker(tempDistance);
                IncreaseDifficulty();
                IncreaseDistance();
                tempDistance = _distance;
            }
            Assert.AreEqual(NumberOfMarkersRecordTest, _markerManager.GetMarkers().Count);
            // Moves markers out of the screen
            _markerManager.Update(BigDistance);
            Assert.AreEqual(0, _markerManager.GetMarkers().Count);
        }

        private void IncreaseDifficulty() => 
            _difficulty = _difficulty <= MaxDifficulty ? _difficulty * DifficultyFactor : _difficulty;

        private void IncreaseDistance() => _distance += (int)_difficulty;

    }
}