using System.Drawing;

namespace FabioVeroli.Entity
{
    class Obstacle : AbstractDynamicEntity
    {
        public Obstacle(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance) 
               : base(coordinates, dimensions, level, type, distance)
        {
        }
    }
}
