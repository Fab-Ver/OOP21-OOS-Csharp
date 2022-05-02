using FabioVeroli.Entity;
using System.Collections.Generic;

namespace FabioVeroli.Manager
{
    /// <summary>
    /// Interface identifying the manager for IDynamicEntity.
    /// </summary>
    public interface IEntityManager
    {
        /// <summary>
        /// Get the entities currently on the game. 
        /// </summary>
        /// <returns>a list containing the entities that are actually on the game.</returns>
        List<IDynamicEntity> GetEntities();

        /// <summary>
        /// Speed property of the entities. 
        /// </summary>
        float SpeedX { set; }

        /// <summary>
        /// Update the position of every entity in the list, remove and add element.
        /// </summary>
        void UpdateList();

    }
}
