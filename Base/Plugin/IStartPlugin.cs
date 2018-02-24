using System;
using OQ.MineBot.PluginBase.Base.Plugin.Tasks;
using OQ.MineBot.PluginBase.Bot;

namespace OQ.MineBot.PluginBase.Base.Plugin
{
    public abstract class IStartPlugin : IPlugin
    {
        /// <summary>
        /// This will be assigned by the program internally.
        /// </summary>
        public Action<ITask> RegisterTask;

        public virtual PluginResponse OnEnable (IBotSettings botSettings) { return null; }
        public virtual void           OnDisable() { }

        public virtual void           OnStart()   { }
        public virtual void           OnStop()    { }
    }
}