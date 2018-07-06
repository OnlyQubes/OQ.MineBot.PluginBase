namespace OQ.MineBot.PluginBase.Base
{
    public class GroupSetting : IParentSetting, IPluginSetting
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
            get { return false; }
            set { return; }
        }
        public bool isOpen;

        /// <summary>
        /// Contains a refference of the parent
        /// setting if it's in a Setting group.
        /// </summary>
        public IPluginSetting parent { get; set; }
        public string saveName { get; set; }

        private object _value;

        public GroupSetting(string name, string description) {
            this.name = name;
            this.description = description;
            this.value = name;
        }

        public void Add(IPluginSetting setting) {
            this.Add(value, setting);
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