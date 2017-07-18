namespace OQ.MineBot.PluginBase.Classes
{
    public interface IFacedLocation
    {
        sbyte face { get; set; }
        ILocation location { get; set; }
    }
}