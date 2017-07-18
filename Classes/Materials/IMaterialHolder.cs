namespace OQ.MineBot.PluginBase.Classes.Materials
{
    public interface IMaterialHolder
    {
        /// <summary>
        /// All materials sorted by
        /// http://minecraft.gamepedia.com/Materials ids.
        /// </summary>
        IMaterial[] materials { get; set; }

        /// <summary>
        /// Get material by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IMaterial GetMaterial(string name);
        /// <summary>
        /// Get material by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IMaterial GetMaterial(int id);
    }
}