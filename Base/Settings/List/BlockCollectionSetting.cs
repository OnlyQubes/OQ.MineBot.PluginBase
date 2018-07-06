using OQ.MineBot.PluginBase.Classes.Base;

namespace OQ.MineBot.PluginBase.Base
{
    public class BlockCollectionSetting : IPluginSetting
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
                if (value is string)
                    _value = BlockIdCollection.Parse((string)value);
                else
                    _value = value;
            }
        }

        /// <summary>
        /// Contains a refference of the parent
        /// setting if it's in a Setting group.
        /// </summary>
        public IPluginSetting parent { get; set; }
        public string saveName { get; set; }

        private object _value;

        public bool IsNegativeMode;

        public BlockCollectionSetting(string name, string description, string selected, bool negative) {
            this.name = name;
            this.description = description;
            this.value = selected;
            this.IsNegativeMode = negative;
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