namespace OQ.MineBot.PluginBase.Classes.Window.Containers
{
    public interface ISearchableContainer
    {
        /// <summary>
        /// Find a slot by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>-1 if not found.</returns>
        short FindId(int id);
        /// <summary>
        /// Find a slot by ids.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        short FindId(int[] ids);

        /// <summary>
        /// Find a slot by ids and metadata.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        short FindId(int id, int[] metadata);
        /// <summary>
        /// Find slots by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        short[] FindIds(int id);

        /// <summary>
        /// Find a slot by id. This returns the slot
        /// that has the highest count of item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>-1 if not found.</returns>
        short FindIdMax(int id);
    }
}