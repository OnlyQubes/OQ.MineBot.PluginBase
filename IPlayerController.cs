using System.Threading.Tasks;
using OQ.MineBot.GUI.Protocol.Movement.Maps;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Crafting;
using OQ.MineBot.PluginBase.Classes.Entity;
using OQ.MineBot.PluginBase.Classes.Physics;
using OQ.MineBot.PluginBase.Pathfinding;

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
        public abstract IRotation GetRotation();

        public abstract float GetHealth();
        public abstract float GetFood();
        public abstract float GetFoodSaturation();
        public abstract bool  IsDead();

        public abstract int GetExperienceLevel();
        public abstract int GetExperience();

        public abstract IEffectContainer GetEffects() ;
        public abstract bool HasEffect(Effects effect);

        public abstract Task SetCrouchState(CrouchStates mode);
        public abstract bool IsCrouching();

        public abstract Task Respawn();

        public abstract Task<ICachedPath> CreateReusablePath(IPosition start, IPosition end, MapOptions options = null);
        public abstract Task<ICachedPath> CreateReusablePath(ILocation start, ILocation end, MapOptions options = null);
    }

    public enum CrouchStates
    {
        Crouch,
        Uncrouch
    }
}