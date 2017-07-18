namespace OQ.MineBot.PluginBase.Base
{
    public class PluginResponse
    {
        /// <summary>
        /// Was the plugin "started" successfully.
        /// </summary>
        public bool success { get; }
        /// <summary>
        /// Response message to the start.
        /// (Should be given once '!success')
        /// </summary>
        public string message { get; }

        public PluginResponse(bool success, string message = "") {
            this.success = success;
            this.message = message;
        }
    }
}