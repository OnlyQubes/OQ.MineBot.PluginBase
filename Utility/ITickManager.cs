using System;

namespace OQ.MineBot.PluginBase.Utility
{
    public interface ITickManager
    {
        /// <summary>
        /// Registers an action to the tick counter,
        /// which will execute the action once enough
        /// ticks are reached.
        /// (Runs on physiscs thread)
        /// </summary>
        /// <param name="count">How many ticks need to pass until the action will be executed.</param>
        /// <param name="action">Action that will be executed after the amount of ticks.</param>
        void Register(int count, Action action);
    }
}