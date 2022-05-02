using System;
using System.Drawing;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Class identifying a game's Obstacle.
    /// </summary>
    public sealed class Obstacle : AbstractDynamicEntity
    {
        /// <summary>
        /// Create a new Obstacle. 
        /// </summary>
        /// <param name="coordinates">The coordinates of the Obstacle on the screen.</param>
        /// <param name="dimensions"> The size of the Obstacle.</param>
        /// <param name="level">The level on which the Obstacle spawn.</param>
        /// <param name="type">The type identifying the Obstacle.</param>
        /// <param name="distance">The distance after that next entity should spawn.</param>
        public Obstacle(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance) 
               : base(coordinates, dimensions, level, type, distance)
        {
        }

        protected override void ActivateEffect() => Console.WriteLine("Just a test, no actual effect implemented");
    }
}
