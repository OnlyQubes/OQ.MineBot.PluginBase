using OQ.MineBot.PluginBase.Classes.Blocks;

namespace OQ.MineBot.PluginBase.Classes.Items
{
    public interface IUpgradable
    {
        /// <summary>
        /// Material of the item.
        /// </summary>
        CraftableMaterials material { get; set; }
    }
}