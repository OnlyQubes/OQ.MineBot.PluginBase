using System;
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
        float DistanceHorizontal(ILocation other);
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
        IPosition ToPosition(double addY = Double.NaN);

        /// <summary>
        /// Returns a new location with
        /// an offset.
        /// </summary>
        /// <returns></returns>
        ILocation Offset(int x, float y, int z);
        /// <summary>
        /// Returns a new location with
        /// a height offset.
        /// </summary>
        /// <returns></returns>
        ILocation Offset(float y);
        /// <summary>
        /// Returns a new location with
        /// a height offset.
        /// </summary>
        /// <returns></returns>
        ILocation Offset(ILocation y);

        ILocation Multiply(int mult);
    }
}