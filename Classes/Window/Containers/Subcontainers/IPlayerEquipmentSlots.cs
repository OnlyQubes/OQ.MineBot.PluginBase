using System;
using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerEquipmentSlots : IWindow
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
        ISlot GetChestplate();
        /// <summary>
        /// Get the pants of the player. 
        /// (must have an assigned inventory)
        /// </summary>
        /// <returns></returns>
        ISlot GetLeggings();
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
        /// Attempt to dequip an armor peace.
        /// Only works if you have free inventory
        /// or no armor is equiped.    
        /// </summary>
        Task<bool> AttemptUnequip(EquipmentSlots slot);
        /// <summary>
        /// Attempts to equip an armor piece.
        /// This won't work and will corrupt inventory
        /// if the slot is badly assigned for this item.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        Task<bool> AttemptEquip(int index);
    }

    public enum EquipmentSlots
    {
        Head = 5,
        Chest = 6,
        Pants = 7,
        Boots = 8
    }
}