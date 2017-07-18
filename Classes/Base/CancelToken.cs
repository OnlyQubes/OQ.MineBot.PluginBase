namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class CancelToken : IStopToken
    {
        /// <summary>
        /// Should the process be stopped.
        /// </summary>
        public bool stopped { get { return m_stopped; } }
        private bool m_stopped = false;

        /// <summary>
        /// Updates the tokens state to stopped.
        /// </summary>
        public void Stop() {
            this.m_stopped = true;
        }

        public void Reset() {
            this.m_stopped = false;
        }
    }
}