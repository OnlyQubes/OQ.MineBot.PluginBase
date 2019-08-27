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
        public IStopToken token { get; set; }

        public IBotContext context { get; set; }

        public IPlayerStatus    status      { get; set; }   // Refference to quickly access players status.
        public IPlayerFunctions actions     { get; set; }   // Refference to quickly access player functions.
        public IWorld           world       { get; set; }   // Refference to quickly access players world.
        public IInventory       inventory
        {
            get { return context.status.containers.inventory; }
            set { context.status.containers.inventory = value; }
        } // Refference to quickly access players inventory.

        public virtual void Start()     { }
        public virtual void Stop()      { }

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