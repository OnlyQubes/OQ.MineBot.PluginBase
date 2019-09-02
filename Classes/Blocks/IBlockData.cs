using OQ.MineBot.PluginBase.Classes.Materials;
using OQ.MineBot.PluginBase.Classes.Physics.Colliders;

namespace OQ.MineBot.PluginBase.Classes.Blocks
{
    public interface IBlockData
    {
        /// <summary>
        /// Id of the block.
        /// </summary>
        ushort id { get; set; }

        /// <summary>
        /// Material of the block.
        /// </summary>
        IMaterial material { get; set; }

        /// <summary>
        /// Is the block solid (can
        /// be walked on).
        /// </summary>
        Solidity solidity { get; set; }

        /// <summary>
        /// Get the shapes for this
        /// blocks collisions.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        ICollider[] GetCollider(byte metadata);
        /// <summary>
        /// Get the shapes for this
        /// blocks collisions.
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        ICollider[] GetCollider(byte metadata, ILocation location);

        /// <summary>
        /// How hard is this block?
        /// (Used in the calculation of
        /// how much time it will take to
        /// mine this block)
        /// </summary>
        float hardness { get; set; }

        /// <summary>
        /// Minimum material required,
        /// for this block to be mined
        /// efficiently.
        /// </summary>
        CraftableMaterials requiredMaterial { get; set; }
    }

    public enum Solidity
    {
        Solid,
        Fluid,
        Transparent
    }

    public enum CraftableMaterials
    {
        hand = 0, //Tear 0, no item

        wooden = 1,
        stone = 2,
        gold = 3,
        iron = 4,
        diamond = 5,

        shears = 6,
        sword = 7,
    }
}