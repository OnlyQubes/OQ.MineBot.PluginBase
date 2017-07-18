namespace OQ.MineBot.PluginBase.Classes.Items
{
    public interface IStackable
    {
        /// <summary>
        /// Max amount of same type items
        /// that can be stored in the same slot.
        /// </summary>
        byte maxStackSize { get; set; } 
    }
}