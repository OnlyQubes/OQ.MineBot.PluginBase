using System;

namespace OQ.MineBot.PluginBase.Base.Plugin
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : Attribute
    {
        /// <summary>
        /// Current version of this plugin.
        /// Lower is older.
        /// (User for auto updates)
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Name of the plugin.
        /// (Will be displayed on the website
        /// and in the plugins tab)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the plugin.
        /// (Will be displayed on the website
        /// and in the plugins tab)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url to a showcase of the plugin.
        /// This is optinal, if provided it will appear in the
        /// plugin settings as a hyperlink.
        /// (E.g.: "https://www.youtube.com/video?...")
        /// </summary>
        public string ShowcaseAddress { get; set; }

        public PluginAttribute(int Version, string Name, string Description) {
            this.Version = Version;
            this.Name = Name;
            this.Description = Description;
        }

        public PluginAttribute(int Version, string Name, string Description, string ShowcaseAddress) {
            this.Version = Version;
            this.Name = Name;
            this.Description = Description;
            this.ShowcaseAddress = ShowcaseAddress;
        }
    }
}