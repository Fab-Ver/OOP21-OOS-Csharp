using System;
using System.Reflection;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Enumeration identifying the level on which entities could spawn.
    /// </summary>
    public enum SpawnLevel
    {
        [LevelAttr(1.0f)] ZERO,
        [LevelAttr(0.75f)] ONE,
        [LevelAttr(0.5f)] TWO
    }

    /// <summary>
    /// Custom attribute defining the Y coordinate for every level of the enum. 
    /// </summary>
    class LevelAttr : Attribute
    {
        internal LevelAttr(float spawnY)
        {
            this.SpawnY = spawnY;
        }

        public float SpawnY { get; private set; }
       
    }

    /// <summary>
    /// Class defining extension method for the enum SpawnLevel. 
    /// </summary>
    public static class Levels
    {
        public static float GetSpawnY(this SpawnLevel sp)
        {
            LevelAttr attr = GetAttr(sp);
            return attr.SpawnY;
        }

        private static LevelAttr GetAttr(SpawnLevel l) => (LevelAttr)Attribute.GetCustomAttribute(ForValue(l), typeof(LevelAttr));

        private static MemberInfo ForValue(SpawnLevel l) => typeof(SpawnLevel).GetField(Enum.GetName(typeof(SpawnLevel), l));
    }
}
