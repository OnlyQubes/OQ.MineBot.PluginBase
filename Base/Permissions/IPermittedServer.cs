namespace OQ.MineBot.PluginBase.Base.Permissions
{
    public interface IPermittedServer
    {
        string Address { get; }
        ushort Port { get; }

        /// <summary>
        /// This can be used to switch
        /// servers before the bot joins.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        void Set(string address, ushort port);
    }
}