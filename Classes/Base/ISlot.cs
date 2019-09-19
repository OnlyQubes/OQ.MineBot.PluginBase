using System;
using System.IO;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Base;
using OQ.MineBot.PluginBase.Classes.Window;

namespace OQ.MineBot.PluginBase.Classes
{
    public static class SlotType
    {
        public static Type slotType;

        public static ISlot Create(ushort id, sbyte count = 1) {
            // Sanitise inputs.
            if (count > 64) count = 64;
            if (count < -1) count = -1;

            ISlot instance = (ISlot)Activator.CreateInstance(slotType);
            instance.Id = (short)id;
            instance.Count = count;
            return instance;
        }
    }

    public interface ISlot
    {
        int     Index     { get; set; }
        IWindow Container { get; set; }

        /// <summary>
        /// Id of the item in this slot.
        /// </summary>
        short Id { get; set; }

        /// <summary>
        /// How many items are in this slot.
        /// </summary>
        sbyte Count { get; set; }
        /// <summary>
        /// How much item does this item
        /// have taken.
        /// </summary>
        short Damage { get; set; }

        /// <summary>
        /// Nbt data for this item.
        /// </summary>
        object Nbt { get; set; }

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

        /// <summary>
        /// Is this slot empty?
        /// </summary>
        bool IsEmpty();
        bool IsStackFull();
        bool IsStackable();

        Task<bool> DropStack();
        Task<bool> Drop();
        Task<bool> Eat ();

        Task<bool> Select();
        Task<bool> Use();

        Task<bool> Transfer (ISlot other);
        Task<bool> DepositTo(IWindow window, sbyte index = -1);
        Task<bool> BringToHotbar(sbyte optionalSlotIndex = -1);

        bool IsWearable   ();
        Task<bool> PutOn  ();
        Task<bool> TakeOff();
    }
}