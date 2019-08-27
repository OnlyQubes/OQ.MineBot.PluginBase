namespace OQ.MineBot.PluginBase.Classes.Entity.Mob
{
    public abstract class IMobEntity : ILiving
    {
        /// <summary>
        /// Type of the monster entity.
        /// </summary>
        public MobType type { get; set; }

        /// <summary>
        /// Metadata for this monster.
        /// </summary>
        public IEntityMetadata metadata { get; set; }

        /// <summary>
        /// Is this a passive mob.
        /// </summary>
        public abstract bool IsFriendly();
    }

    public enum MobType
    {
        Mob = 48,
        Monster = 49,
        Creeper = 50,
        Skeleton = 51,
        Spider = 52,
        Giant_Zombie = 53,
        Zombie = 54,
        Slime = 55,
        Ghast = 56,
        Zombie_Pigman = 57,
        Enderman = 58,
        Cave_Spider = 59,
        Silverfish = 60,
        Blaze = 61,
        Magma_Cube = 62,
        Ender_Dragon = 63,
        Wither = 64,
        Bat = 65,
        Witch = 66,
        Endermite = 67,
        Guardian = 68,
        Shulker = 69,
        Pig = 90,
        Sheep = 91,
        Cow = 92,
        Chicken = 93,
        Squid = 94,
        Wolf = 95,
        Mooshroom = 96,
        Snowman = 97,
        Ocelot = 98,
        Iron_Golem = 99,
        Horse = 100,
        Rabbit = 101,
        Polar_Bear = 102,
        Villager = 120,
    }
}