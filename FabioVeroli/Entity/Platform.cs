using System;
using System.Drawing;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Class identifying a game's Platform.
    /// </summary>
    public sealed class Platform : AbstractDynamicEntity
    {
        /// <summary>
        /// Create a new Platform. 
        /// </summary>
        /// <param name="coordinates">The coordinates of the Platform on the screen.</param>
        /// <param name="dimensions"> The size of the Platform.</param>
        /// <param name="level">The level on which the Platform spawn.</param>
        /// <param name="type">The type identifying the Platform.</param>
        /// <param name="distance">The distance after that next entity should spawn.</param>
        public Platform(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance)
               : base(coordinates, dimensions, level, type, distance)
        {
        }

        protected override void ActivateEffect() => Console.WriteLine("Just a test, no actual effect implemented");
    }
}
