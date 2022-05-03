using Commons.Geometry;
using FabioVeroli.Entity;
using FabioVeroli.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FabioVeroli.Manager
{
    public sealed class EntityManager : IEntityManager
    {
        private static readonly float INITIAL_SPEEDX = 2.0f;

        private readonly List<IDynamicEntity> _entities;
        private readonly IEntityFactory _factory;

        public EntityManager(Size worldDimensions)
        {
            _factory = new EntityFactory(worldDimensions);
            _entities = new List<IDynamicEntity>();
            SpeedX = INITIAL_SPEEDX;
        }

        public List<IDynamicEntity> Entities { get => _entities; }
        public float SpeedX { private get; set; }

        public void UpdateList()
        {
            RemoveEntity(e => e.Hit && (e.Type == EntityType.POWERUP || e.Type == EntityType.COIN));
            _entities.ForEach(e => e.UpdatePosition(SpeedX));
            RemoveEntity(e => e.IsOutofScreen());

            if(_entities.Count == 0)
            {
                _entities.AddRange(_factory.CombineAll(SpawnLevel.ONE, SpawnLevel.ZERO, SpawnLevel.TWO));

            } else if (CheckPosition())
            {
                AddEntity();
            }
            
        }

        /// <summary>
        /// Add an entitties' configuration to the list. 
        /// </summary>
        private void AddEntity()
        {
            //Not a translation of Java code, code for this section was implemented for test purpose and simplified. 
            var last = _entities.Last();
            switch (last.Level)
            {
                case SpawnLevel.ZERO:
                    _entities.AddRange(_factory.CombineObstacleCoin(SpawnLevel.ZERO, SpawnLevel.ONE));
                    break;
                case SpawnLevel.ONE:
                    _entities.AddRange(_factory.CombinePlatformCoin(SpawnLevel.TWO, SpawnLevel.ONE));
                    break;
                case SpawnLevel.TWO:
                    _entities.AddRange(_factory.CombinePlatformObstacle(SpawnLevel.TWO, SpawnLevel.ZERO));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Remove the filtered entities from the entities list.
        /// </summary>
        /// <param name="filter">the condition used to remove the entities from the list.</param>
        private void RemoveEntity(Predicate<IDynamicEntity> filter) => _entities.RemoveAll(e => filter(e));

        /// <summary>
        /// Check if a new entity could spawn, according to the last entity's distance.
        /// </summary>
        /// <returns>true if the entity could spawn, false otherwise.</returns>
        private bool CheckPosition()
        {
            IDynamicEntity last = _entities.Last();
            return last.Bounds.MinX <= last.Distance;
        }

    }
}
