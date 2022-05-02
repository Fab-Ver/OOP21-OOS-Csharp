using System.Drawing;

namespace FabioVeroli.Entity
{
    interface IDynamicEntity
    {

        void UpdatePosition(float speedX);

        RectangleF GetBounds();

        bool IsOutofScreen();

        SpawnLevel Level { get; }

        EntityType Type { get; }

        double Distance { get;  }

        bool Hit { get; set; }

        //void onCollision(Model model);
    }
}
