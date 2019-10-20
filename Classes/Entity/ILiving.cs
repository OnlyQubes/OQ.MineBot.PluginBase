
using OQ.MineBot.PluginBase.Classes.Entity.Equipment;
using OQ.MineBot.PluginBase.Classes.Enums;

namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public abstract class ILiving : IEntity
    {
        public event IPlayerDelegates.OnEntityEvent OnDeath;
        public event IPlayerDelegates.OnEntityEvent OnMoved;

        /// <summary>
        /// Rotation of the entity.
        /// </summary>
        public IRotation Rotation { get; set; }

        /// <summary>
        /// Has this entity been moved at least once?
        /// </summary>
        public bool HasMoved { get; set; }

        /// <summary>
        /// All effects on the entity are stored here.
        /// </summary>
        public IEffectContainer Effects { get; set; }

        /// <summary>
        /// Items that the entity is wearing/holding.
        /// </summary>
        public EntityEquipment Equipment { get; set; } = new EntityEquipment();

        /// <summary>
        /// Vehicle that the entity is attached to.
        /// </summary>
        public int VehicleId { get; set; }

        public abstract float GetHealth();
        public abstract bool IsDead();

        public abstract void Attack();
        public abstract void Attack(Hands hand);
        public abstract void Interact();
        public abstract void Interact(Hands hand);

        protected void InvokeOnDeath() { this.OnDeath?.Invoke(); }
        protected void InvokeOnMoved() { this.OnMoved?.Invoke(); }

    }
}