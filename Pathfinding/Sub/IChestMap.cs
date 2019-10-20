using System;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Window;

namespace OQ.MineBot.PluginBase.Pathfinding.Sub
{
    public interface IChestMap
    {
        /// <summary>
        /// Finds all chest near the player.
        /// </summary>
        Task UpdateChestList();

        /// <summary>
        /// Attempts to find/path to/open a
        /// free chest and open it.
        /// </summary>
        /// <returns>True if found empty chest 
        /// and opened it, else false</returns>
        Task<IWindow> Open(ChestStatus status);
        Task<IWindow> Open(IStopToken token, ChestStatus status);
    }

    public enum ChestStatus
    {
        Empty,
        Full,
        NotFull,
        Misc,
    }
}