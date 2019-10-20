using OQ.MineBot.PluginBase.Classes.Entity;

namespace OQ.MineBot.PluginBase.Classes
{
    public abstract class Living : ILiving
    {
        public void _InvokeOnMoved() { this.InvokeOnMoved(); }
        public void _InvokeOnDeath() { this.InvokeOnDeath(); }
    }
}