using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OQ.MineBot.GUI.Protocol.Movement.Maps;
using OQ.MineBot.PluginBase.Classes;
using OQ.MineBot.PluginBase.Classes.Blocks;
using OQ.MineBot.PluginBase.Classes.Entity;
using OQ.MineBot.PluginBase.Classes.Items;
using OQ.MineBot.PluginBase.Classes.Physics;
using OQ.MineBot.PluginBase.Classes.Window;
using OQ.MineBot.PluginBase.Classes.Window.Containers.Subcontainers;
using OQ.MineBot.PluginBase.Movement.Maps;
using OQ.MineBot.PluginBase.Pathfinding;
using OQ.MineBot.PluginBase.Pathfinding.Sub;

namespace OQ.MineBot.PluginBase
{
    /*
        All packet sending that
        is related to the player
        should be send through here.

        (E.g.: Look(east) should send the smooth looking
        packet. (should be async?))
    */
    public interface IPlayerFunctions
    {
        /// <summary>
        /// Set the player for this
        /// class.
        /// </summary>
        /// <param name="player"></param>
        void RegisterPlayer(IPlayer player);

        /// <summary>
        /// Start the packet compression/decompression
        /// streams.
        /// 
        /// This should be called by internal
        /// packet handling only!
        /// </summary>
        /// <param name="threshold"></param>
        /// <returns></returns>
        bool SetCompression(int threshold);

        /// <summary>
        /// Sends a keep alive packet
        /// to the server with the specified
        /// id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool SendKeepAlive(int id);
        bool SendKeepAlive(long id);

        /// <summary>
        /// Disconnects from the server.
        /// (Also called as when
        /// the server disconnects us)
        /// (This will disonnect and will
        /// call the events.)
        /// </summary>
        /// <param name="reason"></param>
        void Disconnect(string reason = "");

        /// <summary>
        /// Updates the player on the server.
        /// (Server updates players hunger
        /// only if this is sent OR other
        /// movement packets are sent)
        /// (Instant)
        /// </summary>
        /// <param name="onGround"></param>
        void SendUpdate(bool onGround);

        /// <summary>
        /// Set the players position.
        /// (Instant)
        /// </summary>
        /// <param name="position"></param>
        /// <param name="onGround"></param>
        void SetMovement(IPosition position, bool onGround);

        /// <summary>
        /// Set the players Rotation.
        /// (Instant)
        /// (For ncp positive look use:
        /// 'Look', 'LookAt' or 'LookAtSmooth')
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="onGround"></param>
        void SetRotation(IRotation rotation, bool onGround);

        /// <summary>
        /// Set the position and
        /// the look of the player.
        /// (Instant)
        /// </summary>
        /// <param name="newPos"></param>
        /// <param name="rotation"></param>
        void SetMovementLook(IPosition newPos, IRotation rotation, bool onGround);

        /// <summary>
        /// Confirms that the client has accepted
        /// the new position.
        /// For 1.9+.
        /// </summary>
        void TeleportConfirm(int id);

        /// <summary>
        /// Sends a chat message.
        /// </summary>
        /// <param name="message"></param>
        void Chat(string message);

        /// <summary>
        /// Attempts to respawn.
        /// </summary>
        void PerformaRespawn();

        /// <summary>
        /// Select the hotbar slot.
        /// </summary>
        /// <param name="index"></param>
        void SetHotbarSlot(short index);

        /// <summary>
        /// Sends default client settings
        /// to the server.
        /// </summary>
        void SendClientSettings(bool enabledChat, bool enableColors);

        /// <summary>
        /// Players the "player swing" animation.
        /// </summary>
        void PerformSwing();

        /// <summary>
        /// Crouches the player.
        /// </summary>
        void Crouch();
        /// <summary>
        /// Uncrouches the player.
        /// </summary>
        void Uncrouch();
        /// <summary>
        /// Toggles player crouch state.
        /// </summary>
        void ToggleCrouch();

