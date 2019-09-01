namespace OQ.MineBot.PluginBase.Classes.Entity.Objects.List
{
    public class ItemFrameObject : IWorldObject
    {
        public Facing FrameFacing { get; set; }

        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return ObjectTypes.ItemFrames;
        }

        /// <summary>
        /// Makes a copy of a world object.
        /// </summary>
        /// <returns></returns>
        public IWorldObject Copy() {
            return (IWorldObject)MemberwiseClone();
        }
    }

    public enum Facing
    {
        South,
        West, 
        North,
        East
    }
}