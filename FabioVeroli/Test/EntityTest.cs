using Commons.Geometry;
using NUnit.Framework;
using FabioVeroli.Entity;
using FabioVeroli.Factory;

namespace FabioVeroli.Test
{   
    class EntityTest
    {
        private static readonly float COIN_WIDTH = 35.0f;
        private static readonly float COIN_HEIGHT = 40.0f;
        private static readonly float COIN_EXPECTED_X = 1039.5f;
        private static readonly float COIN_EXPECTED_Y = 290.0f;
        private static readonly float COIN_EXPECTED_DISTANCE = 668.5f;

        private static readonly float PLATFORM_WIDTH = 417.0f;
        private static readonly float PLATFORM_HEIGHT = 35.0f;
        private static readonly float PLATFORM_EXPECTED_X = 854.0f;
        private static readonly float PLATFORM_EXPECTED_Y = 185.0f;
        private static readonly float PLATFORM_EXPECTED_DISTANCE = 437.0f;

        private static readonly float OBSTACLE_WIDTH = 43.0f;
        private static readonly float OBSTACLE_HEIGHT = 55.0f;
        private static readonly float OBSTACLE_EXPECTED_X = 1056.1f;
        private static readonly float OBSTACLE_EXPECTED_Y = 385.0f;
        private static readonly float OBSTACLE_EXPECTED_DISTANCE = 651.9f;

        private static readonly float WORLD_WIDTH = 854.0f;
        private static readonly float WORLD_HEIGHT = 440.0f;


        private IEntityFactory _factory;

        [SetUp]
        public void SetUp() => _factory = new EntityFactory(new Size(WORLD_WIDTH, WORLD_HEIGHT));

        [Test]
        public void TestCoin()
        {
            /*Test coin's initial state and position*/
            IDynamicEntity coin = _factory.CreateCoin(SpawnLevel.ONE);
            Assert.AreEqual(coin.Bounds, new Rectangle(COIN_EXPECTED_X, COIN_EXPECTED_Y, COIN_WIDTH, COIN_HEIGHT));
            Assert.IsFalse(coin.IsOutofScreen());
            Assert.AreEqual(SpawnLevel.ONE, coin.Level);
            Assert.AreEqual(EntityType.COIN, coin.Type);
            Assert.AreEqual(COIN_EXPECTED_DISTANCE, coin.Distance);
            Assert.IsFalse(coin.Hit);
            /*Modify coin's state*/
            coin.OnCollision();
            coin.UpdatePosition(WORLD_WIDTH * 2);
            /*Check the state modification*/
            Assert.IsTrue(coin.Hit);
            Assert.IsTrue(coin.IsOutofScreen());
        }

        [Test]
        public void TestPlatform()
        {
            /*Test platform's initial state and position*/
            IDynamicEntity platform = _factory.CreatePlatform(SpawnLevel.TWO);
            Assert.AreEqual(platform.Bounds, new Rectangle(PLATFORM_EXPECTED_X, PLATFORM_EXPECTED_Y, PLATFORM_WIDTH, PLATFORM_HEIGHT));
            Assert.IsFalse(platform.IsOutofScreen());
            Assert.AreEqual(SpawnLevel.TWO, platform.Level);
            Assert.AreEqual(EntityType.PLATFORM, platform.Type);
            Assert.AreEqual(PLATFORM_EXPECTED_DISTANCE, platform.Distance);
            Assert.IsFalse(platform.Hit);
            /*Modify platform's state*/
            platform.OnCollision();
            platform.UpdatePosition(WORLD_WIDTH * 2);
            /*Check the state modification*/
            Assert.IsTrue(platform.Hit);
            Assert.IsTrue(platform.IsOutofScreen());
        }

        [Test]
        public void TestObstacle()
        {
            /*Test obstacle's initial state and position*/
            IDynamicEntity obstacle = _factory.CreateObstacle(SpawnLevel.ZERO);

            Assert.AreEqual(obstacle.Bounds, new Rectangle(OBSTACLE_EXPECTED_X, OBSTACLE_EXPECTED_Y, OBSTACLE_WIDTH, OBSTACLE_HEIGHT));
            Assert.AreEqual(obstacle.Distance, OBSTACLE_EXPECTED_DISTANCE);
            Assert.IsFalse(obstacle.IsOutofScreen());
            Assert.AreEqual(SpawnLevel.ZERO, obstacle.Level);
            Assert.AreEqual(EntityType.OBSTACLE, obstacle.Type);
            Assert.IsFalse(obstacle.Hit);
            /*Modify obstacle's state*/
            obstacle.OnCollision();
            obstacle.UpdatePosition(WORLD_WIDTH * 2);
            /*Check the state modification*/
            Assert.IsTrue(obstacle.Hit);
            Assert.IsTrue(obstacle.IsOutofScreen());
        }
    }
}
