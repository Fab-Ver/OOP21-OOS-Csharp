using System;
using System.Reflection;

namespace FabioVeroli.Entity
{
    /// <summary>
    /// Enumeration defining different types of entities.
    /// </summary>
    public enum EntityType
    {
        [EntityAttr(4.7f)] OBSTACLE,

        [EntityAttr(0.0f)] PLATFORM,

        [EntityAttr(5.3f)] COIN,

        [EntityAttr(5.0f)] POWERUP

    }

    /// <summary>
    /// Custom attribute defining the distance factor for different type of entities. 
    /// </summary>
    class EntityAttr : Attribute
    {
        internal EntityAttr(float distanceFactor)
        {
            this.DistanceFactor = distanceFactor;
        }

        public float DistanceFactor { get; private set; }
    }

    /// <summary>
    /// Class defining extension method for the enum EntityType. 
    /// </summary>
    public static class Entities
    {
        public static float GetDistanceFactor(this EntityType et)
        {
            EntityAttr attr = GetAttr(et);
            return attr.DistanceFactor;
        }

        private static EntityAttr GetAttr(EntityType e) => (EntityAttr)Attribute.GetCustomAttribute(ForValue(e), typeof(EntityAttr));

        private static MemberInfo ForValue(EntityType e) => typeof(EntityType).GetField(Enum.GetName(typeof(EntityType), e));
    }
}
