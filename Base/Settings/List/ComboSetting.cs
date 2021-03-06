﻿namespace OQ.MineBot.PluginBase.Base
{
    public class ComboSetting : IParentSetting, IPluginSetting
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
        public object value
        {
            get
            {
                if (_value.GetType() != typeof (int)) {
                    int temp;
                    if (int.TryParse((string)_value, out temp))
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

        public string[] values;

        public ComboSetting(string name, string description, string[] values, int index) {
            this.name = name;
            this.description = description;
            this.value = index;
            this.values = values;
        }
        public ComboSetting(string displayName, string internalName, string description, string[] values, int index) {
            this.name = displayName;
            this.saveName = internalName;
            this.description = description;
            this.value = index;
            this.values = values;
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