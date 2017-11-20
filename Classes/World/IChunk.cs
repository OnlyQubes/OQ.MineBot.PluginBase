namespace OQ.MineBot.PluginBase.Classes.World
{
    public interface IChunk
    {
        /// <summary>
        /// Where is this chunk in the
        /// columb.
        /// </summary>
        byte Y { get; }

        /// <summary>
        /// All blocks of this chunk
        /// represented in X/Z.
        /// </summary>
        ushort[] blocks { get; }//ushort[,,] blocks { get; }

        /// <summary>
        /// Unloads the chunk.
        /// </summary>
        void Unload();

        ushort GetBlock(int x, int y, int z);
        void SetBlock(int x, int y, int z, ushort block);
    }
}