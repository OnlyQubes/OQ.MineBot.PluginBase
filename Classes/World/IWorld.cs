using System;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes.Entity.Lists;
using OQ.MineBot.PluginBase.Classes.Physics.Colliders;
using OQ.MineBot.PluginBase.Pathfinding;
using OQ.MineBot.Protocols.Classes.Base;

namespace OQ.MineBot.PluginBase.Classes.World
{
    public struct ChunkLocation
    {
        public readonly int X;
        public readonly int Z;

        public ChunkLocation(int X, int Z)
        {
            this.X = X;
            this.Z = Z;
        }

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode()
        {
            return this.X * 16 + Z * 47;
        }
    }

    public interface IWorld
    {
        IBlock GetBlock(ILocation location);
        IBlock GetBlock(IPosition position);
        IBlock GetBlock(int x, int y, int z);

        IEnumerable<IBlock> GetBlocks(IEnumerable<ILocation> locations);

        ushort GetBlockRaw(ILocation location);

        ushort GetBlockId(ILocation location);
        ushort GetBlockId(IPosition position);
        ushort GetBlockId(int x, int y, int z);

        byte GetBlockMetadata(ILocation location);
        byte GetBlockMetadata(IPosition position);
        byte GetBlockMetadata(int x, int y, int z);

        IBlock GetLookingAt(); // may be null.

        bool IsWalkable(ILocation location); // Internal legacy requirement, mark as _IsWalkable
    }
}