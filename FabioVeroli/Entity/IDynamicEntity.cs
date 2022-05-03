using Commons.Geometry;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Interface that describe an entity moving on the screen.
    /// </summary>
    public interface IDynamicEntity
    {
        /// <summary>
        /// Update the entity position on the screen.
        /// </summary>
        /// <param name="speedX"> entity's speedX. </param>
        void UpdatePosition(float speedX);

        /// <summary>
        /// Returns the entity's Bounding Box.
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// Check if the entity is out of the game screen.
        /// </summary>
        /// <returns>true if the entity is out of the screen, false otherwise.</returns>
        bool IsOutofScreen();

        /// <summary>
        /// The level on which the entity spawn.
        /// </summary>
        SpawnLevel Level { get; }

        /// <summary>
        /// The type that identifies the entity.
        /// </summary>
        EntityType Type { get; }

        /// <summary>
        /// The distance after that next entity should spawn.
        /// </summary>
        double Distance { get; }

        /// <summary>
        /// An entity' state, true if it was hit, false otherwise.
        /// </summary>
        bool Hit { get; set; }

        /// <summary>
        /// Method called when an entity collide with the player.
        /// </summary>
        void OnCollision();

    }
}
