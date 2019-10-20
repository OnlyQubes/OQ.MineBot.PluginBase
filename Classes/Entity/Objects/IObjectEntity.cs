namespace OQ.MineBot.PluginBase.Classes.Entity.Objects
{
    public abstract class IObjectEntity : IEntity
    {
        // Check Classes.Entity.Objects.List for all possible object classes.
        public IWorldObject Object;
        public ObjectTypes Type;
    }
}