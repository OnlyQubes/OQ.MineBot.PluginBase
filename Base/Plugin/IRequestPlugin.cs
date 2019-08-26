﻿namespace OQ.MineBot.PluginBase.Base.Plugin
{
    public abstract class IRequestPlugin : IPlugin
    {
        public abstract IRequestFunction[] GetFunctions();
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
        /// <param name="macro">Did a macro invoke this call.</param>
        /// <returns></returns>
        PluginResponse OnRequest(IPlayer player, bool macro = false);

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