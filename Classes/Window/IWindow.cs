using System;
using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Classes.Window
{
    public interface IWindow
    {
        /// <summary>
        /// Id of this window.
        /// </summary>
        int id { get; set; }

        /// <summary>
        /// The window type to use for display.
        /// </summary>
        string windowType { get; set; }
        /// <summary>
        /// The title of the window.
        /// </summary>
        string windowTitle { get; set; }

        /// <summary>
        /// Number of slots in the window (excluding the number of slots in the player inventory)
        /// </summary>
        byte slotCount { get; set; }
        /// <summary>
        /// (OPTIONAL)
        /// EntityHorse's EID. Only sent when Window Type is “EntityHorse”.
        /// </summary>
        int entityId { get; set; }
        
        /// <summary>
        /// Current action id.
        /// </summary>
        short m_actionId { get; set; }

        /// <summary>
        /// Each move on the inventory should be
        /// confirmed by the server, these confirmations
        /// are awaited here.
        /// </summary>
        Dictionary<short, Action<bool>> confirmationCallbacks { get; set; }

        /// <summary>
        /// Get a slot at the slot
        /// position (id).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ISlot GetAt(int id);

        /// <summary>
        /// Get slots that are not empty.
        /// </summary>
        /// <returns></returns>
        short[] GetNotEmpty();

        /// <summary>
        /// Set an item (slot) to a
        /// slot at the position. (index)
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="index"></param>
        void SetAt(ISlot slot, int index);

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
        /// Called once a confirmation is reiceved
        /// to confirm a window action.
        /// </summary>
        /// <param name="actionId"></param>
        void ReceivedConfirmation(short actionId, bool success);

        /// <summary>
        /// Attempts to retrieve a slot position
        /// that is currently not occupied.
        /// </summary>
        /// <returns></returns>
        short FindFreeSlot();

        /// <summary>
        /// Shift clicks an item.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="equipmentSlot">Can this item be equiped, aka can
        /// this go to the armor slot? If it can then the slot that it can
        /// go should be specified.</param>
        /// <returns></returns>
        short ShiftClickItem(int index, Action<bool> callback, short equipmentSlot = -1);

        /// <summary>
        /// Performs a keypad (1-9 buttons) click
        /// on the inventory.
        /// The keypad button is "hotbarIndex".
        /// Mouse hovering point is "inventoryIndex".
        /// </summary>
        /// <param name="hotbarIndex">0-8.</param>
        /// <param name="inventoryIndex"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        short ClickHotbarShortcut(short hotbarIndex, short inventoryIndex, Action<bool> callback);
    }
}