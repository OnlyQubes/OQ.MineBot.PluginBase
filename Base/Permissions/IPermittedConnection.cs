namespace OQ.MineBot.PluginBase.Base.Permissions
{
    public interface IPermittedConnection
    {
        bool Connected { get; }
        string Message { get; } // Used if you get disconnected.
    }
}