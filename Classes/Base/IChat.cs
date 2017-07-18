namespace OQ.MineBot.PluginBase.Classes.Base
{
    public interface IChat
    {
        /// <summary>
        /// Parsed message RAW message to message only.
        /// (Excludes color information)
        /// </summary>
        string Parsed { get; set; }
        /// <summary>
        /// Raw chat text received from the serer.
        /// </summary>
        string Raw { get; set; }
    }
}