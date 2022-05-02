using System;
using System.Drawing;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Class identifying a game's Coin. 
    /// </summary>
    public sealed class Coin : AbstractDynamicEntity
    {
        /// <summary>
        /// Create a new Coin. 
        /// </summary>
        /// <param name="coordinates">The coordinates of the Coin on the screen.</param>
        /// <param name="dimensions"> The size of the Coin.</param>
        /// <param name="level">The level on which the Coin spawn.</param>
        /// <param name="type">The type identifying the Coin.</param>
        /// <param name="distance">The distance after that next entity should spawn.</param>
        public Coin(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance)
               : base(coordinates, dimensions, level, type, distance)
        {
        }

        protected override void ActivateEffect() => Console.WriteLine("Just a test, no actual effect implemented");
    }
}
