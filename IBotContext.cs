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
    public abstract class IBotContext
    {
        /// <summary>
        /// Settings of the player.
        /// </summary>
        public abstract IBotSettings Settings { get; }

        /// <summary>
        /// Packet sending should be hooked
        /// to this. So that the bot could do
        /// packet sending withouth interacting
        /// with the actualy packets.
        /// </summary>
        public abstract IPlayerFunctions Functions { get; }
        /// <summary>
        /// Status of the player.
        /// </summary>
        public abstract IPlayerEvents Events { get; }

        /// <summary>
        /// World that the player is loaded
        /// into.
        /// </summary>
        public abstract IWorld World { get; }
        /// <summary>
        /// All entities.
        /// </summary>
        public abstract IEntityList Entities { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract IPlayerController Player { get; }

        /// <summary>
        /// Player events based on the packets
        /// should be stored here.
        /// </summary>
        public abstract IPlayerStatus Status { get; }
        /// <summary>
        /// Physics engine for the player.
        /// </summary>
        public abstract IPlayerPhysics PhysicsEngine { get; }
        /// <summary>
        /// High level controls.
        /// </summary>
        public abstract IControls Controls { get; }
        /// <summary>
        /// Crafting.
        /// </summary>
        public abstract ICrafting Crafting { get; }

        /// <summary>
        /// Tick manager for the player.
        /// </summary>
        public abstract ITickManager TickManager { get; }
    }
}