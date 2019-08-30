using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnHungerChanged' will be called once the bots
        health is changed.
    */
    public interface IHungerListener
    {
        Task OnHungerChanged();
    }
}