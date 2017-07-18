namespace OQ.MineBot.PluginBase.Classes
{
    public interface IVector
    {
        double x { get; set; }
        double y { get; set; }
        double z { get; set; }

        /// <summary>
        /// Total distance needed to be moved.
        /// </summary>
        double distance { get; set; }

        void Normalize();
        IVector NormalizeCopy();
        void Combine(IVector other);
        void MultiplyHorizontal(double number);
    }
}