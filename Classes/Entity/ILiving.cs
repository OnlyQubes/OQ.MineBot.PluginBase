
namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public interface ILiving : IEntity
    {
        /// <summary>
        /// Rotation of the entity.
        /// </summary>
        IRotation rotation { get; set; }

        /// <summary>
        /// How many ticks is the entity
        /// alive for.
        /// </summary>
        int ticks { get; }

        /// <summary>
        /// Has this entity been moved
        /// at least once?
        /// </summary>
        bool moved { get; set; }

        /// <summary>
        /// All effects on the entity
        /// are stored here.
        /// </summary>
        IEffectContainer effects { get; set; }

        /// <summary>
        /// Vehicle that the entity is attached to.
        /// </summary>
        int vehicleId { get; set; }
    }
}