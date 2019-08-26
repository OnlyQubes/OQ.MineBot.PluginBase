namespace OQ.MineBot.PluginBase.Classes.Entity.Player
{
    /*
     * Entity used to describe OTHER players.
     */

    public interface IPlayerEntity : ILiving
    {
        /// <summary>
        /// Game mode of the player.
        /// </summary>
        Gamemodes gamemode { get; set; }
        /// <summary>
        /// Dimension of the player.
        /// </summary>
        Dimensions dimension { get; set; }

        /// <summary>
        /// Id of the player.
        /// </summary>
        string uuid { get; set; }

        /// <summary>
        /// Metadata of the player.
        /// </summary>
        IEntityMetadata metadata { get; set; }

        /// <summary>
        /// How much health does our
        /// player currently have?
        /// (0 or less is dead)
        /// </summary>
        float health { get; set; }
        /// <summary>
        /// Is the player dead?
        /// </summary>
        bool isDead { get; set; }

        /// <summary>
        /// How much food points 
        /// does the player currently
        /// have.
        /// (0 - startving)
        /// </summary>
        int food { get; set; }
        /// <summary>
        /// Food saturation.
        /// </summary>
        float foodSaturation { get; set; }
        /// <summary>
        /// Is the player currenly
        /// starving?
        /// </summary>
        bool isStarving { get; set; }

        /// <summary>
        /// Is the player currently crouching.
        /// </summary>
        bool isCrouching { get; set; }
        /// <summary>
        /// Is the player currently sprinting.
        /// </summary>
        bool isSprinting { get; }

        /// <summary>
        /// Hotbar selected item index.
        /// </summary>
        short selectedSlot { get; set; }

        /// <summary>
        /// Current level of the player.
        /// </summary>
        int level { get; set; }
        /// <summary>
        /// Total experience of the player.
        /// </summary>
        int totalExperience { get; set; }
    }

    public enum Gamemodes
    {
        survival = 0,
        creative = 1,
        adventure = 2,
        spectator = 3,
    }

    public enum Dimensions
    {
        nether = -1,
        overworld = 0,
        end = 1,
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