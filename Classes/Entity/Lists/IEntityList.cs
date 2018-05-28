using System.Collections.Concurrent;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes.Base;
using OQ.MineBot.PluginBase.Classes.Entity.Filter;
using OQ.MineBot.PluginBase.Classes.Physics;

namespace OQ.MineBot.PluginBase.Classes.Entity.Lists
{
    public interface IEntityList
    {
        /// <summary>
        /// Called once an entity is added.
        /// </summary>
        event EntityDelegate onEntityAdded;
        /// <summary>
        /// Called once an entity is removed.
        /// </summary>
        event EntityDelegate onEntityRemoved;
        /// <summary>
        /// Called once an entity is moved by
        /// the server.
        /// (also includes player movements)
        /// </summary>
        event EntityInformationDelegate onEntityMove;
        /// <summary>
        /// Called once a player is moved by
        /// the srever.
        /// </summary>
        event EntityInformationDelegate onPlayerMove;
        /// <summary>
        /// Called once a name is added.
        /// </summary>
        event NameDelegate onNameAdded;

        /// <summary>
        /// All entities that we receive from
        /// the server should be stored here.
        /// (E.g.: other players, mobs)
        /// </summary>
        ConcurrentDictionary<int, ILiving> entityList { get; set; }

        /// <summary>
        /// A shared list (shared refferences with 
        /// entityList) of all players that we receive.
        /// </summary>
        ConcurrentDictionary<int, ILiving> playerList { get; set; }

        /// <summary>
        /// A list of all the uuids and names of
        /// the players. (TAB Menu)
        /// 
        /// String - Uuid
        /// UUID   - Uuid and name
        /// </summary>
        ConcurrentDictionary<string, UUID> uuidList { get; set; }

            /// <summary>
        /// Get an entity instance by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ILiving GetEntity(int id);
        /// <summary>
        /// Get a player instance by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ILiving GetPlayer(int id);

        /// <summary>
        /// Add an entity to our 
        /// world entities.
        /// (If entity with same id already
        /// exists, this, new entity overrides it)
        /// </summary>
        /// <param name="entity"></param>
        void AddEntity(ILiving entity);

        /// <summary>
        /// Remove an entity by its id.
        /// </summary>
        /// <param name="id"></param>
        void RemoveEntity(int id);
        /// <summary>
        /// Remove an array of entities.
        /// </summary>
        /// <param name="ids"></param>
        void RemoveEntity(int[] ids);
        /// <summary>
        /// Remove this entity.
        /// </summary>
        /// <param name="entity"></param>
        void RemoveEntity(ILiving entity);

        /// <summary>
        /// Removes all entities.
        /// </summary>
        void RemoveAllEntities();

        /// <summary>
        /// Set the entities position and rotation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="yaw"></param>
        /// <param name="ptich"></param>
        void SetPosition(int id, double x, double y, double z, byte yaw, byte ptich);
        /// <summary>
        /// Add the x/y/z to the current
        /// entities position.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        void RelativeMove(int id, double x, double y, double z);
        /// <summary>
        /// Set the entities rotation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="yaw"></param>
        /// <param name="pitch"></param>
        void HeadRotate(int id, byte yaw, byte pitch);
        /// <summary>
        /// Relative move and rotate the
        /// entities head.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="yaw"></param>
        /// <param name="pitch"></param>
        void RelativeMoveAndRotate(int id, double x, double y, double z, byte yaw, byte pitch);

        /// <summary>
        /// Sets an entities metadata to the
        /// given metadata.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="metadata"></param>
        void SetMetadata(int id, IEntityMetadata metadata);

        /// <summary>
        /// Finds the closest entity to
        /// the given x/y/z.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        ILiving FindClosest(double x, double y, double z);
        /// <summary>
        /// Finds the closest mob to
        /// the given x/y/z.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        ILiving FindClosestMob(double x, double y, double z);
        /// <summary>
        /// Finds the closest player to
        /// the given x/y/z.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        ILiving FindClosestPlayer(double x, double y, double z);

        /// <summary>
        /// Finds the closest valid
        /// target near our player.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        ILiving FindClosestTarget(ILocation player, TargetFilter filter);

        /// <summary>
        /// Add the uuid names.
        /// </summary>
        /// <param name="players"></param>
        void AddNames(UUID[] players);
        /// <summary>
        /// Remove the uuid names.
        /// </summary>
        /// <param name="players"></param>
        void RemoveNames(UUID[] players);

        /// <summary>
        /// Atempts to get a uuid by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        UUID FindUuidByName(string name);
        /// <summary>
        /// Atempts to get a name by uuid.
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        UUID FindNameByUuid(string uuid);

        /// <summary>
        /// Gets a random user from the tab list.
        /// </summary>
        /// <returns></returns>
        string RandomName();

        /// <summary>
        /// Does the uuid belong to a bot.
        /// </summary>
        bool IsBot(string uuid);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="token">This event can be canceled using this token.</param>
    public delegate void EntityDelegate(IEntity entity, EventCancelToken token);
    public delegate void EntityInformationDelegate(IEntity entity);
    public delegate void NameDelegate(UUID uuid);

    public static class Targeter
    {
        /// <summary>
        /// Uuids that are excluded from closest targeting.
        /// </summary>
        public static HashSet<string> IgnoreList { get; set; } = new HashSet<string>();

        /// <summary>
        /// The distance that we can still hit
        /// the other player at.
        /// </summary>
        public static double ReachDistance = 4;

        /// <summary>
        /// What filter should be used by default.
        /// </summary>
        public static TargetFilter DefaultFilter { get; set; } = new TargetFilter()
        {
            AttackInvisible = true,
            MaxDistance = -1,
            Ticks = -1,
            Reach = true
        };
    }
}