using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Window.Containers;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    public abstract class ITask
    {
        /// <summary>
        /// This token can be used to check if the
        /// plugin has been disabled.
        /// </summary>
        public IStopToken token { get; set; }

        public IPlayer          player      { get; set; }
        public IPlayerStatus    status      { get; set; }   // Refference to quickly access players status.
        public IPlayerFunctions actions     { get; set; }   // Refference to quickly access player functions.
        public IInventory       inventory   { get; set; }   // Refference to quickly access players inventory.

        public virtual void Start()     { }
        public virtual void Stop()      { }
    }
}