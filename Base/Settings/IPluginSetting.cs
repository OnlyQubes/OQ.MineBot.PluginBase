﻿namespace OQ.MineBot.PluginBase.Base
{
    public interface IPluginSetting
    {
        /// <summary>
        /// Name of the settings.
        /// </summary>
        string name { get; set; }
        /// <summary>
        /// Decription of the setting.
        /// </summary>
        string description { get; set; }
        /// <summary>
        /// Default value of the setting.
        /// </summary>
        object value { get; set; }

        /// <summary>
        /// Contains a refference of the parent
        /// setting if it's in a Setting group.
        /// </summary>
        IPluginSetting parent { get; set; }
        string saveName { get; set; }

        /// <summary>
        /// Get the setting
        /// value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Get<T>();
    }
}