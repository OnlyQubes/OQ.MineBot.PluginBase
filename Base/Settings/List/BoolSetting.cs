﻿namespace OQ.MineBot.PluginBase.Base
{
    public class BoolSetting : IParentSetting, IPluginSetting
    {
        /// <summary>
        /// Name of the settings.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Decription of the setting.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Default value of the setting.
        /// </summary>
        public object value {
            get {
                if (_value.GetType() != typeof(bool)) {
                    bool temp;
                    if (bool.TryParse((string)_value, out temp))
                        return temp;
                }
                return _value;
            }
            set { _value = value; }
        }

        /// <summary>
        /// Contains a refference of the parent
        /// setting if it's in a Setting group.
        /// </summary>
        public IPluginSetting parent { get; set; }
        public string saveName { get; set; }

        private object _value;

        public BoolSetting(string name, string description, bool value) {
            this.name = name;
            this.description = description;
            this.value = value;
        }
        public BoolSetting(string displayName, string internalName, string description, bool value) {
            this.name = displayName;
            this.saveName = internalName;
            this.description = description;
            this.value = value;
        }

        /// <summary>
        /// Get the setting
        /// value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() {
            return (T)value;
        }
    }
}