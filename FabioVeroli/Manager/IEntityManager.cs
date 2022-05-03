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
        /// Return a list containg the entities actually on the game. 
        /// </summary>
        List<IDynamicEntity> Entities { get; }

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
