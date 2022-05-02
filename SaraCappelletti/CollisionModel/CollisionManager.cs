using FabioVeroli.Entity;
using SaraCappelletti.PlayerModel;
using System.Collections.Generic;

namespace SaraCappelletti.CollisionModel
{
    internal class CollisionManager : ICollisionManager
    {
        private const double COLLISION_BOUND = 15.0;

        private double _platformY;

        public void PlayerCollidesWidth(Player pl, List<IDynamicEntity> objects)
        {
            _platformY = Player.LAND;
            objects.ForEach(e =>
            {
                if (e.Type == EntityType.PLATFORM)
                {
                    if (IsPlayerAbove(pl, e))
                    {
                        _platformY = e.GetBounds().Y;
                    }
                }
                else
                {
                    Rectangle playerBounds = ShrinkBounds(pl.Bounds, COLLISION_BOUND);
                    if (pl.IsShieldActive && e.Type == EntityType.OBSTACLE)
                    {
                        e.Hit = false;
                    }
                    else if (e.GetBounds().Intersects(playerBounds) && !e.Hit)
                    {
                        e.OnCollision();
                    }
                }
            });
            pl.LandHeight = _platformY;
        }

        /**
         * 
         * @param player the player that has to be above
         * @param e the object that has to be below
         * @return true if player is above e 
         */
        private bool IsPlayerAbove(IPlayer player, IDynamicEntity e)
        {
            return player.Bounds.MaxY <= e.GetBounds().Y + e.GetBounds().Height
                    && player.Bounds.MaxX >= e.GetBounds().X + e.GetBounds().Width
                    && player.Bounds.MinX <= e.GetBounds().X;
        }

        /**
         * 
         * @param bounds initial bounds
         * @param amount the amount to shrink each side
         * @return the modified bounds
         */
        private Rectangle ShrinkBounds(Rectangle bounds, double amount)
        {
            return new Rectangle(bounds.MinX + amount, bounds.MinY + amount,
                    bounds.Width - amount * 2, bounds.Height - amount * 2);
        }
    }
}
