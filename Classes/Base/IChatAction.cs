namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class IChatAction
    {
        public string action;
        public string value;

        public IChatAction(string action, string value) {
            this.action = action;
            this.value = value;
        }
    }
}