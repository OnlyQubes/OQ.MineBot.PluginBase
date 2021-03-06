﻿using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerOffhandSlot : IWindow
    {
        /// <summary>
        /// Assign a parent container for this class.
        /// This class refferences to the inner container
        /// of the inventory to get the appriopriate slots.
        /// </summary>
        /// <param name="inventory"></param>
        void AssignContainer(IInventory inventory);

        ISlot GetItem();
        Task<bool> RemoveItem();
    }
}