        /// <summary>
        /// Attempts to jump.
        /// </summary>
        /// <returns>False if already
        /// in the air/jumping</returns>
        bool Jump();

        /// <summary>
        /// Open the inventory window.
        /// </summary>
        void OpenInventory();
        /// <summary>
        /// Close the inventory window.
        /// </summary>
        void CloseInventory();
        /// <summary>
        /// Attempts to open 
        /// a container at position.
        /// </summary>
        /// <param name="location"></param>
        void OpenContainer(ILocation location);
        /// <summary>
        /// Attempts to close a container.
        /// (Window)
        /// </summary>
        /// <param name="id"></param>
        void CloseContainer(int id);

        /// <summary>
        /// Attempts to find a chest
        /// in the area that has free
        /// slots.
        /// </summary>
        IChestMap CreateChestMap();

        /// <summary>
        /// Drops single item from inventory.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="index"></param>
        /// <param name="actionId"></param>
        void DropItem(byte windowId, short index, short actionId);
        /// <summary>
        /// Drops a stack of item from inventory.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="index"></param>
        /// <param name="actionId"></param>
        void DropItemStack(byte windowId, short index, short actionId);

        /// <summary>
        /// Drops all items in the inventory.
        /// </summary>
        /// <param name="delay">Delay between each drop. (for ncp)</param>
        /// <param name="fullStack"></param>
        /// <param name="stopToken">As this class has a delay it has a stop token. [can be null]</param>
        void DropInventory(int delay, bool fullStack, object stopToken);
        /// <summary>
        /// Drops items with the specified ids from
        /// the inventory.
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="fullStack"></param>
        /// <param name="delay">Delay between each drop. (for ncp)</param>
        /// <param name="stopToken">As this class has a delay it has a stop token. [can be null]</param>
        void DropInventory(short[] ids, bool fullStack, int delay, object stopToken);

        /// <summary>
        /// Shift clicks a slot.
        /// (works for amor equiping as well, 
        /// handlign the new item position should
        /// be done by the caller!)
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="index"></param>
        /// <param name="actionId"></param>
        void ShiftClickItem(byte windowId, short index, ISlot slot, short actionId);
        /// <summary>
        /// Performs a keypad (1-9 buttons) click
        /// on the inventory.
        /// The keypad button is "hotbarIndex".
        /// Mouse hovering point is "inventoryIndex".
        /// </summary>
        /// <param name="hotbarIndex"></param>
        /// <param name="inventoryIndex"></param>
        void ClickHotbarShortcut(byte windowId, short hotbarIndex, ISlot hotbarSlot, short inventoryIndex, ISlot inventorySlot, short actionId);
        /// <summary>
        /// Used to respond with a confirmation
        /// when the server tells us that we 
        /// did an invalid inventory move.
        /// </summary>
        /// <param name="windowId"></param>
        /// <param name="actionId"></param>
        /// <param name="accepted"></param>
        void ConfirmTransaction(byte windowId, short actionId, bool accepted);

        /// <summary>
        /// "Right clicks" the selected (held) item.
        /// </summary>
        void UseSelectedItem();
        /// <summary>
        /// "Clicks" the item at the index on
        /// each opened container.
        /// </summary>
        /// <param name="index"></param>
        void ClickContainerSlot(short index, GameWindowButton mode);

        /// <summary>
        /// Makes the player use the 
        /// given rotation.
        /// (On physics tick)
        /// </summary>
        /// <param name="rotation">Excecutes rotations in
        /// their order on physics tick. (can also
        /// be 1 item in array)</param>
        /// <param name="force">Should it cancel/override all
        /// other rotation requests?</param>
        void Look(IRotation[] rotation, bool force = false);
        /// <summary>
        /// Makes the player look towards
        /// the target location.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="force">Should it cancel/override all
        /// other rotation requests?</param>
        void LookAt(IPosition target, bool force = false);
        /// <summary>
        /// Makes the player look towars
        /// the specified block.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="force">Should it cancel/override all
        /// other rotation requests?</param>
        void LookAtBlock(ILocation target, bool force = false);
        /// <summary>
        /// Smoothly look at the target
        /// location.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="smoothness">The smoother it is the, the slower it is.</param>
        /// <param name="force">Should it cancel/override all
        /// other rotation requests?</param>
        void LookAtSmooth(IPosition target, int smoothness, bool force = false);
        /// <summary>
        /// Smoothly look at the target
        /// location.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="speed"></param>
        /// <param name="force">Should it cancel/override all
        /// other rotation requests?</param>
        void LookAtSmooth(IPosition target, LookSpeed speed, bool force = false);

