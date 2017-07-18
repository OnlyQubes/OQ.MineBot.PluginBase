namespace OQ.MineBot.PluginBase.Bot
{
    public interface IBotSettings
    {
        /// <summary>
        /// Should the bot reconnect
        /// once it gets dced.
        /// </summary>
        bool reconnect { get; }
        /// <summary>
        /// Max reconnect attempts it can do
        /// after it was dced.
        /// </summary>
        int maxReconnects { get; }

        /// <summary>
        /// Should this bot instance
        /// load worlds?
        /// 
        /// (Impacts the players ability to move,
        /// mine blocks, place block)
        /// </summary>
        bool loadWorld { get; }
        /// <summary>
        /// Should the bot use physics?
        /// </summary>
        bool usePhysics { get; }
        /// <summary>
        /// Are the worls sharable?
        /// </summary>
        bool staticWorlds { get; }

        /// <summary>
        /// Should this bot instance
        /// read the inventory packets?
        /// 
        /// (Impacts mining, block placement, equipment...)
        /// </summary>
        bool loadInventory { get; }

        /// <summary>
        /// Should entities be read
        /// by the player.
        /// (Impacts 'loadMobs' and 'loadPlayers')
        /// </summary>
        bool loadEntities { get; }
        /// <summary>
        /// Should monsters (E.g.: enemies,
        /// friendly) be loaded?
        /// (Can be disabled by 'loadEntitites')
        /// </summary>
        bool loadMobs { get; }
        /// <summary>
        /// Should player be loaded?
        /// (Can be disabled by 'loadEntitites')
        /// </summary>
        bool loadPlayers { get; }

        /// <summary>
        /// Should chat messages be
        /// read by the client? (and should
        /// it call the chat events.)
        /// (This does not impact the bots
        /// ability to write in chat)
        /// </summary>
        bool loadChat { get; }

        /// <summary>
        /// Incase the bot maxed out 
        /// on its reconnect attempts. 
        /// </summary>
        /// <returns></returns>
        bool canReconnect();
    }
}