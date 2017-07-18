namespace OQ.MineBot.PluginBase.Classes
{
    public interface IPosition
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }

        ILocation ToLocation(float add);

        /// <summary>
        /// Is the current position
        /// closser.
        /// (not given)
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        bool IsCloser(double x, double y, double z, IPosition position);

        /// <summary>
        /// Distance from our position to target.
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        double Distance(IPosition target);
    }
}