using FabioVeroli.Entity;
using System.Collections.Generic;

namespace FabioVeroli.Factory
{
    /// <summary>
    /// Factory Method for DynamicEntity.
    /// </summary>
    public interface IEntityFactory
    {
        /// <summary>
        /// Create a new Obstacle's instance.
        /// </summary>
        /// <param name="level">The level on which Obstacle spawn.</param>
        /// <returns>A new Obstacle's instance.</returns>
        IDynamicEntity CreateObstacle(SpawnLevel level);

        /// <summary>
        /// Create a new Platform's instance.
        /// </summary>
        /// <param name="level">The level on which Platform spawn.</param>
        /// <returns>A new Platform's instance.</returns>
        IDynamicEntity CreatePlatform(SpawnLevel level);

        /// <summary>
        /// Create a new Coin's instance.
        /// </summary>
        /// <param name="level">The level on which Coin spawn.</param>
        /// <returns>A new Coin's instance.</returns>
        IDynamicEntity CreateCoin(SpawnLevel level);

        /// <summary>
        /// Combine Platform and Obstacle. 
        /// </summary>
        /// <param name="platformLevel">The level on which Platform should spawn.</param>
        /// <param name="obstacleLevel">The level on which Obstacle should spawn.</param>
        /// <returns>A list containing Platform and Obstacle combined. </returns>
        List<IDynamicEntity> CombinePlatformObstacle(SpawnLevel platformLevel, SpawnLevel obstacleLevel);

        /// <summary>
        ///  Combine Platform and Coin.
        /// </summary>
        /// <param name="platformLevel">The level on which Platform should spawn.</param>
        /// <param name="coinLevel">The level on which Coin should spawn.</param>
        /// <returns>A list containing Platform and Coin combined. </returns>
        List<IDynamicEntity> CombinePlatformCoin(SpawnLevel platformLevel, SpawnLevel coinLevel);

        /// <summary>
        /// Combine Obstacle and Coin.
        /// </summary>
        /// <param name="obstacleLevel">The level on which Obstacle should spawn.</param>
        /// <param name="coinLevel">The level on which Coin should spawn.</param>
        /// <returns>A list containing Obstacle and Coin combined. </returns>
        List<IDynamicEntity> CombineObstacleCoin(SpawnLevel obstacleLevel, SpawnLevel coinLevel);

        /// <summary>
        /// Combine Obstacle, Platform and Coin.
        /// </summary>
        /// <param name="platformLevel">The level on which Platform should spawn.</param>
        /// <param name="obstacleLevel">The level on which Obstacle should spawn.</param>
        /// <param name="coinLevel">The level on which Coin should spawn.</param>
        /// <returns>A list containing Platform, Obstacle and Coin combined. </returns>
        List<IDynamicEntity> CombineAll(SpawnLevel platformLevel, SpawnLevel obstacleLevel, SpawnLevel coinLevel);
    }
}
