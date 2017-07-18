using System;

namespace OQ.MineBot.PluginBase.Utility
{
    public static class NameHelper
    {
        public static Func<string, string> __api_hook_ntu;

        /// <summary>
        /// Converts a name to a uuid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>NULL incase of an error or invalid name.</returns>
        public static string NameToUUID(string name) {

            return __api_hook_ntu(name);
        }
    }
}