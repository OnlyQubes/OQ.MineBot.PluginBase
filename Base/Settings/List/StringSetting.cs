namespace OQ.MineBot.PluginBase.Base
{
    public class StringSetting : IPluginSetting
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
        public object value { get; set; }

        /// <summary>
        /// Contains a refference of the parent
        /// setting if it's in a Setting group.
        /// </summary>
        public IPluginSetting parent { get; set; }
        public string saveName { get; set; }


        public StringSetting(string name, string description, string value) {
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
            return (T) value;
        }
    }
}