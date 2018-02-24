using OQ.MineBot.PluginBase.Classes;

namespace OQ.MineBot.PluginBase.Base.Plugin.Tasks
{
    /*
        'OnInventoryChanged' - called everytime the players inventory changes.
        'OnItemChanged' - called every time a slot changes (e.g.: item picked up, item removed, item count incremented)
        'OnItemAdded' - called once an item gets added to the inventory. (has to be a new item, does not get called if item is put into an existing stack)
        'OnItemRemoved' - called once an item gets removed from the inventory.

        (The methods will get called from the main thead,
        therefore if your methods take >3ms then they
        should be running on a seperate thread)
    */
    public interface IInventoryListener
    {
        void OnInventoryChanged();
        void OnSlotChanged(ISlot slot);
        void OnItemAdded(ISlot slot);
        void OnItemRemoved(ISlot slot);
    }
}