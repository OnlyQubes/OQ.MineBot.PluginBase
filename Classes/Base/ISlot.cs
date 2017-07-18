using System.IO;

namespace OQ.MineBot.PluginBase.Classes
{
    public interface ISlot
    {
        /// <summary>
        /// Id of the item in this slot.
        /// </summary>
        short id { get; set; }

        /// <summary>
        /// How many items are in this slot.
        /// </summary>
        sbyte count { get; set; }
        /// <summary>
        /// How much item does this item
        /// have taken.
        /// </summary>
        short damage { get; set; }

        /// <summary>
        /// Nbt data for this item.
        /// </summary>
        object nbt { get; set; }//NbtTag nbt { get; set; }

        ISlot Read(Stream stream, object token, ref int bytesRead);
    }
}