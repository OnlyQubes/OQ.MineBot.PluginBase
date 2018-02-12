using OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers
{
    public interface IInventory : IWindow, ISearchableContainer
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

        /// <summary>
        /// Deposits the full inventory to
        /// the specified window.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="exclude">Items that should not be stored</param>
        /// <param name="include">Only items that can be stored</param>
        void Deposite(IWindow window, int[] exclude, int[] include = null);

        /// <summary>
        /// Takes items from a window to the inventory.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="exclude"></param>
        /// <param name="include"></param>
        void Take(IWindow window, int[] exclude, int[] include);

        /// <summary>
        /// Attempts to select an item with
        /// the specified id.
        /// 
        /// select - bring item to hotbar, if it's not
        /// on there already and select it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Select(ushort id);

        /// <summary>
        /// Attempts to select an item from
        /// the specified id list.
        /// 
        /// select - bring item to hotbar, if it's not
        /// on there already and select it.
        /// </summary>
        /// <param name="id">Item id that was selected (-1 if none)</param>
        /// <returns></returns>
        int Select(ushort[] id);
    }
}