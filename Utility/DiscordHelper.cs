using System;

namespace OQ.MineBot.PluginBase.Utility
{
    public class DiscordHelper
    {
        public static Action<ulong, string, string, string, bool, byte> __api_hook_dsc;
        public static Action<ulong, string, string, string, bool, byte, int> __api_hook_notdsc;
        public static Action<string, int> __api_hook_alw;
        public static Action<string, int> __api_hook_ale;

        /// <summary>
        /// Sends a discord message to the user.
        /// </summary>
        /// <param name="body">TTS message part, only used if mode has tts.</param>
        public static void SendMessage(ulong discord, string title, string body, string message, bool important, Mode mode) {
            __api_hook_dsc(discord, title, body, message, important, (byte)mode);
        }

        /// <summary>
        /// Sends a discord message to the user and
        /// opens a notification.
        /// </summary>
        /// <param name="body">TTS message part, only used if mode has tts.</param>
        public static void AlertMessage(ulong discord, string title, string body, string message, bool important, int priority, Mode mode) {
            __api_hook_notdsc(discord, title, body, message, important, (byte)mode, priority);
        }

        public static void Alert(string message, int id) {
            __api_hook_alw(message, id);
        }
        public static void Error(string message, int id) {
            __api_hook_alw(message, id);
        }

        public enum Mode
        {
            None,
            Everyone,
            EveryoneTTS
        }
    }
}