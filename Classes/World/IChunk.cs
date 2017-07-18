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
        ushort[,,] blocks { get; }

        /// <summary>
        /// Unloads the chunk.
        /// </summary>
        void Unload();
    }
}