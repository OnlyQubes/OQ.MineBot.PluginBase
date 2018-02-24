namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        The method 'OnHungerChanged' will be called once the bots
        health is changed.
        (The method will get called from the main thead,
        therefore if your method 'OnHungerChanged' takes >3ms then it
        should be running on a seperate thread)
    */
    public interface IHungerListener
    {
        void OnHungerChanged(int hunger);
    }
}