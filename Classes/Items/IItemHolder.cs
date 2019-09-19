using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes.Blocks;
using OQ.MineBot.PluginBase.Classes.Entity;
using OQ.MineBot.PluginBase.Classes.Items.Groups;
using OQ.MineBot.PluginBase.Classes.Materials;

namespace OQ.MineBot.PluginBase.Classes.Items
{
    public interface IItemHolder
    {
        /// <summary>
        /// All item refferences are stored here.
        /// </summary>
        IItem[] items { get; set; }

        /// <summary>
        /// All pickaxes are stored here.
        /// (Also stored in 'items')
        /// </summary>
        Dictionary<short, IItem> pickaxes { get; set; }
        Dictionary<short, IItem> shovels { get; set; }
        Dictionary<short, IItem> axes { get; set; }
        Dictionary<short, IItem> hoes { get; set; }
        Dictionary<short, IItem> swords { get; set; }

        /// <summary>
        /// All helmets are stored here.
        /// (Also stored in 'items')
        /// </summary>
        Dictionary<short, IItem> helmets { get; set; }
        Dictionary<short, IItem> chestplates { get; set; }
        Dictionary<short, IItem> leggings { get; set; }
        Dictionary<short, IItem> boots { get; set; }

        bool IsHelmet(short id);
        bool IsChestplate(short id);
        bool IsLeggings(short id);
        bool IsBoots(short id);


        /// <summary>
        /// Gets item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IItem GetItem(short id);

        /// <summary>
        /// Get items by material.
        /// </summary>
        /// <param name="toolMaterial"></param>
        /// <returns></returns>
        IItem[] GetItems(MaterialTools toolMaterial);

        /// <summary>
        /// Get a typed item.
        /// (E.g.: IPickaxe, IShovel, IAxe,
        /// IHoe, ISword)
        /// </summary>
        /// <param name="toolMaterial"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        IItem GetTyped(MaterialTools toolMaterial, short id);

        /// <summary>
        /// Get the speed at which this
        /// material mines at.
        /// </summary>
        /// <param name="material"></param>
        /// <param name="slot"></param>
        /// <param name="effects"></param>
        /// <returns></returns>
        float GetMiningSpeed(CraftableMaterials? material, ISlot slot, IEffectContainer effects);

        /// <summary>
        /// Check if our material is worse
        /// than block material.
        /// </summary>
        /// <param name="ourMaterial"></param>
        /// <param name="blockMaterial"></param>
        /// <returns></returns>
        bool IsWorse(CraftableMaterials? ourMaterial, CraftableMaterials blockMaterial);
    }
}