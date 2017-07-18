namespace OQ.MineBot.PluginBase.Movement.Geometry
{
    public interface IAreaCuboid
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }

        double directionX { get; set; }
        double directionZ { get; set; }

        /// <summary>
        /// Have we reached (and passed)
        /// the start position of this cubod.
        /// </summary>
        bool startReached { get; set; }
    }
}