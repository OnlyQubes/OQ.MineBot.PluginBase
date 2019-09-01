namespace OQ.MineBot.PluginBase.Classes.Entity.Objects.List
{
    public class PotionObject : IWorldObject {
        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return ObjectTypes.ThrownPotion;
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