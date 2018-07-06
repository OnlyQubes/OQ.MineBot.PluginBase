using System;

namespace OQ.MineBot.PluginBase.Base.Plugin
{
    public abstract class IPlugin : ICloneable
    {
        /// <summary>
        /// All settings should be stored here.
        /// </summary>
        public readonly SettingCollection Setting = new SettingCollection();

        public IPluginSetting At(int index) {
            return Setting.At(index);
        } 

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