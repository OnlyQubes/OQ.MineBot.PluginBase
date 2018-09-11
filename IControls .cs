namespace OQ.MineBot.PluginBase
{
    /*
        Higher level controls of the player.
        Where as IPlayerFunctions allows you to control
        each packet and timing, this allows you to control
        higher level input.
        E.g.: hold left mouse button down.
    */
    public interface IControls
    {
        ControlState state { get; set; }

        /// <summary>
        /// Single click of button button.
        /// </summary>
        /// <param name="instant">
        /// true - sends the click packet instantly.
        /// false - waits until the next physics tick.
        /// </param>
        void ClickMouseButton(MouseButton button, bool instant = false, MouseClickMod mod = null);

        /// <summary>
        /// Holds the mouse button pressed down
        /// until ReleaseMouseButton is called.
        /// </summary>
        void HoldMouseButton(MouseButton button, MouseClickMod mod = null);
        /// <summary>
        /// Spam the mouse button
        /// until ReleaseMouseButton is called.
        /// </summary>
        void SpamMouseButton(MouseButton button, MouseClickMod mod = null);
        
        /// <summary>
        /// Stop holding/spam clicking all mouse buttons.
        /// </summary>
        void ReleaseMouseButton();
    }

    public class ControlState
    {
        // Are we spam clicking a mouse button.
        public bool mouseSpam { get; set; }
        // Are we holding down a mouse button.
        public bool mouseHold { get; set; }

        // Is the left button being spam clicked/held down.
        public bool mouseLeftButton { get; set; }
        // Is the right button being spam clicked/held down.
        public bool mouseRightButton { get; set; }
    }

    public class MouseClickMod
    {
        // Can we target blocks.
        // (default true)
        public bool world;
        // Can we target entities.
        // (default true)
        public bool entity;

        public MouseClickMod(bool world, bool entity) {
            this.world = world;
            this.entity = entity;
        }
    }

    public enum MouseButton
    {
        Left,
        Right
    }
}