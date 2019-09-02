namespace OQ.MineBot.PluginBase.Classes.World
{
    public class FaceData
    {
        public ILocation BlockLocation;
        public IPosition LookPosition ;
        public sbyte     Face;

        public FaceData(ILocation blockLocation, IPosition lookPosition, sbyte face) {
            this.BlockLocation = blockLocation;
            this.LookPosition = lookPosition;
            this.Face = face;
        }
    }
}