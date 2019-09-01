namespace OQ.MineBot.PluginBase.Classes.Entity.Objects.List
{
    // Includes also spectal arrows.
    public class ArrowObject : IWorldObject
    {
        /// <summary>
        /// The entity ID of the shooter + 1 (Subtract 1 to get the actual entity ID)
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return ObjectTypes.TippedArrow;
        }

        /// <summary>
        /// Makes a copy of a world object.
        /// </summary>
        /// <returns></returns>
        public IWorldObject Copy() {
            return (IWorldObject)MemberwiseClone();
        }
    }
}