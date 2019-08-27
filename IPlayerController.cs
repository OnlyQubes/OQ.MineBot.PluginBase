using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Crafting;
using OQ.MineBot.PluginBase.Classes.Physics;

namespace OQ.MineBot.PluginBase
{
    public abstract class IPlayerController
    {
        public abstract IPlayerState State { get; }

        public abstract IPlayerManager Manager { get; }
        public abstract IPlayerPhysics PhysicsEngine { get; }

        public abstract ICrafting Crafting { get; }
        public abstract IControls Controls { get; }

        public abstract string GetUuid();
        public abstract string GetUsername();

        public abstract IPosition GetPosition();
        public abstract ILocation GetLocation(); // GetPosition.ToLocation(0);

        public abstract float GetHealth();
        public abstract float GetFood();
        public abstract float GetFoodSaturation();

        public abstract int GetExperienceLevel();
        public abstract int GetExperience();
    }
}