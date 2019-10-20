using System.Collections.Generic;
using OQ.MineBot.GUI.Protocol.Movement.Maps;
using OQ.MineBot.PluginBase.Classes.Physics.Colliders;
using OQ.MineBot.PluginBase.Movement.Maps;

namespace OQ.MineBot.PluginBase.Classes.Physics
{
    public interface IPlayerPhysics
    {
        /// <summary>
        /// Called before any physics calls
        /// are checked.
        /// </summary>
        event PlayerPhysicsDelegates.PhysicsPreTickDelegate onPhysicsPreTick;
        /// <summary>
        /// Called each physics tick.
        /// endPosition - the position that has
        /// been calculated to be sent to the server.
        /// (This can be modified, can be null if
        /// nothing will change on tick)
        /// </summary>
        event PlayerPhysicsDelegates.PhysicsTickDelegate onPhysicsTick;
        /// <summary>
        /// Called once the player is about to fall.
        /// This event can be cancelled.
        /// fallPosition - position once this fall
        /// tick is excecuted.
        /// </summary>
        event PlayerPhysicsDelegates.FallTickDelegate onFallTick;
        /// <summary>
        /// Called once the players rotation changes.
        /// </summary>
        event PlayerPhysicsDelegates.RotationDelegate onRotationChanged;

        /// <summary>
        /// Is the player currently jumping?
        /// (Jumped and still hasn't landed)
        /// </summary>
        bool jumping { get; set; }

        /// <summary>
        /// Current map that the player is following.
        /// </summary>
        IAreaMap path { get; }

        /// <summary>
        /// A queue that holds rotations that should be sent
        /// to the server once we can. 
        /// </summary>
        Queue<PrecomputedRotationList> precomputedRotations { get; set; }

        /// <summary>
        /// Velocity of the player.
        /// (Usually used for the vertical
        /// calculations)
        /// </summary>
        IVector Velocity { get; }

        /// <summary>
        /// Player collision data.
        /// </summary>
        ICubeCollider collider { get; set; }

        /// <summary>
        /// Is the player on ground.
        /// </summary>
        bool isGrounded { get; set; }

        /// <summary>
        /// Is the player in water.
        /// </summary>
        bool inWater { get; set; }

        /// <summary>
        /// Update player values with
        /// physical stuff.
        /// (E.g.: gravity)
        /// </summary>
        void PhysicsTick();

        /// <summary>
        /// Is the player on ground.
        /// (If world isn't loaded will
        /// always return 'false')
        /// </summary>
        /// <returns></returns>
        bool IsGrounded(ILocation[] _locations, out ILocation biggestY, IPosition playerPosition = null);
        ILocation GetGroundedBlock(MapOptions options);

        /// <summary>
        /// Get the ground blocks that are
        /// surrounding the player. 
        /// (should be 4 positions
        /// usually)
        /// </summary>
        /// <returns></returns>
        ILocation[] GetGroundBlockPos();
        
        /// <summary>
        /// Add the precomputed positions to the
        /// waiting list.
        /// </summary>
        /// <param name="rotations"></param>
        void AddPrecomputedRotations(PrecomputedRotationList rotations);
        /// <summary>
        /// Cancels all other precomputed 
        /// movements and add the new one.
        /// </summary>
        void ForcePrecomputedRotations(PrecomputedRotationList rotations);

        /// <summary>
        /// Attempts to jump
        /// </summary>
        /// <returns></returns>
        bool Jump();
        /// <summary>
        /// Can the player jump
        /// at the moment?
        /// </summary>
        /// <returns></returns>
        bool CanJump();

        /// <summary>
        /// Resets the position of the player.
        /// (Usually when sent in by a server update)
        /// </summary>
        /// <param name="position"></param>
        void Reset(IPosition position);

        /// <summary>
        /// Updates the map for the bot.
        /// </summary>
        /// <param name="map"></param>
        void SetMap(IAreaMap map);
        /// <summary>
        /// Removes the map for the bot.
        /// </summary>
        void RemoveMap();
    }

    public class PlayerPhysicsDelegates
    {
        public delegate void PhysicsPreTickDelegate(IBotContext context);
        public delegate void PhysicsTickDelegate(IBotContext context, IPosition endPosition);
        public delegate void FallTickDelegate(IBotContext context, IPosition fallPosition, EventCancelToken token);
        public delegate void RotationDelegate(IBotContext context, IRotation rotaion);
    }

    public class EventCancelToken
    {
        public bool isCancelled { get; set; }
    }
}