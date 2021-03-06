﻿using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Window.Containers;
using OQ.MineBot.PluginBase.Classes.World;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    public abstract class ITask
    {
        /// <summary>
        /// This token can be used to check if the
        /// plugin has been disabled.
        /// </summary>
        public IStopToken Token { get; set; }

        public IBotContext Context { get; set; }

        public IPlayerState     State      { get; set; }   // Reference to quickly access players status.
        public IPlayerFunctions Actions     { get; set; }   // Reference to quickly access player functions.
        public IWorld           World       { get; set; }   // Reference to quickly access players world.
        public IInventory       Inventory
        {
            get { return Context.Containers.GetInventory(); }
        } // Refference to quickly access players inventory.

        public virtual async Task Start()     { }
        public virtual async Task Stop()      { }

        /// <summary>
        /// Determines if any of the listeners will be
        /// called for this task (for this tick only).
        /// 
        /// True  - listeners will be invoked normally.
        /// Flase - no listener will be invoked.
        /// </summary>
        public abstract bool Exec();
    }
}