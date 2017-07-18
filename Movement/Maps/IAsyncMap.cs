namespace OQ.MineBot.PluginBase.Movement.Maps
{
    public interface IAsyncMap : IAreaMap
    {
        /// <summary>
        /// Is the map already started.
        /// </summary>
        bool Started { get; set; }

        /// <summary>
        /// Starts the async mapping
        /// process.
        /// </summary>
        /// <returns></returns>
        bool Start();
    }
}