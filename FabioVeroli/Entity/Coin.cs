using System.Drawing;

namespace FabioVeroli.Entity
{
    class Coin : AbstractDynamicEntity
    {
        public Coin(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance)
               : base(coordinates, dimensions, level, type, distance)
        {
        }
    }
}
