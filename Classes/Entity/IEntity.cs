using System;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Enums;

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

        public abstract Task LookAt(BodyParts bodyPart = BodyParts.Body);
        public abstract bool HasLineOfSight(BodyParts bodyPart = BodyParts.Body);
    }
}