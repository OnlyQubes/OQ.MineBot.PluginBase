using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Window.Containers;

namespace OQ.MineBot.PluginBase.Classes.Window
{
    public interface IWindowContainer
    {
        event WindowContainerDelegates.WindowDelegate onWindowAddedEvent;
        event WindowContainerDelegates.WindowRemovedDelegate onWindowRemovedEvent;

        /// <summary>
        /// Players inventory.
        /// </summary>
        IInventory GetInventory();
        /// <summary>
        /// Gets the currently open window. This does not return IInventory, that should be kept track of manually as the notchian server
        /// does not keep track of the players inventory.
        /// This can return null if no open window is found.
        /// </summary>
        IWindow GetOpenWindow();

        /// <summary>
        /// Get window by id.
        /// </summary>
        /// <param name="id">If id is 0 then 'inventory' is returned.</param>
        IWindow GetWindow(int id);
        IWindow GetWindowByTitle(string title);
        IWindow GetWindowByType (string type);

        /// <summary>
        /// Closes all windows one by one. 
        /// Calls callback once done.
        /// </summary>
        Task CloseWindows();
    }

    public class WindowContainerDelegates
    {
        public delegate void WindowDelegate(IWindow window);
        public delegate void WindowRemovedDelegate(int id);
    }
}