        /// <summary>
        /// Sends a blog dig start packet to
        /// the server.
        /// </summary>
        /// <param name="location"></param>
        void BlockDigStart(ILocation location, sbyte face);
        /// <summary>
        /// Sends a block dig end packet to 
        /// the server.
        /// </summary>
        /// <param name="location"></param>
        void BlockDigEnd(ILocation location, sbyte face);
        /// <summary>
        /// Sends a block dig cancel packet
        /// to the server.
        /// </summary>
        /// <param name="location"></param>
        void BlockDigCancel(ILocation location, sbyte face);
        /// <summary>
        /// Begins the block digging process.
        /// (Sends a start and end packet
        /// in the correct times.)
        /// (This does not check if we are
        /// close enough to the block or
        /// if we have equiped the correct item)
        /// </summary>
        /// <param name="location"></param>
        /// <param name="onStateChanged">Called once the action is complete or cancelled.</param>
        IDigAction BlockDig(ILocation location, Action<IDigAction> onStateChanged = null);

        /// <summary>
        /// Places the block ('blockData') on the
        /// face of 'blockPosition'.
        /// 
        /// FindValidNeighbour() should be used to
        /// find the face and block position.
        /// </summary>
        /// <param name="blockPosition">Needs to be calculated manually.</param>
        /// <param name="face">Face on which we will place the block.</param>
        void BlockPlaceOnBlockFace(ILocation blockPosition, sbyte face);

        /// <summary>
        /// Attempts (because it tries to find a block to place
        ///  this on) to find the best block/face to place on.
        /// 
        /// LookAtBlock() + BlockPlaceOnBlockFace() should
        /// be used after this.
        /// </summary>
        /// <param name="target">Location that we need the block to be placed on.</param>
        /// <param name="invalid">Blocks that are not a valid neighbour.</param>
        /// <returns></returns>
        IFacedLocation FindValidNeighbour(ILocation target, bool canVertical = true, ushort[] invalid = null);
        IFacedLocation FindValidFacingAwayNeighbour(ILocation target);
        
        /// <summary>
        /// Sends an attack packet.
        /// </summary>
        /// <param name="targetId"></param>
        void EntityAttack(int targetId);
        /// <summary>
        /// Sends a "right click" packet
        /// to the server.
        /// </summary>
        /// <param name="targetId"></param>
        void EntityInteract(int targetId);

        /// <summary>
        /// Finds and equips the best
        /// item to the equipmentSlot.
        /// </summary>
        bool EquipBest(EquipmentSlots equipmentSlot, Dictionary<short, IItem> possibleItems);
        /// <summary>
        /// Equip the best weapon in inventory.
        /// </summary>
        /// <returns></returns>
        bool EquipWeapon();

        /// <summary>
        /// Attempt to eat the item
        /// that is currently held.
        /// </summary>
        Task EatAsync();

        /// <summary>
        /// Start the sprinting process.
        /// </summary>
        bool StartSprint();
        /// <summary>
        /// Stop the sprinting process.
        /// </summary>
        void StopSprint();

        /// <summary>
        /// Starts a macro by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>NULL if not found.</returns>
        Task StartMacro(string name);


