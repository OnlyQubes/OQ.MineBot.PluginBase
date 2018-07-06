namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class BlockID
    {
        public ushort id;
        public byte metadata;

        public BlockID(ushort id, byte metadata) {
            this.id = id;
            this.metadata = metadata;
        }
    }
}