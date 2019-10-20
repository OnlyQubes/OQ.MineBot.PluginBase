using OQ.MineBot.PluginBase.Classes.Physics.Colliders;
using OQ.MineBot.PluginBase.Classes.World;

namespace OQ.MineBot.PluginBase.Classes.Blocks
{
    public interface IBlockHolder
    {
        /// <summary>
        /// All known blocks are stored
        /// here by id.
        /// </summary>
        IBlockData[] BlocksData { get; set; }

        /// <summary>
        /// Get block by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IBlockData GetBlock(ushort id);
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
        bool CanBePlacedOn(ushort id);
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

        /// <summary>
        /// Can this block be mined?
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        bool IsMinable(ushort blockId);

        /// <summary>
        /// Checks if the block at the location is safe to mine
        /// (doesn't have any liquids or any other dangers
        /// around it)
        /// </summary>
        /// <param name="location">Location of the block we want
        /// to mine, all 5 (or 6 if isFall) around the block will
        /// be checked if they are dangerous.</param>
        /// <param name="isFall">Are we going to mine this block
        /// and fall down at this blocks location? - Checks if
        /// there are dangerous blocks below and checks if the
        /// gap is supported by our fall level.</param>
        /// <returns>
        /// True - we can mine the block without any dangers.
        /// False - should not mine this block. (might have 
        /// liquids surrounding it)
        /// </returns>
        bool IsSafeToMine(IWorld world, ILocation location, bool isFall = false);
        /// <summary>
        /// Is lava/water or sand/gravel.
        /// </summary>
        /// <param name="getBlockId"></param>
        /// <returns></returns>
        bool IsDanger(ushort getBlockId);

        bool IsBlockSubset(ushort id1, ushort id2);
        bool SimilarBlockProperties(ushort oldid, ushort newid);
    }
}