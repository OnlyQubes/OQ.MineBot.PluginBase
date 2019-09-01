using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public interface IEntityMetadata
    {
        /// <summary>
        /// All of the metada values
        /// should be stored here.
        /// </summary>
        Dictionary<int, object> metadata { get; set; }

        void Update(IEntityMetadata entityMetadata);
        object TryGetValue(int id);
    }
}