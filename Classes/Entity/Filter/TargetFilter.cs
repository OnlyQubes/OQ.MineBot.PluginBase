namespace OQ.MineBot.PluginBase.Classes.Entity.Filter
{
    public class TargetFilter
    {
        /// <summary>
        /// Can friendly players get hit?
        /// </summary>
        public bool AttackFriendly { get; set; }
        
        /// <summary>
        /// How many ticks should have passed
        /// before we can attack the entity.
        /// </summary>
        public int Ticks { get; set; }

        /// <summary>
        /// Can invisible players get hit.
        /// </summary>
        public bool AttackInvisible { get; set; }

        /// <summary>
        /// Must the target have armour equiped
        /// for us to be able to attack it.
        /// </summary>
        public bool ArmourEquiped { get; set; }

        /// <summary>
        /// If the player hasn't moved yet
        /// then we shouldn't target it.
        /// </summary>
        public bool Moved { get; set; }

        /// <summary>
        /// Can we pick the target only if
        /// it's withing reach range.
        /// </summary>
        public bool Reach { get; set; }

        /// <summary>
        /// What's the max disatance from which
        /// the player can still be targeted.
        /// </summary>
        public double MaxDistance { get; set; }
    }
}