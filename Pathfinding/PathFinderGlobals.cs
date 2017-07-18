namespace OQ.MineBot.PluginBase.Pathfinding
{
    public static class PathFinderGlobals
    {
        /// <summary>
        /// How muchs blocks can the player fall
        /// for the path to be still valid.
        /// </summary>
        public static int maxFallDistance = 3;
        /// <summary>
        /// How muchs blocks a bove a block need
        /// to be free to be considered a free path.
        /// </summary>
        public const int freeBlocksAbove = 2;
        /// <summary>
        /// How tall a block can be for our
        /// player to be able to jump on.
        /// </summary>
        public const int jumpHeight = 1;
    }
}