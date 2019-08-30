using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnDeath' will be called once the bots
        health is equal or below 0.
    */
    public interface IDeathListener
    {
        Task OnDeath();
    }
}