using System.Drawing;

namespace FabioVeroli.Entity
{
    abstract class AbstractDynamicEntity : IDynamicEntity
    {

        private PointF _coordinates;
        private readonly SizeF _dimensions;

        public AbstractDynamicEntity(PointF coordinates, SizeF dimensions, SpawnLevel level, EntityType type, double distance)
        {
            this._coordinates = coordinates;
            this._dimensions = dimensions;
            this.Level = level;
            this.Type = type;
            this.Distance = distance;
            this.Hit = false;
        }

        public SpawnLevel Level { get; }

        public EntityType Type { get; }

        public double Distance { get; }

        public bool Hit { get; set; }

        public void UpdatePosition(float speedX) => _coordinates.X -= speedX;

        public RectangleF GetBounds() => new RectangleF(_coordinates, _dimensions);

        public bool IsOutofScreen() => _coordinates.X < -_dimensions.Width;

    }
}
