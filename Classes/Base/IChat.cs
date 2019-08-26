using System;

namespace OQ.MineBot.PluginBase.Classes.Base
{
    public static class Chat
    {
        public static Func<string, IChat> __hook_c_p; 
        public static IChat Parse(string text) {
            return __hook_c_p(text);
        }
    }

    public interface IChat
    {
        /// <summary>
        /// Parsed message RAW message to message only.
        /// (Excludes color information)
        /// </summary>
        string Raw { get; set; }

        /* Get all text components that have been parsed from Raw. */
        IChatFormatted[] GetChatFormatted();
        IChatFormatted[] GetByAttribute(ChatFormatAttribute attribute, bool matchValue);
        /* Get chat components that have the specified color.*/
        IChatFormatted[] GetByColor(ChatColor color);

        IChatAction[] GetHoverEvents();
        IChatAction[] GetClickEvents();
        IChatAction   GetClickEvent (string text);

        /* Parse raw and only get the text data. */
        object GetParagraph(Action<IChatFormatted> onClick = null);
        string GetText();
        string GetTextRtf();
    }

    public enum ChatColor
    {
        dark_red,
        red,
        gold,
        yellow,
        dark_green,
        green,
        aqua,
        dark_aqua,
        dark_blue,
        blue,
        light_purple,
        dark_purple,
        white,
        gray,
        dark_gray,
        black
    }

    public enum ChatFormatAttribute
    {
        Bold,
        Italic,
        Underline,
        Strikethrough,
        Obfuscated
    }
}