using System;
using System.Reflection;

namespace FabioVeroli.Entity
{
    public enum EntityType
    {
        [EntityAttr(4.7f)] OBSTACLE,

        [EntityAttr(0.0f)] PLATFORM,

        [EntityAttr(5.3f)] COIN,

        [EntityAttr(5.0f)] POWERUP

    }
    class EntityAttr : Attribute
    {
        internal EntityAttr(float distanceFactor)
        {
            this.DistanceFactor = distanceFactor;
        }

        public float DistanceFactor { get; private set; }
    }

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
