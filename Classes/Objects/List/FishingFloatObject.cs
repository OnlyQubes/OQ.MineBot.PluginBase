namespace OQ.MineBot.PluginBase.Classes.Objects.List
{
    public class FishingFloatObject : IWorldObject
    {
        /// <summary>
        /// Entity id of the owner.
        /// </summary>
        public int Owner { get; set; }

        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return ObjectTypes.FishingHook;
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