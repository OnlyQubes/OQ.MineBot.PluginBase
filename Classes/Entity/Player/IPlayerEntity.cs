namespace OQ.MineBot.PluginBase.Classes.Entity.Player
{
    /*
     * Entity used to describe OTHER players.
     */

    public abstract class IPlayerEntity : ILiving
    {
        /// <summary>
        /// Metadata of the player.
        /// </summary>
        public IEntityMetadata metadata { get; set; }

        public abstract bool IsBot();
        public abstract string GetName();
        public abstract string GetUuid();

        public abstract bool IsCrouched();
        public abstract bool IsSprinting();
        public abstract bool IsSwimming();
    }

    public enum Directions
    {
        South = 0,
        West = 90,
        North = 180,
        East = -90,

        Up = 1,
        Down = 2
    }
}