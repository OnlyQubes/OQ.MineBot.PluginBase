namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public interface IEntity
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        int entityId { get; set; }

        /// <summary>
        /// Position of the entity.
        /// </summary>
        IPosition location { get; set; }

        /// <summary>
        /// Is this entity unloaded?
        /// </summary>
        bool unloaded { get; set; }
    }
}