namespace OQ.MineBot.PluginBase.Classes.Entity.Player
{
    /*
     * Entity used to describe OTHER players.
     */

    public abstract class IPlayerEntity : ILiving
    {
        /// <summary>
        /// Id of the player.
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// Metadata of the player.
        /// </summary>
        public IEntityMetadata metadata { get; set; }

        /// <summary>
        /// Is the player currently crouching.
        /// </summary>
        public bool isCrouching { get; set; }
        /// <summary>
        /// Is the player currently sprinting.
        /// </summary>
        public abstract bool isSprinting { get; }
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