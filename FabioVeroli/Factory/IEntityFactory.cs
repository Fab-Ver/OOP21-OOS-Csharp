using FabioVeroli.Entity;
using System.Collections.Generic;

namespace FabioVeroli.Factory
{
    public interface IEntityFactory
    {
        IDynamicEntity CreateObstacle(SpawnLevel level);
        IDynamicEntity CreatePlatform(SpawnLevel level);
        IDynamicEntity CreateCoin(SpawnLevel level);
        List<IDynamicEntity> CombinePlatformObstacle(SpawnLevel platformLevel, SpawnLevel obstacleLevel);
        List<IDynamicEntity> CombinePlatformCoin(SpawnLevel platformLevel, SpawnLevel coinLevel);
        List<IDynamicEntity> CombineObstacleCoin(SpawnLevel obstacleLevel, SpawnLevel coinLevel);
        List<IDynamicEntity> CombineAll(SpawnLevel platformLevel, SpawnLevel obstacleLevel, SpawnLevel coinLevel);
    }
}
