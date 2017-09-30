using System;
using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Base.Permissions
{
    public static class EventPermissions
    {
        /// <summary>
        /// Are low level permissions allowed.
        /// </summary>
        internal static bool m_lowLevel => __api_hook_lp();

        public static Action<string> __api_hook_not;
        public static Func<bool> __api_hook_lp;

        public static List<Action<IPermittedCredentials, IPermittedServer, IPermittedConnection>> __api_hook_ocr;
        public static List<Action<IPermittedCredentials, IPermittedServer, IPermittedConnection>> __api_hook_osir;

        public static bool CheckPermissions(string level) {
            if (level == "low-level")
                return m_lowLevel;
            if (level == "high-level")
                return true;
            throw new ArgumentException("Invalid level.");
        }

        public static void LowLevelHook(string name, LowLevelEvents type, Action<IPermittedCredentials, IPermittedServer, IPermittedConnection> hook) {
            // Check if we can use low level hooks.
            if (!CheckPermissions("low-level"))
                throw new AccessViolationException("Low-level hooks not allowed by user.");

            __api_hook_not(name);
            if (type == LowLevelEvents.OnCredentialsReceived) {
                if (__api_hook_ocr == null)
                    __api_hook_ocr = new List<Action<IPermittedCredentials, IPermittedServer, IPermittedConnection>>();
                __api_hook_ocr.Add(hook);
            }
            else if (type == LowLevelEvents.OnServerInitialResponse) {
                if (__api_hook_osir == null)
                    __api_hook_osir = new List<Action<IPermittedCredentials, IPermittedServer, IPermittedConnection>>();
                __api_hook_osir.Add(hook);
            }
        }
    }

    public enum LowLevelEvents
    {
        OnCredentialsReceived,
        OnServerInitialResponse,
    }
}