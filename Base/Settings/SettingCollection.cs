using System;
using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Base
{
    public class SettingCollection
    {
        private readonly List<IPluginSetting> all = new List<IPluginSetting>(); 
        private readonly Dictionary<string, IPluginSetting> collection = new Dictionary<string, IPluginSetting>();

        public bool HasSettings() {
            return collection.Count > 0;
        }

        public void Add(IPluginSetting setting) {
            collection.Add(setting.name, setting);
            all.Add(setting);
            
            // Check children.
            var parent = setting as IParentSetting;
            if (parent == null) return;

            var data = parent.GetCollection();
            foreach (var entry in data) {
                var entryData = entry.Value.GetCollection();
                foreach (var second in entryData)
                    all.Add(second.Value);
            }
        }

        public IPluginSetting Get(string name) {
            if (collection.ContainsKey(name)) return collection[name];
            throw new KeyNotFoundException("Could not find plugin setting with the name '"+name+"'.");
        }
        public T GetValue<T>(string name) {
            if (collection.ContainsKey(name)) return collection[name].Get<T>();
            throw new KeyNotFoundException("Could not find plugin setting with the name '" + name + "'.");
        }

        public Dictionary<string, IPluginSetting> GetCollection() {
            return collection;
        }

        public IPluginSetting[] GetAll() {
            return all.ToArray();
        }

        public IPluginSetting At(int i) {
            return all[i];
        }
    }
}