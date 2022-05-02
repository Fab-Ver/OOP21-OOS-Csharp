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

        private EntityManager generator;
        private EntityFactory factory;

        [SetUp]
        public void SetUp()
        {
            Size size = new Size(WORLD_WIDTH, WORLD_HEIGHT);
            generator = new EntityManager(size);
            factory = new EntityFactory(size);
        }

        [Test]
        public void TestGetter()
        {
            List<IDynamicEntity> entities = generator.GetEntities();
            /*Empty list at the beginning*/
            Assert.AreEqual(entities.Count, 0);
            /*Add some entities using the factory*/
            entities.Add(factory.CreateCoin(SpawnLevel.ZERO));
            entities.AddRange(factory.CombineAll(SpawnLevel.ONE, SpawnLevel.ZERO, SpawnLevel.TWO));
            entities.AddRange(factory.CombineObstacleCoin(SpawnLevel.ZERO, SpawnLevel.ONE));
            /*Check if the size of the list as changed*/
            Assert.AreEqual(entities.Count, RESULT_ONE);
        }

        [Test]
        public void TestUpdate()
        {
            /*Update the generator, if the size of the list is zero the test should fail*/
            for (int i = 0; i < NUM_ITERATIONS; i++)
            {
                generator.UpdateList();
                if (generator.GetEntities().Count == 0)
                {
                    Assert.Fail("Entities list's size should be positive.");
                }
            }
            /*Change the speed of the entities so they go out of screen, when the list get updated 
             * all the entities must have been removed except for the new added ones*/
            generator.SpeedX = OUT_OF_SCREEN;
            generator.UpdateList();
            Assert.True(generator.GetEntities().Count <= MIN_ENTITIES);
        }
    }
}
