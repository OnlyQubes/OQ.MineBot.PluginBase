namespace OQ.MineBot.PluginBase.Base
{
    /*
        Start plugins (plugins that inherit this class)
        get called once the bot is started.
    */
    public interface IStartPlugin : IPlugin
    {
        /// <summary>
        /// Called once a "player" logs
        /// in to the server.
        /// (This does not start a new thread, so
        /// if you want to do any long temn functions
        /// please start your own thread!)
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        PluginResponse OnStart(IPlayer player);
    }
}