namespace OQ.MineBot.PluginBase.Base
{
    /* 
        Request plugins (plugins that inherit this class)
        get called once the user specifically calls this plugin.
    */
    public interface IRequestPlugin : IPlugin
    {
        /// <summary>
        /// All requestable functions should
        /// be storedh ere.
        /// </summary>
        IRequestFunction[] functions { get; set; }
    }

    public interface IRequestFunction
    {
        /// <summary>
        /// Name of this function.
        /// </summary>
        /// <returns></returns>
        string GetName();

        /// <summary>
        /// Called once the user requested
        /// for the plugin to start on this player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        PluginResponse OnRequest(IPlayer player);

        /// <summary>
        /// Called once the user requested
        /// for the plugin to start on these players.
        /// (This should not limit you to handle all player.
        /// You can choose to handle each seperartly)
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        PluginResponse OnRequest(IPlayer[] players);
    }
}