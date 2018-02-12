namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnDeath' will be called once the bots
        health is equal or below 0.
        (The method will get called from the main thead,
        therefore if your method 'OnDeath' takes >3ms then it
        should be running on a seperate thread)
    */
    public interface IDeathListener
    {
        void OnDeath();
    }
}