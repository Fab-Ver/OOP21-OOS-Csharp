using FabioVeroli.Entity;
using FabioVeroli.Factory;
using NUnit.Framework;
using SaraCappelletti.CollisionModel;
using SaraCappelletti.PlayerModel;
using System.Collections.Generic;
using System.Drawing;

namespace SaraCappelletti.Test
{
    internal class CollisionManagerTest
    {
        private const int DISTANCE = 1000;
        private ICollisionManager _manager;
        private IEntityFactory _factory;
        private List<IDynamicEntity> _objects;
        private IPlayer _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
            _manager = new CollisionManager();
            _factory = new EntityFactory(new SizeF(854, 440));
            _objects = new List<IDynamicEntity>();
        }

        [Test]
        public void testCollisionWithObstacle()
        {
            int lives = _player.Lives;
            _objects.Clear();
            _objects.Add(_factory.CreateObstacle(SpawnLevel.ZERO));
            _objects[0].UpdatePosition(DISTANCE);
            _manager.PlayerCollidesWidth(_player, _objects);
            Assert.True(_player.Lives < lives);
        }

        [Test]
        public void testCollisionWithPlatform()
        {
           _objects.Clear();
           _objects.Add(_factory.CreatePlatform(SpawnLevel.ZERO));
           _player.Jump();
           Assert.Equals(JumpState.UP, _player.JumpState);
        }

    }
}
