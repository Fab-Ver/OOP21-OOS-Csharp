using FabioVeroli.Entity;
using SaraCappelletti.PlayerModel;
using System.Collections.Generic;

namespace SaraCappelletti.CollisionModel
{
    internal interface ICollisionManager
    {
        /// <summary>
        /// Checks all the collisions with the player.
        /// </summary>
        /// <param name="pl">The Player</param>
        /// <param name="objects">The actual list of Entity</param>
        void PlayerCollidesWidth(IPlayer pl, List<IDynamicEntity> objects);
    }
}
