using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Base;

namespace OQ.MineBot.PluginBase.Utility
{
    public class DiscordHelper
    {
        public static Action<ulong, string, string, string, bool, byte> __api_hook_dsc;
        public static Action<ulong, string, string, string, bool, byte, int> __api_hook_notdsc;
        public static Action<string, int> __api_hook_alw;
        public static Action<string, int> __api_hook_ale;

        public static Func<string, string, Task<DiscordWebhookClient>> __api_hook_webhook_int;
        public static Func<string, string, object, Task<int>> __api_hook_webhook_snd;


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
            __api_hook_ale(message, id);
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

        public static Task<DiscordWebhookClient> WebhookInit(string id, string token) {
            return __api_hook_webhook_int(id, token);
        }

        public static Task<int> WebhookSendMessage(string id, string token, object message) {
            return __api_hook_webhook_snd(id, token, message);
        }
    }

    public class DiscordWebhookClient
    {
        public string id, token;

        public string botName;

        private bool _disposed;

        private readonly ConcurrentQueue<object> _queue = new ConcurrentQueue<object>(); 
        private bool _queueActive;

        public DiscordWebhookClient(string id, string token, string botName) {
            this.id = id;
            this.token = token;
            this.botName = botName;
        }

        public async void SendMessage(object message) {
            _queue.Enqueue(message);

            if (!_queueActive) {
                _queueActive = true;
                try {
                    while (!_disposed && _queueActive && !_queue.IsEmpty) {

                        object msg;
                        if (!_queue.TryDequeue(out msg)) continue;

                        var nextDelay = await DiscordHelper.WebhookSendMessage(id, token, msg);
                        if (_queue.IsEmpty) break;

                        if (nextDelay > 0) await Task.Delay(nextDelay);
                    }
                }
                catch { Console.WriteLine("[Discord] Failed to send message."); }
                _queueActive = false;
            }
        }

        public bool IsValid() {
            return !_disposed && !string.IsNullOrWhiteSpace(botName);
        }

        public void Dispose() {
            this._disposed = true;
        }
    }

    public class DiscordMessage
    {
        public string content;

        public DiscordMessage(string content) {
            this.content = content;
        }
    }

    public class DiscordEmbeds
    {
        public DiscordEmbed[] embeds;
    }

    public class DiscordEmbed
    {
        public int? color;
        public string title;
        public string type = "rich";
        public string description;
        public string url;
        public DiscordField[] fields;
        public DiscordFooter footer;
    }

    public class DiscordField
    {
        public string name;
        public string value;
        public bool inline;

        public DiscordField() { }
        public DiscordField(string name, string value, bool inline) {
            this.name = name;
            this.value = value;
            this.inline = inline;
        }
    }

    public class DiscordFooter
    {
        public string text;
        public string icon_url;
    }
}