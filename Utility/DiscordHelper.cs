using System;

namespace OQ.MineBot.PluginBase.Utility
{
    public class DiscordHelper
    {
        public static Action<string, string> __api_hook_dsc;
        public static Action<string, string, int> __api_hook_notdsc;
        public static Action<string, int> __api_hook_alw;
        public static Action<string, int> __api_hook_ale;

        /// <summary>
        /// Sends a discord message to the user.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static void SendMessage(string name, string message)
        {
            __api_hook_dsc(name, message);
        }

        /// <summary>
        /// Sends a discord message to the user and
        /// opens a notification.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <param name="priority"></param>
        public static void AlertMessage(string name, string message, int priority)
        {
            __api_hook_notdsc(name, message, priority);
        }

        public static void Alert(string message, int id) {
            __api_hook_alw(message, id);
        }
        public static void Error(string message, int id) {
            __api_hook_alw(message, id);
        }
    }
}