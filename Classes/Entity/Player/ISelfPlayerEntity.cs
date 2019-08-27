namespace OQ.MineBot.PluginBase.Classes.Entity.Player
{
    public abstract class ISelfPlayerEntity : IPlayerEntity
    {
        /// <summary>
        /// Game mode of the player.
        /// </summary>
        public Gamemodes gamemode { get; set; }
        /// <summary>
        /// Dimension of the player.
        /// </summary>
        public Dimensions dimension { get; set; }

        /// <summary>
        /// How much health does our
        /// player currently have?
        /// (0 or less is dead)
        /// </summary>
        public float health { get; set; }
        /// <summary>
        /// Is the player dead?
        /// </summary>
        public bool isDead { get; set; }

        /// <summary>
        /// How much food points 
        /// does the player currently
        /// have.
        /// (0 - startving)
        /// </summary>
        public int food { get; set; }
        /// <summary>
        /// Food saturation.
        /// </summary>
        public float foodSaturation { get; set; }
        /// <summary>
        /// Is the player currenly
        /// starving?
        /// </summary>
        public bool isStarving { get; set; }

        /// <summary>
        /// Current level of the player.
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// Total experience of the player.
        /// </summary>
        public int totalExperience { get; set; }

        /// <summary>
        /// Hotbar selected item index.
        /// </summary>
        public short selectedSlot { get; set; }
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
}