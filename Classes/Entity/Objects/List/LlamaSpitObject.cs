﻿namespace OQ.MineBot.PluginBase.Classes.Entity.Objects.List
{
    public class LlamaSpitObject : IWorldObject {
        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return ObjectTypes.LlamaSpit;
        }

        /// <summary>
        /// Makes a copy of a world object.
        /// </summary>
        /// <returns></returns>
        public IWorldObject Copy() {
            return (IWorldObject)MemberwiseClone();
        }
    }
}