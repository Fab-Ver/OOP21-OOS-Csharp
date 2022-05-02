using FabioVeroli.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FabioVeroli.Factory
{
    class EntityFactory : IEntityFactory
    {
        private static readonly float COIN_WIDTH = 35.0f;
        private static readonly float COIN_HEIGHT = 40.0f;

        private static readonly float PLATFORM_WIDTH = 417.0f;
        private static readonly float PLATFORM_HEIGHT = 35.0f;

        private static readonly float OBSTACLE_WIDTH = 43.0f;
        private static readonly float OBSTACLE_HEIGHT = 55.0f;

        public EntityFactory(SizeF worldDimensions)
        {
            WorldDimensions = worldDimensions;
        }

        public SizeF WorldDimensions { private get; set; }

        public IDynamicEntity CreateCoin(SpawnLevel level)
        {
            SizeF size = new SizeF(COIN_WIDTH, COIN_HEIGHT);
            PointF coordinates = GeneratePoint(level, size, EntityType.COIN.GetDistanceFactor());
            float distance = WorldDimensions.Width - size.Width * EntityType.COIN.GetDistanceFactor();
            return new Platform(coordinates, size, level, EntityType.COIN, distance);
        }

        public IDynamicEntity CreateObstacle(SpawnLevel level)
        {
            SizeF size = new SizeF(OBSTACLE_WIDTH, OBSTACLE_HEIGHT);
            PointF coordinates = GeneratePoint(level, size, EntityType.OBSTACLE.GetDistanceFactor());
            float distance = WorldDimensions.Width - size.Width * EntityType.OBSTACLE.GetDistanceFactor();
            return new Obstacle(coordinates, size, level, EntityType.OBSTACLE, distance);
        }

        public IDynamicEntity CreatePlatform(SpawnLevel level)
        {
            SizeF size = new SizeF(PLATFORM_WIDTH, PLATFORM_HEIGHT);
            PointF coordinates = GeneratePoint(level, size, EntityType.PLATFORM.GetDistanceFactor());
            float distance = WorldDimensions.Width - size.Width;
            return new Platform(coordinates, size, level, EntityType.PLATFORM, distance);
        }

        public List<IDynamicEntity> CombineAll(SpawnLevel platformLevel, SpawnLevel obstacleLevel, SpawnLevel coinLevel)
        {
            throw new NotImplementedException();
        }

        public List<IDynamicEntity> CombineObstacleCoin(SpawnLevel obstacleLevel, SpawnLevel coinLevel)
        {
            throw new NotImplementedException();
        }

        public List<IDynamicEntity> CombinePlatformCoin(SpawnLevel platformLevel, SpawnLevel coinLevel)
        {
            throw new NotImplementedException();
        }

        public List<IDynamicEntity> CombinePlatformObstacle(SpawnLevel platformLevel, SpawnLevel obstacleLevel)
        {
            throw new NotImplementedException();
        }


        private PointF GeneratePoint(SpawnLevel level, SizeF size, float distanceFactor)
        {
            float x = WorldDimensions.Width + size.Width * distanceFactor;
            float y = WorldDimensions.Height * level.GetSpawnY() - size.Height;
            return new PointF(x, y);
        }
    }
}
