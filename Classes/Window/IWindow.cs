using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Base;
using OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers;

namespace OQ.MineBot.PluginBase.Classes.Window
{
    public interface IWindow
    {
        event WindowDelegates.SlotDelegate onSlotChanged;
        event WindowDelegates.DropDelegate onSlotDropped;

        int    GetId();
        string GetWindowType();
        IChat  GetWindowName();

        ISlot GetAt(int index);
        ISlot GetAt(EquipmentSlots equipmentSlot);
        ISlot[] GetSlots(bool includeEmpty = false);

        bool IsOpen();
        Task Close ();

        byte GetSlotCount();

        ISlot[] Find(ushort id);
        ISlot[] Find(ushort[] ids);
        ISlot[] Find(ushort id, short metadata);
        ISlot[] Find(ushort[] ids, short[] metadata);
        ISlot   FindFirst(ushort id);
        ISlot   FindFirst(ushort[] ids);
        ISlot   FindFirst(ushort id, short metadata);
        ISlot   FindFirst(ushort[] ids, short[] metadata);
        ISlot[] FindByMetadata(short metadata);
        ISlot   FindFirstByMetadata(short metadata);

        ISlot[] FindByType(EquipmentType type);
        ISlot   FindBest  (EquipmentType type);
        ISlot   FindBest  (EquipmentSlots slot);

        bool    HasFreeSlots(int minSlotCount = 1);
        ISlot[] GetFreeSlots(int maxSlotCount = 255);
        ISlot   GetFreeSlot ();

        bool IsEmpty();
        bool IsFull ();

        int GetAmountOfItem(ushort id);

        Task<bool> MouseLeftClick(int index);
        Task<bool> MouseRightClick(int index);
        Task<bool> MouseShiftLeftClick(int index);
        Task<bool> MouseMiddleClick(int index);
        Task<bool> ClickHotbarShortcut(int index, int hotbarIndex);

        Task<bool> Take(ushort   id , int maxStacks = -1, Func<ISlot, bool> optionalCanBePicked = null);
        Task<bool> Take(ushort[] ids = null, int maxStacks = -1, Func<ISlot, bool> optionalCanBePicked = null);

        Task<bool> Deposit(ushort id, Func<ISlot, bool> optionalCanPickSlot = null);
        Task<bool> Deposit(ushort[] ids = null, Func<ISlot, bool> optionalCanPickSlot = null);
    }

    public enum EquipmentType
    {
        Helmet,
        Chestplate,
        Leggings,
        Boots,

        Sword,
        Pickaxe,
        Shovel,
        Axe
    }

    public class WindowDelegates
    {
        public delegate void SlotDelegate(ISlot slot);
        public delegate void DropDelegate(int index, bool stack);
    }
}