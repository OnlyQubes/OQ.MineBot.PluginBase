using System;
using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Base
{
    public class SettingGroup
    {
        private readonly Dictionary<string, IPluginSetting> collection = new Dictionary<string, IPluginSetting>();

        public bool HasSettings() {
            return collection.Count > 0;
        }

        public void Add(IPluginSetting setting) {
            collection.Add(setting.name, setting);
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
    }
}