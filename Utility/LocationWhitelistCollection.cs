using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.PluginBase.Utility
{
    public class LocationWhitelistCollection
    {
        private int range;
        private LocationWhitelistFlags settings;

        private readonly ConcurrentDictionary<IBotContext, ILocation> collection = new ConcurrentDictionary<IBotContext, ILocation>();

        private LocationWhitelistCollection(int range, LocationWhitelistFlags settings) {
            this.range = range;
            this.settings = settings;
        }

        public static LocationWhitelistCollection Create(int range, LocationWhitelistFlags settings = LocationWhitelistFlags.Alive | LocationWhitelistFlags.Connected) {
            return new LocationWhitelistCollection(range, settings);
        }

        public bool IsTaken(IBotContext context, ILocation location) {
            return IsTaken(context, location, true);
        }
        private bool IsTaken(IBotContext context, ILocation location, bool doLock) {
            KeyValuePair<IBotContext, ILocation>[] array = null;
            if (doLock) lock (collection) { array = collection.ToArray(); }
            else array = collection.ToArray();

            foreach (var value in array) {
                if (value.Key != context && value.Value.Distance(location) < range && 
                    (!settings.HasFlag(LocationWhitelistFlags.Connected) || value.Key.Player.State.IsConnected) &&
                    (!settings.HasFlag(LocationWhitelistFlags.Alive) || !value.Key.Player.IsDead())) return true;
                /*
                 * (!settings.HasFlag(LocationWhitelistFlags.Alive) || !value.Key.Player.IsDead()) &&
                    (!settings.HasFlag(LocationWhitelistFlags.Connected) || !value.Key.Player.State.IsConnected)
                 */
            }

            return false;
        }
        public void Take(IBotContext context, ILocation location) {
            lock (collection) {
                collection.AddOrUpdate(context, botContext => location, (botContext, location1) => location);
            }
        }
        public bool TryTake(IBotContext context, ILocation location) {
            lock (collection) {
                if (this.IsTaken(context, location, false)) return false;
                collection.AddOrUpdate(context, botContext => location, (botContext, location1) => location);
            }
            return true;
        }
        public void Release(IBotContext context) {
            lock (collection) {
                collection.TryRemove(context, out _);
            }
        }

        public void Clear() {
            this.collection.Clear();
        }
    }

    [Flags]
    public enum LocationWhitelistFlags
    {
        None = 0,
        Alive = 1,
        Connected = 2
    }
}