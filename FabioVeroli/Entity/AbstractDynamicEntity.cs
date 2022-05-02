using Commons.Geometry;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Abstract class defining behaviors common to all entity. 
    /// </summary>
    public abstract class AbstractDynamicEntity : IDynamicEntity
    {

        private readonly Size _dimensions;
        private readonly Point _coordinates;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates">The coordinates of the entity on the screen.</param>
        /// <param name="dimensions"> The size of the entity.</param>
        /// <param name="level">The level on which the entity spawn.</param>
        /// <param name="type">The type identifying the entity.</param>
        /// <param name="distance">The distance after that next entity should spawn.</param>
        internal AbstractDynamicEntity(Point coordinates, Size dimensions, SpawnLevel level, EntityType type, double distance)
        {
            this._coordinates = coordinates;
            this._dimensions = dimensions;
            this.Distance = distance;
            this.Level = level;
            this.Type = type;
            this.Hit = false;
        }

        public SpawnLevel Level { get; }

        public EntityType Type { get; }

        public double Distance { get; }

        public bool Hit { get; set; }

        public void UpdatePosition(float speedX) => _coordinates.X -= speedX;

        public Rectangle Bounds { get => new Rectangle(_coordinates.X, _coordinates.Y, _dimensions.Width, _dimensions.Height); }

        public bool IsOutofScreen() => _coordinates.X < -_dimensions.Width;

        public void OnCollision()
        {
            this.Hit = true;
            ActivateEffect();
        }

        /// <summary>
        /// Defines the sequence of action that represents the entity's effect.
        /// </summary>
        protected abstract void ActivateEffect();
    }
}
