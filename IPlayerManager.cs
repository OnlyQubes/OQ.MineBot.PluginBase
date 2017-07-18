
namespace OQ.MineBot.PluginBase
{
    public interface IPlayerManager
    {
        /// <summary>
        /// Should we check if we received a keep
        /// alive packet from the server? 
        /// (If we haven't received one 
        /// for 30s then dc)
        /// </summary>
        bool checkKeepAlives { get; set; }

        /// <summary>
        /// Should we send movement packet
        /// (standing still) to the server?
        /// (If we don't send it the server
        /// won't update the players values such
        /// as hunger)
        /// </summary>
        bool sendIdle { get; set; }

        /// <summary>
        /// Should we send the movement packets?
        /// (If not you will only move locally
        /// or will need to handle the packet
        /// sending on your own)
        /// </summary>
        bool sendMovements { get; set; }

        /// <summary>
        /// Registers the keep alive as
        /// received.
        /// </summary>
        void KeepAliveCallback();
        void PassiveAliveCallback();
    }
}