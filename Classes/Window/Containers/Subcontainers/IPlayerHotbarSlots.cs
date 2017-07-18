using System;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerHotbarSlots : ISearchableContainer
    {
        /// <summary>
        /// Assign a parent container for this class.
        /// This class refferences to the inner container
        /// of the inventory to get the appriopriate slots.
        /// </summary>
        /// <param name="inventory"></param>
        void AssignContainer(IInventory inventory);

        /// <summary>
        /// Get item from the slot.
        /// </summary>
        /// <param name="slot">Goes from 0-8.</param>
        ISlot GetSlot(byte slot);

        /// <summary>
        /// Drops a single item from the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the action id.</returns>
        short DropItem(int index);
        /// <summary>
        /// Drops a single item from the window and
        /// does a callback with the success state.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        short DropItemAsync(int index, Action<bool> callback);
        /// <summary>
        /// Drops a full stack from the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the action id.</returns>
        short DropItemStack(int index);
        /// <summary>
        /// Drops a full stack from the window and
        /// does a callback with the success state.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        short DropItemStackAsync(int index, Action<bool> callback);

        /// <summary>
        /// Attempts to retrieve a slot position
        /// that is currently not occupied.
        /// </summary>
        /// <returns></returns>
        short FindFreeSlot();

        /// <summary>
        /// Bring an item from the inventory (or hotbar)
        /// to a specific hotbar position.
        /// </summary>
        /// <param name="hotbarSlot">0-8.</param>
        /// <param name="inventoryPosition">Item in inventory position.</param>
        /// <returns></returns>
        short BringToHotbar(short hotbarSlot, short inventoryPosition, Action<bool> callback);
    }
}