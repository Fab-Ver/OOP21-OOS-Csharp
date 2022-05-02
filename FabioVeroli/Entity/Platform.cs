using System.Drawing;

namespace FabioVeroli.Entity
{
    class Platform : AbstractDynamicEntity
    {
        public Platform(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance)
               : base(coordinates, dimensions, level, type, distance)
        {
        }
    }
}
