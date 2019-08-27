namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public abstract class IEntity
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        public int entityId { get; set; }

        /// <summary>
        /// Position of the entity.
        /// </summary>
        public IPosition location { get; set; }

        /// <summary>
        /// Is this entity unloaded?
        /// </summary>
        public bool unloaded { get; set; }
    }
}