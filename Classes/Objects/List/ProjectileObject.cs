namespace OQ.MineBot.PluginBase.Classes.Objects.List
{
    public class ProjectileObject : IWorldObject
    {
        /// <summary>
        /// Entity id of the shooter.
        /// </summary>
        public int ShooterId { get; set; }

        public ProjectileObject(ObjectTypes type) {
            this.m_type = type;
        }

        /// <summary>
        /// Entity id of this object.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Type of this object.
        /// </summary>
        /// <returns></returns>
        public ObjectTypes GetType() {
            return m_type;
        }
        private ObjectTypes m_type;

        /// <summary>
        /// Makes a copy of a world object.
        /// </summary>
        /// <returns></returns>
        public IWorldObject Copy() {
            return (IWorldObject)MemberwiseClone();
        }
    }
}