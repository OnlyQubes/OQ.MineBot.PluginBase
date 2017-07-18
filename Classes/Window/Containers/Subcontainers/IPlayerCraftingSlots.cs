using System;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerCraftingSlots : ISearchableContainer
    {
        /// <summary>
        /// Assign a parent container for this class.
        /// This class refferences to the inner container
        /// of the inventory to get the appriopriate slots.
        /// </summary>
        /// <param name="inventory"></param>
        void AssignContainer(IInventory inventory);

        /// <summary>
        /// Get a slot from the 
        /// crafting square.
        /// </summary>
        /// <param name="slot">
        /// Goes from 0-3. 
        /// 0 - top left, 1 - top right,
        /// 2 - bottom left, 3 - bottom right. 
        /// </param>
        /// <returns></returns>
        ISlot GetSquareSlot(byte slot);
        /// <summary>
        /// Get the item that is in the
        /// crafted item slot.
        /// </summary>
        /// <returns></returns>
        ISlot GetCraftedSlot();

        /// <summary>
        /// Drops a single item from the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the action id.</returns>
        short DropItem(CraftingSlots index);
        /// <summary>
        /// Drops a single item from the window and
        /// does a callback with the success state.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        short DropItemAsync(CraftingSlots index, Action<bool> callback);
        /// <summary>
        /// Drops a full stack from the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the action id.</returns>
        short DropItemStack(CraftingSlots index);
        /// <summary>
        /// Drops a full stack from the window and
        /// does a callback with the success state.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        short DropItemStackAsync(CraftingSlots index, Action<bool> callback);
    }

    public enum CraftingSlots
    {
        Crafted = 0,
        TopLeft = 1,
        TopRight = 2,
        BottomLeft = 3,
        BottomRight = 4
    }
}