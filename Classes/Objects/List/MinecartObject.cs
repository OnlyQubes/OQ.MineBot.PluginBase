namespace OQ.MineBot.PluginBase.Classes.Objects.List
{
    public class MinecartObject : IWorldObject
    {
        /// <summary>
        /// What's the functionallity of the minecart.
        /// </summary>
        public Type MinecartType { get; set; }

        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return ObjectTypes.Minecart;
        }

        /// <summary>
        /// Makes a copy of a world object.
        /// </summary>
        /// <returns></returns>
        public IWorldObject Copy() {
            return (IWorldObject)MemberwiseClone();
        }
    }

    public enum Type
    {
        Empty = 0,
        Chest = 1,
        Furnace = 2,
        Tnt = 3,
        Spawner = 4,
        Hopper = 5,
        Command = 6
    }
}