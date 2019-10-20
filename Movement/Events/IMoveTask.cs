using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.PluginBase.Movement.Events
{
    public abstract class IMoveTask
    {
        public Task<MoveResult> Task { get; protected set; }

        public abstract bool IsMoving(); // is the bot currently following/moving along this path.
        public abstract void Stop();


        public abstract Task<bool> SetNewTarget(IPosition target);
        public abstract Task<bool> SetNewTarget(IPosition target, int maxRange);
        public abstract Task<bool> SetNewTarget(IPosition target, int maxRange, int minRange);
        public abstract Task<bool> SetNewTarget(ILocation target);
        public abstract Task<bool> SetNewTarget(double x, double y, double z);
    }
}