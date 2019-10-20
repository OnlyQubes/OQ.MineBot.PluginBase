using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.PluginBase.Utility
{
    public class LocationBlacklistCollection
    {
        private readonly ConcurrentDictionary<ILocation, LocationBlacklistEntry> collection = new ConcurrentDictionary<ILocation, LocationBlacklistEntry>();
        private readonly int blacklistAfterEntries, blacklistAfterUniqueEntries, blacklistTime, blacklistRadius;

        private LocationBlacklistCollection(int blacklistAfterEntries, int blacklistAfterUniqueEntries, int blacklistTime, int blacklistRadius) {
            this.blacklistAfterEntries = blacklistAfterEntries;
            this.blacklistAfterUniqueEntries = blacklistAfterUniqueEntries;
            this.blacklistTime = blacklistTime;
            this.blacklistRadius = blacklistRadius;
        }

        public static LocationBlacklistCollection CreatePerBot(int blacklistAfterEntries = 1, int blacklistTime = int.MaxValue, int blacklistRadius = 1) {
            return new LocationBlacklistCollection(blacklistAfterEntries, 1, blacklistTime, blacklistRadius);
        }
        public static LocationBlacklistCollection CreateGlobal(int blacklistAfterUniqueBotEntries, int blacklistTime = int.MaxValue, int blacklistRadius = 1) {
            return new LocationBlacklistCollection(1, blacklistAfterUniqueBotEntries, blacklistTime, blacklistRadius);
        }
        public static LocationBlacklistCollection CreateGlobal(int blacklistAfterEntries, int blacklistAfterUniqueBotEntries, int blacklistTime = int.MaxValue, int blacklistRadius = 1) {
            return new LocationBlacklistCollection(blacklistAfterEntries, blacklistAfterUniqueBotEntries, blacklistTime, blacklistRadius);
        }

        public bool IsBlocked(IBotContext context, ILocation location) {
            if (blacklistRadius <= 1) return IsBlockedSingle(context, location);
            else return IsBlockedRecursive(context, location);
        }

        private bool IsBlockedRecursive(IBotContext context, ILocation location) {
            for (int x = -blacklistRadius; x < blacklistRadius; x++) {
                for (int z = -blacklistRadius; z < blacklistRadius; z++) {
                    for (int y = -blacklistRadius; y < blacklistRadius; y++) {
                        if (IsBlockedSingle(context, location.Offset(x,y,z))) return true;
                    }
                }
            }

            return false;
        }
        private bool IsBlockedSingle(IBotContext context, ILocation location) {
            if (!collection.TryGetValue(location, out var v)) return false;
            if (v.GetBot(context) >= blacklistAfterEntries) return true;
            if (blacklistAfterUniqueEntries > 1 && v.GetAll(blacklistAfterEntries) >= blacklistAfterUniqueEntries) return true;

            return false;
        }

        public void AddToBlockCounter(IBotContext context, ILocation location) {
            collection.AddOrUpdate(location, location1 => new LocationBlacklistEntry(context, blacklistTime), (location1, entry) => {
                entry.Add(context, blacklistTime);
                return entry;
            });
        }

        public void Remove(ILocation location) {
            collection.TryRemove(location, out _);
        }
        public void Remove(ILocation location, IBotContext context) {
            if (!collection.TryGetValue(location, out var v)) return;
            v.Clear(context);
        }

        public void Clear() {
            collection.Clear();
        }
        public void Clear(IBotContext context) {
            var array = collection.ToArray();
            foreach (var value in array) {
                value.Value.Clear(context);
            }
        }
    }

    class LocationBlacklistEntry
    {
        private readonly ConcurrentDictionary<IBotContext, LocationBlacklistCounter> counters = new ConcurrentDictionary<IBotContext, LocationBlacklistCounter>();

        public LocationBlacklistEntry(IBotContext context, int ms) {
            counters.TryAdd(context, new LocationBlacklistCounter(ms));
        }

        public void Add(IBotContext context, int ms) {
            counters.AddOrUpdate(context, botContext => new LocationBlacklistCounter(ms), (botContext, counter) => {
                counter.Add(ms);
                return counter;
            });
        }

        public int GetBot(IBotContext context) {
            if (!counters.TryGetValue(context, out var v)) return 0;
            return v.Get();
        }
        public int GetAll(int neededCount) {
            var array = counters.ToArray();
            int count = 0;
            foreach (var value in array) {
                if (value.Value.Get() >= neededCount) count++;
            }

            return count;
        }

        public void Clear(IBotContext context) {
            counters.TryRemove(context, out _);
        }
    }

    class LocationBlacklistCounter
    {
        public List<DateTime> expirationTimes = new List<DateTime>();

        public LocationBlacklistCounter(int ms) {
            expirationTimes.Add(DateTime.Now.AddMilliseconds(ms));
        }

        private void RemoveExpiredTimes() {
            for (var i = expirationTimes.Count - 1; i >= 0; i--) {
                if(expirationTimes[i] < DateTime.Now) expirationTimes.RemoveAt(i);
            }
        }

        public int Get() {
            lock (expirationTimes) {
                RemoveExpiredTimes();
                return expirationTimes.Count;
            }
        }

        public void Add(int ms) {
            lock (expirationTimes) {
                RemoveExpiredTimes();
                expirationTimes.Add(DateTime.Now.AddMilliseconds(ms));
            }
        }
    }
}