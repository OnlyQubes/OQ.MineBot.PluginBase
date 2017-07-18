namespace OQ.MineBot.PluginBase.Classes.Materials
{
    public interface IMaterial
    {
        /// <summary>
        /// Name of this material.
        /// </summary>
        string name { get; set; }

        /// <summary>
        /// Is a tool needed to
        /// mine this material.
        /// </summary>
        MaterialTools requiredTool { get; set; }

        /// <summary>
        /// Can a block be placed in this
        /// materials place.
        /// </summary>
        bool canReplace { get; set; }
    }

    public enum MaterialTools
    {
        ANY, //All tools work.
        axe,
        pickaxe,
        shears,
        shovel,
        sword,
        none, //Unbrekable.
    }
}