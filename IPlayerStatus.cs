﻿using OQ.MineBot.PluginBase.Classes.Entity.Player;
using OQ.MineBot.PluginBase.Classes.Window;
using OQ.MineBot.PluginBase.Classes.Window.Containers;

namespace OQ.MineBot.PluginBase
{
    public abstract class IPlayerStatus
    {
        /// <summary>
        /// Is the player connected
        /// to a server.
        /// </summary>
        public bool LoggedIn { get; protected set; }

        /// <summary>
        /// Has the player spawned and
        /// is he controllable?
        /// </summary>
        public bool Spawned { get; protected set; }

        /// <summary>
        /// Ping to server and back.
        /// </summary>
        public int Ping { get; protected set; }

        /// <summary>
        /// Username of the player.
        /// </summary>
        public string Username { get; protected set; }

        /// <summary>
        /// Uuid of the player.
        /// </summary>
        public string Uuid { get; protected set; }

        /// <summary>
        /// Is the player currently switching worlds/respawning.
        /// (E.g. going from overworld to nether)
        /// (aka Loading world)
        /// </summary>
        public bool SwitchingWorlds { get; protected set; }

        /// <summary>
        /// Is the player currently eating?
        /// </summary>
        public bool Eating { get; protected set; }

        /// <summary>
        /// Currently selected hand.
        /// </summary>
        public int Hand { get; protected set; }
    }
}