using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnTick' will be called each
        tick (~50ms) until the bot gets disconnected
        or the plugin is stopped.
        (The method will get called from the main thead,
        therefore if your method 'OnTick' takes >3ms then it
        should be running on a seperate thread)
    */
    public interface ITickListener {
        Task OnTick();
    }
}