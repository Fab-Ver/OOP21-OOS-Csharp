﻿using System.Drawing;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Interface that describe an entity moving on the screen.
    /// </summary>
    interface IDynamicEntity
    {
        /// <summary>
        /// Update the entity position on the screen.
        /// </summary>
        /// <param name="speedX"> entity's speedX. </param>
        void UpdatePosition(float speedX);

        /// <summary>
        /// Returns the entity's Bounding Box.
        /// </summary>
        /// <returns> a new RectangleF representing the coordinates and the dimension of the entity.</returns>
        RectangleF GetBounds();

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
        double Distance { get;  }

        /// <summary>
        /// An entity' state, true if it was hit, false otherwise.
        /// </summary>
        bool Hit { get; set; }

    }
}
