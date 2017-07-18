using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Window;

namespace OQ.MineBot.PluginBase.Pathfinding.Sub
{
    public interface IChestMap
    {
        /// <summary>
        /// Finds all chest near the player.
        /// </summary>
        void UpdateChestList(IPlayer player);

        /// <summary>
        /// Attempts to find/path to/open a
        /// free chest and open it.
        /// </summary>
        /// <returns>True if found empty chest 
        /// and opened it, else false</returns>
        IWindow Open(IPlayer player, IStopToken token);
    }
}