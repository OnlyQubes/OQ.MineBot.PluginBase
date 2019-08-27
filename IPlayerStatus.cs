using OQ.MineBot.PluginBase.Classes.Entity.Player;
using OQ.MineBot.PluginBase.Classes.Window;
using OQ.MineBot.PluginBase.Classes.Window.Containers;

namespace OQ.MineBot.PluginBase
{
    public abstract class IPlayerStatus
    {
        /// <summary>
        /// Is the player connected
        /// to a server.
        /// </summary>
        public bool loggedIn { get; protected set; }

        /// <summary>
        /// Has the player spawned and
        /// is he controllable?
        /// </summary>
        public bool spawned { get; protected set; }

        /// <summary>
        /// Ping to server and back.
        /// </summary>
        public int ping { get; protected set; }

        /// <summary>
        /// Username of the player.
        /// </summary>
        public string username { get; protected set; }

        /// <summary>
        /// Uuid of the player.
        /// </summary>
        public string uuid { get; protected set; }

        /// <summary>
        /// Is the player currently switching worlds/respawning.
        /// (E.g. going from overworld to nether)
        /// (aka Loading world)
        /// </summary>
        public bool switchingWorlds { get; protected set; }

        /// <summary>
        /// Is the player currently eating?
        /// </summary>
        public bool eating { get; protected set; }

        /// <summary>
        /// Currently selected hand.
        /// </summary>
        public int hand { get; protected set; }
    }
}