namespace OQ.MineBot.PluginBase.Pathfinding
{
    public class PathResult
    {
        public PathResultType Result { get; private set; }
        public ICachedPath Path { get; private set; }

        public PathResult(PathResultType result, ICachedPath path) {
            this.Result = result;
            this.Path = path;
        }
    }

    public enum PathResultType
    {
        Found,
        NotFound
    }
}