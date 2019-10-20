using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes.Base;
using OQ.MineBot.PluginBase.Classes.Entity.Filter;
using OQ.MineBot.PluginBase.Classes.Entity.Mob;
using OQ.MineBot.PluginBase.Classes.Entity.Objects;
using OQ.MineBot.PluginBase.Classes.Entity.Player;
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
        /// Called once an entity is moved by the server.
        /// (also includes player movements)
        /// </summary>
        event EntityInformationDelegate onEntityMoved;
        /// <summary>
        /// Called once a player is moved by the server.
        /// </summary>
        event EntityInformationDelegate onPlayerMoved;

        IEnumerable<IPlayerEntity> GetBots();
        IPlayerEntity GetClosestBot();
        IPlayerEntity GetClosestBot(IPosition position);
        IPlayerEntity GetClosestBot(ILocation position);
        IPlayerEntity GetClosestBot(double x, double y, double z);

        IEnumerable<IPlayerEntity> GetPlayers(bool includeBots);
        IPlayerEntity GetPlayer(int entityId);
        IPlayerEntity GetPlayer(string name );
        IPlayerEntity GetPlayerByUuid(string uuid);
        IPlayerEntity GetClosestPlayer(bool includeBots = false, Func<IPlayerEntity, bool> optionalValidityCheck = null);
        IPlayerEntity GetClosestPlayer(IPosition position, bool includeBots = false, Func<IPlayerEntity, bool> optionalValidityCheck = null);
        IPlayerEntity GetClosestPlayer(ILocation position, bool includeBots = false, Func<IPlayerEntity, bool> optionalValidityCheck = null);
        IPlayerEntity GetClosestPlayer(double x, double y, double z, bool includeBots = false, Func<IPlayerEntity, bool> optionalValidityCheck = null);

        IEnumerable<ILiving> GetEntities(bool includePlayers = false);
        ILiving GetEntity(int entityId);
        ILiving GetClosestEntity(bool includePlayers = false, Func<ILiving, bool> optionalValidityCheck = null);
        ILiving GetClosestEntity(IPosition position, bool includePlayers = false, Func<ILiving, bool> optionalValidityCheck = null);
        ILiving GetClosestEntity(ILocation position, bool includePlayers = false, Func<ILiving, bool> optionalValidityCheck = null);
        ILiving GetClosestEntity(double x, double y, double z, bool includePlayers = false, Func<ILiving, bool> optionalValidityCheck = null);

        IEnumerable<IMobEntity> GetMobs(MobType type = MobType.All);
        IMobEntity GetClosestMob(MobType type = MobType.All, Func<IMobEntity, bool> optionalValidityCheck = null);
        IMobEntity GetClosestMob(IPosition position, MobType type = MobType.All, Func<IMobEntity, bool> optionalValidityCheck = null);
        IMobEntity GetClosestMob(ILocation position, MobType type = MobType.All, Func<IMobEntity, bool> optionalValidityCheck = null);
        IMobEntity GetClosestMob(double x, double y, double z, MobType type = MobType.All, Func<IMobEntity, bool> optionalValidityCheck = null);

        IEnumerable<IObjectEntity> GetObjects(ObjectTypes type = ObjectTypes.All);
        IEnumerable<IObjectEntity> GetItemStackObjects();
        IObjectEntity GetClosestObject(ObjectTypes type = ObjectTypes.All, Func<IObjectEntity, bool> optionalValidityCheck = null);
        IObjectEntity GetClosestObject(IPosition position, ObjectTypes type = ObjectTypes.All, Func<IObjectEntity, bool> optionalValidityCheck = null);
        IObjectEntity GetClosestObject(ILocation position, ObjectTypes type = ObjectTypes.All, Func<IObjectEntity, bool> optionalValidityCheck = null);
        IObjectEntity GetClosestObject(double x, double y, double z, ObjectTypes type = ObjectTypes.All, Func<IObjectEntity, bool> optionalValidityCheck = null);

        void _AddEntity(ILiving entity);
        void _RemoveEntity(int entityId);
        void _AddPlayerEntity(IPlayerEntity entity);
        void _RemovePlayerEntity(int entityId);
    }

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