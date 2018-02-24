using System;

namespace OQ.MineBot.PluginBase.Base.Plugin
{
    public abstract class IPlugin : ICloneable
    {
        /// <summary>
        /// All settings should be stored here.
        /// (NULL if there shouldn't be any settings)
        /// </summary>
        public IPluginSetting[] Setting { get; set; }

        /// <summary>
        /// Should be used to check compatability with the
        /// current version of the bot.
        /// </summary>
        public abstract void OnLoad(int version, int subversion, int buildversion);
        
        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}