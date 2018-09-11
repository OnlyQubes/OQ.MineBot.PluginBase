namespace OQ.MineBot.PluginBase.Classes.Base
{
    public class Enchantment
    {
        public int Id { get; private set; }
        public int Level { get; private set; }

        public Enchantment(int id, int level) {
            this.Id = id;
            this.Level = level;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() {
            return "{ id: " + Id + ", lvl: " + Level + " }";
        }
    }
}