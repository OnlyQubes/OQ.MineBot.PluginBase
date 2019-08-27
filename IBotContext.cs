using OQ.MineBot.PluginBase.Bot;
using OQ.MineBot.PluginBase.Classes.Crafting;
using OQ.MineBot.PluginBase.Classes.Entity.Lists;
using OQ.MineBot.PluginBase.Classes.Entity.Player;
using OQ.MineBot.PluginBase.Classes.Physics;
using OQ.MineBot.PluginBase.Classes.Window;
using OQ.MineBot.PluginBase.Classes.World;
using OQ.MineBot.PluginBase.Utility;

namespace OQ.MineBot.PluginBase
{
    public interface IBotContext
    {
        /// <summary>
        /// Packet sending should be hooked
        /// to this. So that the bot could do
        /// packet sending withouth interacting
        /// with the actualy packets.
        /// </summary>
        IPlayerFunctions functions { get; set; }
        /// <summary>
        /// Player events based on the packets
        /// should be stored here.
        /// </summary>
        IPlayerStatus status { get; set; }
        /// <summary>
        /// Status of the player.
        /// </summary>
        IPlayerEvents events { get; set; }
        /// <summary>
        /// Manages the ticks of the player.
        /// (E.g.: movement, keep alive checks)
        /// </summary>
        IPlayerManager manager { get; set; }
        /// <summary>
        /// World that the player is loaded
        /// into.
        /// </summary>
        IWorld world { get; set; }
        /// <summary>
        /// All entities.
        /// </summary>
        IEntityList entities { get; set; }
        /// <summary>
        /// Physics engine for the player.
        /// </summary>
        IPlayerPhysics physicsEngine { get; set; }
        /// <summary>
        /// Settings of the player.
        /// </summary>
        IBotSettings settings { get; set; }
        /// <summary>
        /// Tick manager for the player.
        /// </summary>
        ITickManager tickManager { get; set; }
        /// <summary>
        /// High level controls.
        /// </summary>
        IControls controls { get; set; }
        /// <summary>
        /// Crafting.
        /// </summary>
        ICrafting crafting { get; set; }

        /// <summary>
        /// Player id. (Used to communicate
        /// with the plugin server.)
        /// </summary>
        byte[] playerChannel { get; set; }
    }
}