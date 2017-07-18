namespace OQ.MineBot.PluginBase.Classes.Objects
{
    public interface IWorldObject
    {
        /// <summary>
        /// Entity id of this object.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        ObjectTypes GetType();

        /// <summary>
        /// Makes a copy of a world object.
        /// </summary>
        /// <returns></returns>
        IWorldObject Copy();
    }
}