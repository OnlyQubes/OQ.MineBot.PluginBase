using System;
using OQ.MineBot.GUI.Protocol.Movement.Maps;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Entity;
using OQ.MineBot.PluginBase.Classes.World;
using OQ.MineBot.PluginBase.Movement.Events;

namespace OQ.MineBot.PluginBase.Movement.Maps
{
    public interface IAreaMap : IDisposable
    {
        /// <summary>
        /// What is our current target.
        /// </summary>
        ILocation Target { get; set; }
        IPosition Offset { get; set; }

        /// <summary>
        /// Movement options.
        /// </summary>
        MapOptions Options { get; set; } 
        
        /// <summary>
        /// Is this map "finished".
        /// </summary>
        bool Complete { get; }
        /// <summary>
        /// Is this path valid.
        /// (Reachable)
        /// </summary>
        bool Valid { get; set; }
        /// <summary>
        /// Is the path search for this map
        /// completed.
        /// </summary>
        bool Searched { get; set; }

        /// <summary>
        /// Which player is using this map.
        /// </summary>
        IPlayer Player { get; }

        /// <summary>
        /// Token that sets if the 
        /// bot is stopped.
        /// </summary>
        IStopToken Token { get; set; }

        #region Events

        
/// <summary>
        /// Called when a path is complete.
        /// </summary>
        event MapEvents.GeneralUpdate Completed;
        /// <summary>
        /// Called once of the waypoints are reached.
        /// (A waypoint is a straight line)
        /// </summary>
        event MapEvents.GeneralUpdate WaypointReached;

        /// <summary>
        /// Called once this path is cancelled.
        /// 
        /// cuboid - current object we were on.
        /// </summary>
        event MapEvents.CuboidUpdate Cancelled;

        /// <summary>
        /// Called once a change is detected.
        /// (Block is placed in a cuboid)
        /// </summary>
        event MapEvents.CuboidUpdate ChangeDetected;
        /// <summary>
        /// Called when calculations of 
        /// the path are done. This includes
        /// the result if it was found or not.
        /// (Event before this would be 'ChangeDetected')
        /// 
        /// found - was the new path found?
        /// </summary>
        event MapEvents.SearchUpdate Recalculated;
        #endregion

        /// <summary>
        /// Simulates a physics tick.
        /// </summary>
        /// <returns></returns>
        IVector Tick();

        void CalculateFromNext(IWorld world,IEntity moveTarget);
    }
}