namespace OQ.MineBot.PluginBase.Base
{
    public class NumberSetting : IPluginSetting
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

        public int min, max, add;

        public NumberSetting(string name, string description, int value, int min, int max, int add = 1) {
            this.name = name;
            this.description = description;
            this.value = value;

            this.min = min;
            this.max = max;
            this.add = add;
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