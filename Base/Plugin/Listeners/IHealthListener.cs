namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnHealthChanged' will be called once the bots
        health is changed.
        (The method will get called from the main thead,
        therefore if your method 'OnHealthChanged' takes >3ms then it
        should be running on a seperate thread)
    */
    public interface IHealthListener
    {
        void OnHealthChanged(int health);
    }
}