using Commons.Geometry;
using FabioVeroli.Entity;
using FabioVeroli.Factory;
using FabioVeroli.Manager;
using NUnit.Framework;
using System.Collections.Generic;

namespace FabioVeroli.Test
{
    class ManagerTest
    {
        private static readonly int NUM_ITERATIONS = 10_000;
        private static readonly int MIN_ENTITIES = 3;
        private static readonly int RESULT_ONE = 6;
        private static readonly int OUT_OF_SCREEN = 1200;

        private static readonly float WORLD_WIDTH = 854.0f;
        private static readonly float WORLD_HEIGHT = 440.0f;

        private IEntityManager _manager;
        private IEntityFactory _factory;

        [SetUp]
        public void SetUp()
        {
            var size = new Size(WORLD_WIDTH, WORLD_HEIGHT);
            _manager = new EntityManager(size);
            _factory = new EntityFactory(size);
        }

        [Test]
        public void TestGetter()
        {
            List<IDynamicEntity> entities = _manager.Entities;
            /*Empty list at the beginning*/
            Assert.AreEqual(entities.Count, 0);
            /*Add some entities using the factory*/
            entities.Add(_factory.CreateCoin(SpawnLevel.ZERO));
            entities.AddRange(_factory.CombineAll(SpawnLevel.ONE, SpawnLevel.ZERO, SpawnLevel.TWO));
            entities.AddRange(_factory.CombineObstacleCoin(SpawnLevel.ZERO, SpawnLevel.ONE));
            /*Check if the size of the list as changed*/
            Assert.AreEqual(entities.Count, RESULT_ONE);
        }

        [Test]
        public void TestUpdate()
        {
            /*Update the generator, if the size of the list is zero the test should fail*/
            for (int i = 0; i < NUM_ITERATIONS; i++)
            {
                _manager.UpdateList();
                if (_manager.Entities.Count == 0)
                {
                    Assert.Fail("Entities list's size should be positive.");
                }
            }
            /*Change the speed of the entities so they go out of screen, when the list get updated 
             * all the entities must have been removed except for the new added ones*/
            _manager.SpeedX = OUT_OF_SCREEN;
            _manager.UpdateList();
            Assert.True(_manager.Entities.Count <= MIN_ENTITIES);
        }
    }
}
