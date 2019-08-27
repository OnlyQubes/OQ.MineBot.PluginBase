using System;

namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public abstract class IEntity
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// Position of the entity.
        /// </summary>
        public IPosition Position { get; set; }

        /// <summary>
        /// Is this entity unloaded?
        /// </summary>
        public bool HasDespawned { get; set; }

        /// <summary>
        /// Time that this entity has existed for the bot.
        /// </summary>
        public DateTime Spawned = DateTime.Now;

        public int GetAge() {
            return (int) (DateTime.Now.Subtract(Spawned).TotalMilliseconds / 50);
        }
    }
}