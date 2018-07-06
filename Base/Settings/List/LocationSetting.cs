using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.Protocols.Classes.Base;

namespace OQ.MineBot.PluginBase.Base
{
    public class LocationSetting: IParentSetting, IPluginSetting
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
            get { return _value; }
            set
            {
                if (value is string) _value = Location.Parse((string)value) ?? new Location(0, 0, 0);
                else _value = value;
            }
        }

        /// <summary>
        /// Contains a refference of the parent
        /// setting if it's in a Setting group.
        /// </summary>
        public IPluginSetting parent { get; set; }
        public string saveName { get; set; }

        private object _value;

        public LocationSetting(string name, string description) {
            this.name = name;
            this.description = description;
        }
        public LocationSetting(string name, string description, ILocation value) {
            this.name = name;
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