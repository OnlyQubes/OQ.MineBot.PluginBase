using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Base
{
    public class IParentSetting
    {
        private readonly Dictionary<object, SettingGroup> collection = new Dictionary<object, SettingGroup>();

        public delegate void OnValueChangedDelete();
        public event OnValueChangedDelete OnValueChanged;
        public void InvokeEvent() {
            OnValueChanged?.Invoke();
        }

        public void Add(object meValue, IPluginSetting setting) {
            if (!collection.ContainsKey(meValue))
                collection.Add(meValue, new SettingGroup());

            setting.parent = (IPluginSetting)this;
            setting.saveName = setting.parent.name + "#" + meValue.ToString() + ">" + setting.name;
            collection[meValue].Add(setting);
        }

        public IPluginSetting Get(object meValue, string name) {
            if (!collection.ContainsKey(meValue)) return null;
            return collection[meValue].Get(name);
        }
        public T GetValue<T>(object meValue, string name) {
            if (!collection.ContainsKey(meValue)) return default(T);
            return collection[meValue].GetValue<T>(name);
        }
        public T GetValue<T>(string name) {
            if (!collection.ContainsKey(false)) return default(T);
            return collection[false].GetValue<T>(name);
        }

        public SettingGroup GetGroup(object meValue) {
            if (!collection.ContainsKey(meValue)) return null;
            return collection[meValue];
        }

        public Dictionary<object, SettingGroup> GetCollection() {
            return collection;
        }
    }
}