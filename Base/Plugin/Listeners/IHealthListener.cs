using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnHealthChanged' will be called once the bots
        health is changed.
    */
    public interface IHealthListener
    {
        Task OnHealthChanged();
    }
}