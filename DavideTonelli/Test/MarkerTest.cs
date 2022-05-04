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

        private IMarkerManager markerManager;
        private float difficulty;
        private int distance;

        [SetUp]
        public void Setup()
        {
            markerManager = new MarkerManagerImpl(LastDeathDistance, RecordDistance);
            difficulty = 2;
            distance = 0;
        }

        [Test]
        public void InitialState()
        {
            Assert.AreEqual(0, markerManager.GetMarkers().Count);
        }

        [Test]
        public void TestCommonMarker()
        {
            IMarkerFactory factory = new MarkerFactoryImpl();
            int tempDistance = 0;
            string markerString = "";
            while (tempDistance <= DistanceBetweenMarkers)
            {
                if (markerManager.IsCommonMarkerToBeCreated(tempDistance))
                {
                    // Creates a common marker
                    markerManager.GetMarkers().Add(Optional.Of(factory.CreateCommonMarker(DistanceBetweenMarkers.ToString())));
                    // Saves the string distance of the common marker
                    markerString = tempDistance.ToString();
                }
                IncreaseDifficulty();
                IncreaseDistance();
                tempDistance = distance;
            }
            Assert.AreEqual(1, markerManager.GetMarkers().Count);
            Assert.AreEqual(markerString, markerManager.GetMarkers()[0].GetValueOrElseThrow().Text);
            // Moves markers out of the screen
            markerManager.Update(BigDistance);
            Assert.AreEqual(0, markerManager.GetMarkers().Count);
        }

        [Test]
        public void TestLastDeathMarker()
        {
            int tempDistance = 0;
            while (distance <= LastDeathDistance * 2)
            {
                markerManager.CheckCreateMarker(tempDistance);
                IncreaseDifficulty();
                IncreaseDistance();
                tempDistance = distance;
            }
            Assert.AreEqual(NumberOfMarkersLastDeathTest, markerManager.GetMarkers().Count);
            // Moves markers out of the screen
            markerManager.Update(BigDistance);
            Assert.AreEqual(0, markerManager.GetMarkers().Count);
        }

        [Test]
        public void TestRecordMarker()
        {
            int tempDistance = 0;
            while (tempDistance <= RecordDistance * 2)
            {
                markerManager.CheckCreateMarker(tempDistance);
                IncreaseDifficulty();
                IncreaseDistance();
                tempDistance = distance;
            }
            Assert.AreEqual(NumberOfMarkersRecordTest, markerManager.GetMarkers().Count);
            // Moves markers out of the screen
            markerManager.Update(BigDistance);
            Assert.AreEqual(0, markerManager.GetMarkers().Count);
        }

        private void IncreaseDifficulty() => 
            difficulty = difficulty <= MaxDifficulty ? difficulty * DifficultyFactor : difficulty;

        private void IncreaseDistance() => distance += (int)difficulty;

    }
}