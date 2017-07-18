using System;

namespace OQ.MineBot.PluginBase.Classes.Physics.Colliders
{
    public interface ICollider : ICloneable
    {
        float x { get; set; }
        float y { get; set; }
        float z { get; set; }

        float widthx { get; set; }
        float widthz { get; set; }
        float height { get; set; }

        float offsetX { get; set; }
        float offsetY { get; set; }
        float offsetZ { get; set; }

        int blockId { get; set; }

        /// <summary>
        /// Is this collider colliding
        /// with another collider.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="inner">If true then collisions
        /// are calculated with `>=` else calculated
        /// with `>`.</param>
        /// <returns></returns>
        bool IsColliding(ICollider other, bool inner = false);
        /// <summary>
        /// Checks if we are colliding
        /// with the block.
        /// </summary>
        /// <param name="other"></param>
        /// <param name="inner">If true then collisions
        /// are calculated with `>=` else calculated
        /// with `>`.</param>
        /// <returns>The collider we hit</returns>
        ICollider IsColliding(ICollider[] other, bool inner);

        /// <summary>
        /// Update the current position
        /// of the collider.
        /// (Should be used when passing
        /// this as parameter for collision)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        ICollider Update(float x, float y, float z);
        /// <summary>
        /// Update the current position
        /// of the collider.
        /// (Should be used when passing
        /// this as parameter for collision)
        /// </summary>
        ICollider Update(ILocation location);
        /// <summary>
        /// Update the current position
        /// of the collider.
        /// (Should be used when passing
        /// this as parameter for collision)
        /// </summary>
        ICollider Update(IVector velocity, IPosition position);
    }
}