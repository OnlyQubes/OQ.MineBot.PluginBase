using System;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers
{
    public interface IInventory : IWindow
    {
        /// <summary>
        /// Equipments of the player.
        /// </summary>
        IPlayerEquipmentSlots equipment { get; set; }

        /// <summary>
        /// Hotbar of the player.
        /// </summary>
        IPlayerHotbarSlots hotbar { get; set; }

        /// <summary>
        /// The slots at the crafting position.
        /// </summary>
        IPlayerCraftingSlots crafting { get; set; }

        /// <summary>
        /// Inventory that is seen when
        /// the player opens the inventory.
        /// </summary>
        IPlayerInnerInventory inner { get; set; }

        Task<bool> Select(ushort id);
        Task<bool> Select(ushort[] ids);

        /// <param name="hotbarIndex">Index of hotbar (0-8)</param>
        /// <param name="index">Index of item in inventory.</param>
        Task<bool> BringToHotbar(byte hotbarIndex, int index);
    }
}