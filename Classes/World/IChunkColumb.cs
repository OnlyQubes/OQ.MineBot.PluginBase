namespace OQ.MineBot.PluginBase.Classes.World
{
    public interface IChunkColumb
    {

        /// <summary>
        /// On what X position
        /// is this chunk columb
        /// on.
        /// </summary>
        int X { get; }
        /// <summary>
        /// On what Z position
        /// is this chunk columb
        /// on.
        /// </summary>
        int Z { get; }

        /// <summary>
        /// All chunks of this
        /// columb.
        /// </summary>
        IChunk[] chunks { get; set; }

        /// <summary>
        /// Was this columb loaded?
        /// </summary>
        bool loaded { get; set; }

        /// <summary>
        /// Unloads all of its chunks.
        /// </summary>
        void Unload();

        /// <summary>
        /// Adds chunks to this columb.
        /// </summary>
        /// <param name="chunks"></param>
        void AddChunks(IChunk[] chunks);

        /// <summary>
        /// Gets the hashcode of the
        /// columb.
        /// </summary>
        /// <returns></returns>
        ulong GetHash();
    }
}