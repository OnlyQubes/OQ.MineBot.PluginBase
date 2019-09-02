using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OQ.MineBot.GUI.Protocol.Movement.Maps;
using OQ.MineBot.PluginBase.Classes.Blocks;
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

        Task<IEnumerable<IBlock>> GetPathableBlocksFrom(ILocation location, uint range, MapOptions mapOptions = null);
        Task<IEnumerable<IBlock>> GetPathableBlocksFrom(IPosition position, uint range, MapOptions mapOptions = null);
        Task<IEnumerable<IBlock>> GetPathableBlocksFrom(int x, int y, int z, uint range, MapOptions mapOptions = null);

        Task<bool> PlaceAt(ILocation location);
        Task<bool> PlaceAt(IPosition position);
        Task<bool> PlaceAt(int x, int y, int z);
        Task<bool> PlaceOn(FaceData faceData);
        Task<bool> PlaceOn(ILocation location,  sbyte face);
        Task<bool> PlaceOn(IPosition position,  sbyte face);
        Task<bool> PlaceOn(int x, int y, int z, sbyte face);

        Task<IDigAction> Dig(FaceData fadeData);
        Task<IDigAction> Dig(ILocation location, sbyte face);
        Task<IDigAction> Dig(ILocation location);
        Task<IDigAction> Dig(IPosition position);
        Task<IDigAction> Dig(int x, int y, int z);

        Task<IBlock[]> FindFrom(ILocation location, int width, int height, ushort id, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock[]> FindFrom(ILocation location, int width, int height, ushort[] ids, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock> FindClosestTo(ILocation location, int width, int height, ushort id, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock> FindClosestTo(ILocation location, int width, int height, ushort[] ids, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock[]> Find(int width, int height, ushort id, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock[]> Find(int width, int height, ushort[] ids, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock> FindClosest(int width, int height, ushort id, Func<IBlock, bool> optionalIsPickable = null);
        Task<IBlock> FindClosest(int width, int height, ushort[] ids, Func<IBlock, bool> optionalIsPickable = null);

        bool IsWalkable(ILocation location); // Internal legacy requirement, mark as _IsWalkable
    }
}