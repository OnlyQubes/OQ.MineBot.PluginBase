namespace OQ.MineBot.PluginBase.Base
{
    public class PluginAuthor
    {
        /// <summary>
        /// Name of the author.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Key of the author.
        /// (This may be null.)
        /// (If this is given users
        /// can easilly navigate to the
        /// authors profile page.)
        /// </summary>
        public string publicKey { get; set; }

        public PluginAuthor(string name, string publicKey = null) {
            this.name = name;
            this.publicKey = publicKey;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() {
            return name;
        }
    }
}