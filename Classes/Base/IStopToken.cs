namespace OQ.MineBot.PluginBase.Classes
{
    public interface IStopToken
    {
        /// <summary>
        /// Should the process be stopped.
        /// </summary>
        bool stopped { get; }

        /// <summary>
        /// Updates the tokens state to stopped.
        /// </summary>
        void Stop();
    }
}