using FabioVeroli.Entity;
using System.Collections.Generic;
using Commons.Geometry;

namespace FabioVeroli.Factory
{
    public class EntityFactory : IEntityFactory
    {
        private static readonly float COIN_WIDTH = 35.0f;
        private static readonly float COIN_HEIGHT = 40.0f;

        private static readonly float PLATFORM_WIDTH = 417.0f;
        private static readonly float PLATFORM_HEIGHT = 35.0f;

        private static readonly float OBSTACLE_WIDTH = 43.0f;
        private static readonly float OBSTACLE_HEIGHT = 55.0f;

        public EntityFactory(Size worldDimensions)
        {
            WorldDimensions = worldDimensions;
        }

        public Size WorldDimensions { private get; set; }

        public IDynamicEntity CreateCoin(SpawnLevel level)
        {
            Size size = new Size(COIN_WIDTH, COIN_HEIGHT);
            Point coordinates = GeneratePoint(level, size, EntityType.COIN.GetDistanceFactor());
            float distance = WorldDimensions.Width - size.Width * EntityType.COIN.GetDistanceFactor();
            return new Platform(coordinates, size, level, EntityType.COIN, distance);
        }

        public IDynamicEntity CreateObstacle(SpawnLevel level)
        {
            Size size = new Size(OBSTACLE_WIDTH, OBSTACLE_HEIGHT);
            Point coordinates = GeneratePoint(level, size, EntityType.OBSTACLE.GetDistanceFactor());
            float distance = WorldDimensions.Width - size.Width * EntityType.OBSTACLE.GetDistanceFactor();
            return new Obstacle(coordinates, size, level, EntityType.OBSTACLE, distance);
        }

        public IDynamicEntity CreatePlatform(SpawnLevel level)
        {
            Size size = new Size(PLATFORM_WIDTH, PLATFORM_HEIGHT);
            Point coordinates = GeneratePoint(level, size, EntityType.PLATFORM.GetDistanceFactor());
            float distance = WorldDimensions.Width - size.Width;
            return new Platform(coordinates, size, level, EntityType.PLATFORM, distance);
        }

        public List<IDynamicEntity> CombineAll(SpawnLevel platformLevel, SpawnLevel obstacleLevel, SpawnLevel coinLevel) =>
            new List<IDynamicEntity> { CreateCoin(coinLevel), CreateObstacle(obstacleLevel), CreatePlatform(platformLevel) };

        public List<IDynamicEntity> CombineObstacleCoin(SpawnLevel obstacleLevel, SpawnLevel coinLevel) =>
            new List<IDynamicEntity> { CreateCoin(coinLevel), CreateObstacle(obstacleLevel) };

        public List<IDynamicEntity> CombinePlatformCoin(SpawnLevel platformLevel, SpawnLevel coinLevel) =>
            new List<IDynamicEntity> { CreateCoin(coinLevel), CreatePlatform(platformLevel) };

        public List<IDynamicEntity> CombinePlatformObstacle(SpawnLevel platformLevel, SpawnLevel obstacleLevel) =>
            new List<IDynamicEntity> { CreateObstacle(obstacleLevel), CreatePlatform(platformLevel) };


        private Point GeneratePoint(SpawnLevel level, Size size, float distanceFactor)
        {
            float x = WorldDimensions.Width + size.Width * distanceFactor;
            float y = WorldDimensions.Height * level.GetSpawnY() - size.Height;
            return new Point(x, y);
        }
    }
}
