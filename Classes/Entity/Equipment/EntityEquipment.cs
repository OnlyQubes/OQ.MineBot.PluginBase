namespace OQ.MineBot.PluginBase.Classes.Entity.Equipment
{
    public class EntityEquipment
    {
        public ISlot MainHand { get; set; }
        public ISlot OffHand { get; set; }

        public ISlot Boots { get; set; }
        public ISlot Leggings { get; set; }
        public ISlot Chestplate { get; set; }
        public ISlot Helmet { get; set; }
    }
}