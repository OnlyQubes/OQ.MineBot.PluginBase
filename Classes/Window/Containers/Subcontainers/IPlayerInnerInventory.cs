using System;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerInnerInventory : ISearchableContainer
    {
        /// <summary>
        /// Assign a parent container for this class.
        /// This class refferences to the inner container
        /// of the inventory to get the appriopriate slots.
        /// </summary>
        /// <param name="inventory"></param>
        void AssignContainer(IInventory inventory);

        /// <summary>
        /// Get slot at position.
        /// 0-8 vert
        /// 0-3 hor
        /// 24 slots in total.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        ISlot GetSlot(byte position);
        /// <summary>
        /// Get slot at a horizontal (x) position,
        /// and at vertical (y) position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        ISlot GetSlot(byte x, byte y);

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
    }
}