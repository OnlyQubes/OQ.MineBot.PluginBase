using OQ.MineBot.PluginBase.Classes.Entity.Player;
using OQ.MineBot.PluginBase.Classes.Window;
using OQ.MineBot.PluginBase.Classes.Window.Containers;

namespace OQ.MineBot.PluginBase
{
    public interface IPlayerStatus
    {
        /// <summary>
        /// Is the player connected
        /// to a server.
        /// </summary>
        bool loggedIn { get; set; }

        /// <summary>
        /// Has the player spawned and
        /// is he controllable?
        /// </summary>
        bool spawned { get; set; }

        /// <summary>
        /// Username of the player.
        /// </summary>
        string username { get; set; }

        /// <summary>
        /// Uuid of the player.
        /// </summary>
        string uuid { get; set; }

        /// <summary>
        /// Is the player currently eating?
        /// </summary>
        bool eating { get; set; }

        /// <summary>
        /// Currently selected hand.
        /// </summary>
        int hand { get; set; }

        /// <summary>
        /// State of the packets.
        /// (Login - loggin in to the server,
        /// game - in game)
        /// </summary>
        PacketState packetState { get; set; }

        /// <summary>
        /// Our player entity.
        /// </summary>
        IPlayerEntity entity { get; set; }

        /// <summary>
        /// Players inventory and all open containers
        /// are stored here.
        /// </summary>
        IWindowContainer containers { get; set; }

        /// <summary>
        /// Called once the account is logged in.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="uuid"></param>
        void LoginCallback(string name, string uuid);
    }

    public enum PacketState
    {
        Login,
        Game
    }
}