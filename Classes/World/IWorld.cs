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
        /// <summary>
        /// Is this world shared.
        /// </summary>
        bool isShared { get; set; }

        /// <summary>
        /// All chunks of this world.
        /// </summary>
        Dictionary<ChunkLocation, IChunkColumb> chunks { get; set; }
        
        #region Blocks 

        /// <summary>
        /// Get a block from absoulte
        /// cords.
        /// </summary>
        /// <param name="absoluteX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="absoluteZ"></param>
        /// <returns></returns>
        ushort GetBlock(int absoluteX, int absoluteY, int absoluteZ);
        /// <summary>
        /// Get a block from a chunkcolumb.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="relativeX">Relative 0-16.</param>
        /// <param name="absoluteY">Absolute 0-256.</param>
        /// <param name="relativeZ">Relative 0-16.</param>
        /// <returns></returns>
        ushort GetBlock(IChunkColumb chunk, int relativeX, int absoluteY, int relativeZ);
        /// <summary>
        /// Get a block from a chunk.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="relativeX">Relative 0-16.</param>
        /// <param name="relativeY">Relative 0-16.</param>
        /// <param name="relativeZ">Relative 0-16.</param>
        /// <returns></returns>
        ushort GetBlock(IChunk chunk, int relativeX, int relativeY, int relativeZ);

        /// <summary>
        /// Get the chunk columb
        /// </summary>
        /// <param name="absoluteX"></param>
        /// <param name="absoluteZ"></param>
        /// <returns></returns>
        IChunkColumb GetChunkColumb(int absoluteX, int absoluteZ);

        /// <summary>
        /// Get a block from absoulte
        /// cords.
        /// </summary>
        /// <param name="absoluteX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="absoluteZ"></param>
        /// <returns></returns>
        ushort GetBlockId(int absoluteX, int absoluteY, int absoluteZ);
        /// <summary>
        /// Get a block from absoulte
        /// cords.
        /// </summary>
        ushort GetBlockId(ILocation location);
        /// <summary>
        /// Get a block from a chunkcolumb.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="relativeX">Relative 0-16.</param>
        /// <param name="absoluteY">Absolute 0-256.</param>
        /// <param name="relativeZ">Relative 0-16.</param>
        /// <returns></returns>
        int GetBlockId(IChunkColumb chunk, int relativeX, int absoluteY, int relativeZ);
        /// <summary>
        /// Get a block from a chunk.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="relativeX">Relative 0-16.</param>
        /// <param name="relativeY">Relative 0-16.</param>
        /// <param name="relativeZ">Relative 0-16.</param>
        /// <returns></returns>
        int GetBlockId(IChunk chunk, int relativeX, int relativeY, int relativeZ);

        /// <summary>
        /// Gets all block locations with a certain
        /// id.
        /// ALTERNATIVE: FindAsync
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="startZ"></param>
        /// <param name="radius">Radius that it can check.</param>
        /// <param name="blockID">Id of the blocks that we are sreaching.</param>
        /// <returns></returns>
        ILocation[] GetBlockLocations(double startX, double startY, double startZ, int radius, int yRadius, ushort blockID);
        ILocation[] GetBlockLocations(double startX, double startY, double startZ, int radius, int yRadius, ushort[] blockID);

        /// <summary>
        /// Get a block from absoulte
        /// cords.
        /// </summary>
        /// <param name="absoluteX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="absoluteZ"></param>
        /// <returns></returns>
        int GetBlockMetadata(int absoluteX, int absoluteY, int absoluteZ);
        /// <summary>
        /// Get a block from a chunkcolumb.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="relativeX">Relative 0-16.</param>
        /// <param name="absoluteY">Absolute 0-256.</param>
        /// <param name="relativeZ">Relative 0-16.</param>
        /// <returns></returns>
        int GetBlockMetadata(IChunkColumb chunk, int relativeX, int absoluteY, int relativeZ);
        /// <summary>
        /// Get a block from a chunk.
        /// </summary>
        /// <param name="chunk"></param>
        /// <param name="relativeX">Relative 0-16.</param>
        /// <param name="relativeY">Relative 0-16.</param>
        /// <param name="relativeZ">Relative 0-16.</param>
        /// <returns></returns>
        int GetBlockMetadata(IChunk chunk, int relativeX, int relativeY, int relativeZ);

        /// <summary>
        /// A faster method to get block ids by
        /// location.
        /// (Used in physics.gravity)
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        ushort[] GetBlocks(ILocation[] positions);
        ushort[] GetClosestBelowBlocks(ILocation[] positions, out ILocation[] newLocations, bool solidOnly = false);
        ILocation GetClosestBelowBlock(ILocation   positions, bool solidOnly = false);

        /// <summary>
        /// Sets the block id in the chunk.
        /// </summary>
        /// <param name="absoluteX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="absoluteZ"></param>
        /// <param name="blockData"></param>
        /// <returns>Returns the old id.</returns>
        ushort SetBlock(double absoluteX, double absoluteY, double absoluteZ, ushort blockData);
        /// <summary>
        /// Sets the block id in the chunk.
        /// </summary>
        /// <param name="chunkX"></param>
        /// <param name="chunkZ"></param>
        /// <param name="relativeX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="relativeZ"></param>
        /// <param name="blockData"></param>
        /// <returns>Returns the old id.</returns>
        ushort SetBlock(int chunkX, int chunkZ, byte relativeX, byte absoluteY, byte relativeZ, ushort blockData);
        /// <summary>
        /// Sets the block id in the chunk.
        /// </summary>
        /// <param name="columb"></param>
        /// <param name="relativeX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="relativeZ"></param>
        /// <param name="blockData"></param>
        /// <returns>Returns the old id.</returns>
        ushort SetBlock(IChunkColumb columb, byte relativeX, byte absoluteY, byte relativeZ, ushort blockData);
        /// <summary>
        /// Sets the ids of the blocks in the chunk.
        /// (All arrays are expected to be the same
        /// size, else the application will crash)
        /// </summary>
        /// <param name="chunkX"></param>
        /// <param name="chunkZ"></param>
        /// <param name="relativeX"></param>
        /// <param name="absoluteY"></param>
        /// <param name="relativeZ"></param>
        /// <param name="blockData"></param>
        /// <returns>Returns the old id.</returns>
        ushort[] SetBlocks(int chunkX, int chunkZ, byte[] relativeX, byte[] absoluteY, byte[] relativeZ, ushort[] blockData);

        #endregion

        #region Pathfinding

        /// <summary>
        /// Get 4 neighbouring nodes.
        /// (Returns only if walkable)
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        IPathNode[] GetNeighbours(IPathNode parent, ILocation target, int steps);

        #endregion

        /// <summary>
        /// Unloads all of the chunks.
        /// </summary>
        void Unload(IBotContext context);
        /// <summary>
        /// Unloads all types of chunks,
        /// even if it is a shared world.
        /// </summary>
        void ForceUnload();

        /// <summary>
        /// Adds a chunk columb
        /// to the world.
        /// </summary>
        /// <param name="columb"></param>
        void AddColumb(IChunkColumb columb);
        /// <summary>
        /// Adds chunk columbs
        /// to the world.
        /// </summary>
        /// <param name="columb"></param>
        void AddColumbs(IChunkColumb[] columb);
        /// <summary>
        /// Check if we have a columb
        /// at x/z/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        bool HasColumb(int x, int z);

        /// <summary>
        /// Adds a chunk to a
        /// columb.
        /// </summary>
        /// <param name="chunk"></param>
        void AddChunk(IChunk chunk, int x, int z);
        /// <summary>
        /// Adds chunks to columbs.
        /// </summary>
        /// <param name="chunk"></param>
        void AddChunks(IChunk[] chunk, int x, int z);
        
        /// <summary>
        /// Unloads a columb
        /// of chunks.
        /// </summary>
        void UnloadColumb(int x, int z);
        /// <summary>
        /// Unloads a chunk.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y">Local Y (0-15)</param>
        /// <param name="z"></param>
        void UnloadChunk(int x, int y, int z);

        /// <summary>
        /// Checks if a block is visible
        /// from a location.
        /// </summary>
        /// <param name="our"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        bool IsVisible(IPosition our, ILocation target);
        /// <summary>
        /// Checks if the path is jumpable.
        /// (has blocks above or not)
        /// </summary>
        /// <param name="our"></param>
        /// <param name="target"></param>
        /// <returns>Can the blocks be jumped?</returns>
        bool IsValidAbove(IPosition our, ILocation target);
        /// <summary>
        /// Can this block be jumped to when
        /// moving diagonaly?
        /// </summary>
        /// <param name="position"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        bool DiagonalReach(ILocation position, ILocation location);

        /// <summary>
        /// Checks if the block can be
        /// walked on.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="location">target</param>
        /// <param name="jumpRequired">Should the result
        /// take jumping into consideration</param>
        /// <param name="free">Is there enough space (2 blocks)
        /// above the block</param>
        /// <param name="cost"></param>
        /// <returns></returns>
        bool IsWalkable(ILocation current, ILocation location, bool jumpRequired, out bool free, out int cost);
        /// <summary>
        /// Does not check if the blocks above the floor
        /// are valid for movement.
        /// </summary>
        bool IsWalkableFloor(ILocation current, ILocation location, out int cost);
        bool IsWalkable(ILocation location);

        /// <summary>
        /// Is the block in range of the player.
        /// </summary>
        /// <returns></returns>
        bool InRange(IPosition player, ILocation target);

        /// <summary>
        /// Get colliders of a block at location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        ICollider[] GetBlockCollider(ILocation location);

        /// <summary>
        /// Find the closest location with
        /// any of the specified ids.
        /// (On the same Y level)
        /// </summary>
        /// <param name="myLocation">Beginning location.</param>
        /// <param name="ids"></param>
        ILocation FindHorizontal(ILocation myLocation, ushort[] ids);

        /// <summary>
        /// Searches for the specified blocks in the provided area.
        /// Alternative for 'GetBlockLocations'.
        /// </summary>
        /// <param name="width">Width of search. (lenght and width)</param>
        /// <param name="height">Height of search. (up and down)</param>
        /// <param name="id"></param>
        /// <param name="callback">Call backwith result once done. (empty array if not found)</param>
        void FindAsync(IBotContext context, ILocation location, int width, int height, ushort id, Action<ILocation[]> callback);
        void FindAsync(IBotContext context, ILocation location, int width, int height, ushort[] id, Action<ILocation[]> callback);
        /// <param name="isValid">Function used to check if the block is valid or should
        /// we check further. If invalid return false.</param>
        /// <param name="callback">NULL location if not found.</param>
        void FindFirstAsync(IBotContext context, ILocation location, int width, int height, ushort[] ids, Func<ILocation, bool> isValid, Action<ILocation> callback);

        /// <summary>
        /// Is the player standing on this block.
        /// </summary>
        bool IsStandingOn(ILocation location, IPosition player);

    }
}