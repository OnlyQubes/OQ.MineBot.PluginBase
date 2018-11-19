namespace OQ.MineBot.GUI.Protocol.Movement.Maps
{
    public class MapOptions
    {
        /// <summary>
        /// Should the bot ignore slowdown effects.
        /// (Such as eating)
        /// </summary>
        public static bool DefaultNoSlowdown { get; set; } = false;


        /// <summary>
        /// Should the bot not walk
        /// off edges.
        /// </summary>
        public bool EdgeStick { get; set; }

        /// <summary>
        /// Should the bot wait till
        /// it's on ground before switching
        /// to the next geometry object.
        /// </summary>
        public bool PauseOnNext { get; set; } = true;

        /// <summary>
        /// Should the bot look in the direction
        /// it is going?
        /// </summary>
        public bool Look { get; set; } = true;

        /// <summary>
        /// REQUIES Look to be true.
        /// </summary>
        public bool SmoothLook { get; set; } = false;

        /// <summary>
        /// Can the bot sprint.
        /// </summary>
        public bool Sprint { get; set; } = true;

        /// <summary>
        /// Should the bot ignore slowdown effects.
        /// (Such as eating)
        /// </summary>
        public bool NoSlowdown
        {
            get
            {
                if (!_NoSlowdownSet)
                    return DefaultNoSlowdown;
                else
                    return _NoSlowdown;
            }
            set
            {
                _NoSlowdown = value;
                _NoSlowdownSet = true;
            }
        }
        private bool _NoSlowdownSet = false;
        private bool _NoSlowdown = false;

        /// <summary>
        /// Should a sprinting start
        /// packet be sent?
        /// </summary>
        public bool SprintVisuals { get; set; } = true;

        /// <summary>
        /// Can mine through blocks.
        /// </summary>
        public bool Mine { get; set; } = false;
        /// <summary>
        /// Avoid mining into water/lava.
        /// </summary>
        public bool SafeMine { get; set; } = true;

        /// <summary>
        /// Can the player fly?
        /// </summary>
        public bool Fly { get; set; }

        /// <summary>
        /// Should the bot swim
        /// up.
        /// </summary>
        public bool Swim { get; set; } = true;

        /// <summary>
        /// Can the bot climb up.
        /// </summary>
        public bool Climb { get; set; }

        /// <summary>
        /// Detect if we are stuck, and
        /// if we are dispose of the map.
        /// </summary>
        public bool AntiStuck { get; set; } = true;

        /// <summary>
        /// How accurate/big the search should be?
        /// </summary>
        public SearchQuality Quality { get; set; } = SearchQuality.HIGH;

        /// <summary>
        /// Blocks that the bot shouldn't step on.
        /// </summary>
        public ushort[] Unwalkable;

        /// <summary>
        /// Should keep a strict path.
        /// (Keep height always the same, attempt
        /// to do straight lines)
        /// </summary>
        public bool Strict { get; set; }
        /// <summary>
        /// Does not take pathing costs
        /// into the path finding. 
        /// (E.g.: ignores mining vs walking cost)
        /// </summary>
        public bool NoCost { get; set; }

        /// <summary>
        /// EXPERIMENTAL FEATURE!
        /// Allows the bot to segment pathfinding,
        /// meaning it will be able to navigate much longer distances.
        /// </summary>
        public bool Segment { get; set; }
    }

    public enum SearchQuality
    {
        LOWEST = 512,
        LOW = 1024,
        MEDIUM = 2048,
        MEDIUM_EXTENDED = 4096,
        HIGH = 4096*4,
        HIGHEST = 4096*8
    }
}