        /// <summary>
        /// [Not-async - will freeze the code until the path is generated]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAreaMap MoveToLocation(ILocation location, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Not-async - will freeze the code until the path is generated]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAreaMap MoveToLocation(IPosition position, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Not-async - will freeze the code until the path is generated]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAreaMap MoveToLocation(int x, float y, int z, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Not-async - will freeze the code until the path is generated]
        /// Moves the bot to the entity.
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAreaMap MoveToEntity(IEntity entity, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Not-async - will freeze the code until the path is generated]
        /// Moves to a block forward based on looking direction.
        /// </summary>
        /// <returns>Was the path reached.</returns>
        IAreaMap MoveDirection(IStopToken token, Direction direction, MapOptions options = null);

        /// <summary>
        /// [Async - will not freeze up your code if you are not
        /// using an await, if you are it freezes it until the path is found
        /// Start() has to be called on the map]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns></returns>
        IAsyncMap AsyncMoveToLocation(ILocation location, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Async - will not freeze up your code if you are not
        /// using an await, if you are it freezes it until the path is found
        /// Start() has to be called on the map]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAsyncMap AsyncMoveToLocation(IPosition position, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Async - will not freeze up your code if you are not
        /// using an await, if you are it freezes it until the path is found
        /// Start() has to be called on the map]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAsyncMap AsyncMoveToLocation(int x, float y, int z, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Async - will not freeze up your code if you are not
        /// using an await, if you are it freezes it until the path is found
        /// Start() has to be called on the map]
        /// Moves the bot to the entity.
        /// </summary>
        /// <returns>Null if not path is available.</returns>
        IAsyncMap AsyncMoveToEntity(IEntity entity, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Async - will not freeze up your code if you are not
        /// using an await, if you are it freezes it until the path is found
        /// Start() has to be called on the map]
        /// Moves to a block based on looking direction.
        /// </summary>
        /// <returns>Was the path reached.</returns>
        IAsyncMap AsyncMoveDirection(IStopToken token, Direction direction, MapOptions options = null);

        /// <summary>
        /// [Blocks main running thead until the path is reached]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <param name="location"></param>
        /// <returns>Was the path reached succesfully</returns>
        bool WaitMoveToLocation(ILocation location, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Blocks main running thead until the path is reached]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Was the path reached succesfully.</returns>
        bool WaitMoveToLocation(IPosition position, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Blocks main running thead until the path is reached]
        /// Moves the bot to the given location. 
        /// </summary>
        /// <returns>Was the path reached succesfully.</returns>
        bool WaitMoveToLocation(int x, float y, int z, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Blocks main running thead until the path is reached]
        /// Moves the bot to the entity.
        /// </summary>
        /// <returns>Was the path reached succesfully.</returns>
        bool WaitMoveToEntity(IEntity entity, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Blocks main running thead until the path is reached. 
        /// Async not available as we have to attempt to reach each block.]
        /// Moves to the interaction range
        /// of the target.
        /// 
        /// (It attempts to find a location
        /// where the position from us to
        /// target is not obstructed by blocks)
        /// </summary>
        /// <returns>Was the path reached.</returns>
        bool WaitMoveToRange(ILocation target, IStopToken token, MapOptions options = null);
        /// <summary>
        /// [Blocks main running thead until the path is reached.]
        /// Moves to a block based on looking direction.
        /// </summary>
        /// <returns>Was the path reached.</returns>
        bool WaitMoveDirection(IStopToken token, Direction direction, MapOptions options = null);
    }

    public enum LookSpeed
    {
        slow = 25,
        medium = 10,
        fast = 5
    }

    public enum Direction
    {
        Forward,
        Backwards,
        Left,
        Right,
        West,
        North,
        East,
        South
    }


    public enum GameWindowButton
    {
        Left = 0,
        Right = 1,

        Number1 = 0,
        Number2 = 1,
        Number3 = 2,
        Number4 = 3,
        Number5 = 4,
        Number6 = 5,
        Number7 = 6,
        Number8 = 7,
        Number9 = 8,

        Middle = 2,

        DropSingle = 0,
        DropAll = 1,

        DoubleClick = 0
    }
}
