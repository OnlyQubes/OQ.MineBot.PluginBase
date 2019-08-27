
namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public abstract class ILiving : IEntity
    {
        /// <summary>
        /// Rotation of the entity.
        /// </summary>
        public IRotation rotation { get; set; }

        /// <summary>
        /// How many ticks is the entity
        /// alive for.
        /// </summary>
        public abstract int ticks { get; }

        /// <summary>
        /// All effects on the entity
        /// are stored here.
        /// </summary>
        public IEffectContainer effects { get; set; }

        /// <summary>
        /// Has this entity been moved
        /// at least once?
        /// </summary>
        public bool moved { get; set; }


        /// <summary>
        /// Vehicle that the entity is attached to.
        /// </summary>
        public int vehicleId { get; set; }
    }
}