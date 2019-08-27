using OQ.MineBot.PluginBase.Classes.Entity;

namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class RayHit
    {
        /// <summary>
        /// Position that hte object was hit at.
        /// (Should be used for mobs only)
        /// (More specific than location)
        /// </summary>
        public IPosition position;
        /// <summary>
        /// Location that the object was hit at.
        /// </summary>
        public ILocation location;

        /// <summary>
        /// Type of the object that was hit.
        /// </summary>
        public HitType type;

        /// <summary>
        /// Only set if type is Entity.
        /// </summary>
        public ILiving entity;

        // Used for blocks.
        public RayHit(ILocation location) {
            this.location = location;
            this.type  = HitType.Block;
            this.position = location.ToPosition();
        }
        // Used for entities.
        public RayHit(ILocation location, ILiving entity) {
            this.location = location;
            this.type  = HitType.Entity;
            this.position = entity.Position;
            this.entity = entity;
        }
    }

    public enum HitType
    {
        Entity,
        Block
    }
}