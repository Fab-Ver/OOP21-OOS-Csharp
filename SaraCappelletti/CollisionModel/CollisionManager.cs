using Commons.Geometry;
using FabioVeroli.Entity;
using SaraCappelletti.PlayerModel;
using System.Collections.Generic;

namespace SaraCappelletti.CollisionModel
{
    internal class CollisionManager : ICollisionManager
    {
        private const double COLLISION_BOUND = 15.0;

        private double _platformY;

        public void PlayerCollidesWidth(IPlayer pl, List<IDynamicEntity> objects)
        {
            _platformY = Player.LAND;
            objects.ForEach(e =>
            {
                if (e.Type == EntityType.PLATFORM)
                {
                    if (IsPlayerAbove(pl, e))
                    {
                        _platformY = e.Bounds.MinY;
                    }
                }
                else
                {
                    Rectangle playerBounds = ShrinkBounds(pl.Bounds, COLLISION_BOUND);
                    if (pl.IsShieldActive && e.Type == EntityType.OBSTACLE)
                    {
                        e.Hit = false;
                    }
                    else if (e.Bounds.Intersects(playerBounds) && !e.Hit)
                    {
                        e.OnCollision();
                    }
                }
            });
            pl.LandHeight = _platformY;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">The player that has to be above</param>
        /// <param name="e">The object that has to be below</param>
        /// <returns>True if player is above e</returns>
        private static bool IsPlayerAbove(IPlayer player, IDynamicEntity e)
        {
            return player.Bounds.MaxY <= e.Bounds.MinY
                    && player.Bounds.MaxX >= e.Bounds.MinX
                    && player.Bounds.MinX <= e.Bounds.MaxX;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bounds">Initial bounds</param>
        /// <param name="amount">The amount to shrink each side</param>
        /// <returns>The modified bounds</returns>

        private static Rectangle ShrinkBounds(Rectangle bounds, double amount)
        {
            return new Rectangle(bounds.MinX + amount, bounds.MinY + amount,
                    bounds.Width - amount * 2, bounds.Height - amount * 2);
        }
    }
}
