using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Crafting;
using OQ.MineBot.PluginBase.Classes.Physics;

namespace OQ.MineBot.PluginBase
{
    public abstract class IPlayerController
    {
        public abstract IPlayerStatus Status { get; }

        public abstract IPlayerManager Manager { get; }
        public abstract IPlayerPhysics PhysicsEngine { get; }

        public abstract ICrafting Crafting { get; }
        public abstract IControls Controls { get; }

        public abstract IPosition GetPosition();
        public abstract ILocation GetLocation();
    }
}