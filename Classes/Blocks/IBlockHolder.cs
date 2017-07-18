using OQ.MineBot.PluginBase.Classes.Physics.Colliders;

namespace OQ.MineBot.PluginBase.Classes.Blocks
{
    public interface IBlockHolder
    {
        /// <summary>
        /// All known blocks are stored
        /// here by id.
        /// </summary>
        IBlock[] blocks { get; set; }

        /// <summary>
        /// Get block by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IBlock GetBlock(ushort id);
        /// <summary>
        /// Get block colliders
        /// by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ICollider[] GetColliders(ushort id, byte metadata = 0);
        /// <summary>
        /// Get the top of the collider.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        float GetColliderTop(ushort id, byte metadata = 0);
        /// <summary>
        /// Return true if the block is solid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsSolid(ushort id);
        /// <summary>
        /// Return true if the block is liquid.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsLiquid(ushort id);
        /// <summary>
        /// How harmful is the block.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int HarmLevel(ushort id);
        /// <summary>
        /// Is the block climable.
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        bool IsLadder(ushort blockId);
    }
}