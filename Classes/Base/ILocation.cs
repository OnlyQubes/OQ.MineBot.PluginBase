using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Classes
{
    public interface ILocation : IEqualityComparer<ILocation>
    {
        int x { get; set; }
        float y { get; set; }
        int z { get; set; }

        /// <summary>
        /// Calculate total difference
        /// between 2 distances.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        float Distance(ILocation other);
        /// <summary>
        /// Check if 2 locations have
        /// the same values.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool Compare(ILocation other);

        /// <summary>
        /// Convert to byte array.
        /// </summary>
        /// <returns></returns>
        byte[] ToBytes();

        /// <summary>
        /// Converts location to poisition.
        /// </summary>
        /// <returns></returns>
        IPosition ToPosition();

        /// <summary>
        /// Returns a new ilocation with
        /// an offset.
        /// </summary>
        /// <returns></returns>
        ILocation Offset(int x, float y, int z);
    }
}