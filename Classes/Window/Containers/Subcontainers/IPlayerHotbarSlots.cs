using System;
using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers
{
    public interface IPlayerHotbarSlots : IWindow
    {
        /// <summary>
        /// Assign a parent container for this class.
        /// This class refferences to the inner container
        /// of the inventory to get the appriopriate slots.
        /// </summary>
        /// <param name="inventory"></param>
        void AssignContainer(IInventory inventory);

        Task<bool> Select(ushort id);
        Task<bool> Select(ushort[] ids);
    }
}