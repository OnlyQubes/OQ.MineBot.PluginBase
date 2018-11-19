using System.IO;
using OQ.MineBot.PluginBase.Classes.Base;

namespace OQ.MineBot.PluginBase.Classes
{
    public interface ISlot
    {
        /// <summary>
        /// Id of the item in this slot.
        /// </summary>
        short id { get; set; }

        /// <summary>
        /// How many items are in this slot.
        /// </summary>
        sbyte count { get; set; }
        /// <summary>
        /// How much item does this item
        /// have taken.
        /// </summary>
        short damage { get; set; }

        /// <summary>
        /// Nbt data for this item.
        /// </summary>
        object nbt { get; set; }

        /// <summary>
        /// Does this item have any nbt data?
        /// </summary>
        bool HasNbt();

        /// <summary>
        /// Attempts to get a name from the nbt data.
        /// </summary>
        /// <returns></returns>
        string GetName();
        /// <summary>
        /// Attempts to get the description from the nbt data.
        /// </summary>
        string GetLore();

        /// <summary>
        /// Does this item contain an enchantment with the specified id.
        /// </summary>
        bool HasEnchantment(int id);
        /// <summary>
        /// Get an enchantment level on this item by enchantment id.
        /// (-1 if not found)
        /// </summary>
        int GetEnchantmentLevel(int id);
        /// <summary>
        /// Get all enchantments.
        /// </summary>
        Enchantment[] GetEnchantments();

        /// <summary>
        /// Get a string representation of the nbt data.
        /// </summary>
        /// <returns></returns>
        string GetNBT();
    }
}