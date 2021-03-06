﻿using System.Xml;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Base;
using OQ.MineBot.PluginBase.Classes.Entity;
using OQ.MineBot.PluginBase.Classes.Entity.Objects;
using OQ.MineBot.PluginBase.Classes.Entity.Player;

namespace OQ.MineBot.PluginBase
{
    /*
        Events that are based on packets
        should be stored and called here.
        (E.g.: 'OnInventoryChanged' should be a 
        packet that is called once a certain packet
        is received.
        This is so that we could avoid RAW packet
        handling.)
    */
    public interface IPlayerEvents
    {
        /// <summary>
        /// Called once the player logs
        /// in to a server.
        /// </summary>
        event IPlayerDelegates.PlayerDelegate onLoggedIn;
        event IPlayerDelegates.OnEncryptionBegin onEncryptionBegin;
        /// <summary>
        /// Called once the player is
        /// disconencted from the server.
        /// </summary>
        event IPlayerDelegates.PlayerReasonDelegate onDisconnected;
        /// <summary>
        /// Called once the player
        /// joins in game. 
        /// (Isn't actually it spawning
        /// in game, as its still in joining
        /// game phase. Use 'onSpawned' for
        /// the moment that the player is
        /// functional)
        /// </summary>
        event IPlayerDelegates.OnGameJoinedDelegate onGameJoined;
        /// <summary>
        /// Called once the player spawns
        /// the game. After this it can
        /// be controlled.
        /// </summary>
        event IPlayerDelegates.OnSpawnedDelegate onSpawned;

        /// <summary>
        /// Called once a chat message
        /// is received.
        /// </summary>
        event IPlayerDelegates.OnChatDelegate onChat;

        /// <summary>
        /// Called once a health/food update
        /// is received.
        /// </summary>
        event IPlayerDelegates.OnHealthUpdateDelegate onHealthUpdate;
        /// <summary>
        /// Called once the player dies.
        /// </summary>
        event IPlayerDelegates.OnDeathDelegate onDeath;
        /// <summary>
        /// Called once the player starts
        /// startving.
        /// </summary>
        event IPlayerDelegates.OnStartedStartvingDelegate onStartedStarving;

        /// <summary>
        /// Called once a block changes for
        /// this player.
        /// </summary>
        event IPlayerDelegates.OnBlockChangedDelegate onBlockChanged;
        /// <summary>
        /// Called once a chunk is loaded.
        /// </summary>
        event IPlayerDelegates.OnChunlLoadedDelegate onChunkLoaded;

        /// <summary>
        /// Called once our palyer is moved.
        /// </summary>
        event IPlayerDelegates.OnPlayerMovedDelegate onPlayerMoved;

        /// <summary>
        /// Called once the inventory changes.
        /// </summary>
        event IPlayerDelegates.OnInventoryChangedDelegate onInventoryChanged;

        /// <summary>
        /// Called each tick.
        /// </summary>
        event IPlayerDelegates.PlayerDelegate onTick;

        /// <summary>
        /// Called once the sprinting
        /// state changes.
        /// </summary>
        event IPlayerDelegates.OnPlayerSprintUpdateDelegate onSprintingChanged;

        /// <summary>
        /// Called once the world is reloaded.
        /// </summary>
        event IPlayerDelegates.PlayerDelegate onWorldReload;

        /// <summary>
        /// Called once an explosion occurds.
        /// </summary>
        event IPlayerDelegates.OnExplosionDelegate onExplosion;

        /// <summary>
        /// Called once an entity receives an effect.
        /// </summary>
        event IPlayerDelegates.OnEntityEffect onEntityEffectAdded;

        /// <summary>
        /// Called once an object spawns.
        /// </summary>
        event IPlayerDelegates.OnObjectSpawned onObjectSpawned;

        /// <summary>
        /// Called once the server sets
        /// an entities velocity.
        /// </summary>
        event IPlayerDelegates.OnEntityVelocity onEntityVelocity;

        /// <summary>
        /// Called pre player update, allows
        /// to cancel all physics.
        /// </summary>
        event IPlayerDelegates.OnPlayerUpdate onPlayerUpdate;

        /// <summary>
        /// Called when the bot's experience gets changed by the server.
        /// </summary>
        event IPlayerDelegates.OnExperienceChanged onExperienceChanged;

        /// <summary>
        /// Called when the server sends the bot a resource pack url and hash.
        /// </summary>
        event IPlayerDelegates.OnResourcePackReceived onResourcePackReceived;

        /// <summary>
        /// Called once the servers sends an entith attach packet.
        /// (Supported only on 1.8.*)
        /// </summary>
        event IPlayerDelegates.OnEntityAttached onEntityAttached;
    }

    public class IPlayerDelegates
    {
        public delegate void PlayerDelegate(IBotContext context);
        public delegate void PlayerReasonDelegate(IBotContext context, string reason);
        public delegate void OnGameJoinedDelegate(IBotContext context, int entityId, Dimensions dimension, Gamemodes gamemode);
        public delegate void OnEncryptionBegin(IBotContext context, string serverId, byte[] key, byte[] token);
        public delegate void OnSpawnedDelegate(IBotContext context);

        public delegate void OnChatDelegate(IBotContext context, IChat message, byte position);

        public delegate void OnHealthUpdateDelegate(IBotContext context, float health, int food, float foodSaturation);
        public delegate void OnDeathDelegate(IBotContext context);
        public delegate void OnStartedStartvingDelegate(IBotContext context);

        public delegate void OnBlockChangedDelegate(IBotContext context, ILocation location, ushort oldId, ushort newId);
        public delegate void OnChunlLoadedDelegate(IBotContext context, ILocation location);

        public delegate void OnPlayerMovedDelegate(IBotContext context);
        public delegate void OnPlayerSprintUpdateDelegate(IBotContext context, bool isSprinting);

        public delegate void OnInventoryChangedDelegate(IBotContext context, bool changed, bool removed, ushort id, int countDifference, ISlot slot);

        public delegate void OnExplosionDelegate(IBotContext context, float X, float Y, float Z);

        public delegate void OnEntityEffect(ILiving living, Effect effect);

        public delegate void OnObjectSpawned(IWorldObject worldObject, double X, double Y, double Z, byte pitch, byte yaw);
        public delegate void OnEntityVelocity(int entityId, short x, short y, short z);

        public delegate void OnPlayerUpdate(IStopToken cancel);

        public delegate void OnExperienceChanged(int level, int totalExperience);

        public delegate void OnResourcePackReceived(string url, string hash);

        public delegate void OnEntityAttached(int entityId, int vehicleId, bool leash);

        public delegate void OnEntityEvent();

    }
}