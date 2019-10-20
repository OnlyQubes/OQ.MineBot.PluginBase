using OQ.MineBot.PluginBase.Pathfinding;

namespace OQ.MineBot.PluginBase.Movement.Events
{
    public class MoveResult
    {
        public MoveResultType Result { get; private set; }
        public ICachedPath Path { get; private set; }

        public MoveResult(MoveResultType result, ICachedPath path) {
            this.Result = result;
            this.Path = path;
        }
    }

    public enum MoveResultType
    {
        PathNotFound,
        Cancelled,
        Completed,
        Stuck
    }
}