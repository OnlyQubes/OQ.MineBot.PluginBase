using System;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerEquipmentSlots : ISearchableContainer
    {
        /// <summary>
        /// Assign a parent container for this class.
        /// This class refferences to the inner container
        /// of the inventory to get the appriopriate slots.
        /// </summary>
        /// <param name="inventory"></param>
        void AssignContainer(IInventory inventory);

        /// <summary>
        /// Get the helmet of the player. 
        /// (must have an assigned inventory)
        /// </summary>
        /// <returns></returns>
        ISlot GetHelmet();
        /// <summary>
        /// Get the chest of the player. 
        /// (must have an assigned inventory)
        /// </summary>
        /// <returns></returns>
        ISlot GetChest();
        /// <summary>
        /// Get the pants of the player. 
        /// (must have an assigned inventory)
        /// </summary>
        /// <returns></returns>
        ISlot GetPants();
        /// <summary>
        /// Get the shoes of the player. 
        /// (must have an assigned inventory)
        /// </summary>
        /// <returns></returns>
        ISlot GetBoots();
        /// <summary>
        /// Get offhand item.
        /// (Only for 1.10+)
        /// </summary>
        /// <returns></returns>
        ISlot GetOffhand();
        /// <summary>
        /// Gets an item at the equipment slot.
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        ISlot Get(EquipmentSlots slot);

        /// <summary>
        /// Drops a single item from the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the action id.</returns>
        short DropItem(EquipmentSlots index);
        /// <summary>
        /// Drops a single item from the window and
        /// does a callback with the success state.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        /// <returns>Returns the action id.</returns>
        short DropItemAsync(EquipmentSlots index, Action<bool> callback);
        /// <summary>
        /// Drops a full stack from the window.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the action id.</returns>
        short DropItemStack(EquipmentSlots index);
        /// <summary>
        /// Drops a full stack from the window and
        /// does a callback with the success state.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="callback"></param>
        /// <returns>Returns the action id.</returns>
        short DropItemStackAsync(EquipmentSlots index, Action<bool> callback);

        /// <summary>
        /// Attempt to dequip an armor peace.
        /// Only works if you have free inventory
        /// or no armor is equiped.    
        /// </summary>
        /// <returns>Returns the action id.</returns>
        short AttemptDequip(EquipmentSlots slot, Action<bool> callback = null);
        /// <summary>
        /// Attempts to equip an armor piece.
        /// This won't work and will corrupt inventory
        /// if the slot is badly assigned for this item.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="slot"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        short AttemptEquipt(int index, EquipmentSlots slot, Action<bool> callback = null);
    }

    public enum EquipmentSlots
    {
        Head = 5,
        Chest = 6,
        Pants = 7,
        Boots = 8
    }
}