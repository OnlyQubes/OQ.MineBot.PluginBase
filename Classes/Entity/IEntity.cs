using System;
using System.Threading.Tasks;
using OQ.MineBot.GUI.Protocol.Movement.Maps;
using OQ.MineBot.PluginBase.Classes.Enums;
using OQ.MineBot.PluginBase.Movement.Events;

namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public abstract class IEntity
    {
        public event IPlayerDelegates.OnEntityEvent OnDespawned;

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
        public bool HasDespawned
        {
            get => _hasDespawned;
            set { _hasDespawned = value; if(value) OnDespawned?.Invoke(); }
        }
        private bool _hasDespawned = false;

        /// <summary>
        /// Time that this entity has existed for the bot.
        /// </summary>
        protected DateTime Spawned = DateTime.Now;

        public int GetAge() {
            return (int) (DateTime.Now.Subtract(Spawned).TotalMilliseconds / 50);
        }

        public abstract Task LookAt(BodyParts bodyPart = BodyParts.Body);
        public abstract bool HasLineOfSight(BodyParts bodyPart = BodyParts.Body);

        public abstract IMoveTask MoveTo(MapOptions options = null);
        public abstract IMoveTask MoveToRange(int maxRange, MapOptions options = null);
        public abstract IMoveTask Follow(MapOptions options = null);
        public abstract IMoveTask Follow(int maxRange, MapOptions options = null);
        public abstract IMoveTask Follow(int maxRange, int minRange, MapOptions options = null);
    }
}