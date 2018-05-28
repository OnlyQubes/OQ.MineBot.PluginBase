﻿using System;
using System.Collections.Generic;
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
        IInventory inventory { get; set; }

        /// <summary>
        /// Opened windows.
        /// </summary>
        Dictionary<int, IWindow> openWindows { get; set; }

        /// <summary>
        /// Get window by id.
        /// </summary>
        /// <param name="id">If id is 0 then 'inventory' is returned.</param>
        /// <returns></returns>
        IWindow GetWindow(int id);
        /// <summary>
        /// Get window by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IWindow GetWindow(string name);
        /// <summary>
        /// Adds a window to the container.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        IWindow AddWindow(IWindow window);
        /// <summary>
        /// "Closes" a window.
        /// </summary>
        /// <param name="id"></param>
        void RemoveWindow(int id);
        /// <summary>
        /// Gets window from openWindows at index i.
        /// </summary>
        IWindow GetWindowAt(int i);

        /// <summary>
        /// Closes all windows one by one. 
        /// Calls callback once done.
        /// </summary>
        /// <param name="callback"></param>
        void CloseAllWindowsAsync(Action callback);
    }

    public class WindowContainerDelegates
    {
        public delegate void WindowDelegate(IWindow window);
        public delegate void WindowRemovedDelegate(int id);
    }
}