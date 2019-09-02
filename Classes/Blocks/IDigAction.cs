using System;
using System.Threading.Tasks;

namespace OQ.MineBot.PluginBase.Classes.Blocks
{
    public interface IDigAction
    {
        /// <summary>
        /// Is this request valid?
        /// </summary>
        bool valid { get; set; }

        /// <summary>
        /// Dig duration in milliseconds.
        /// </summary>
        int duration { get; }

        /// <summary>
        /// The location at which
        /// we are digging at.
        /// </summary>
        ILocation location { get; }

        /// <summary>
        /// Is this action cancelled.
        /// </summary>
        bool cancelled { get; }

        /// <summary>
        /// Is this dig action completed.
        /// </summary>
        bool completed { get; set; }

        /// <summary>
        /// Action that is called once
        /// digging is cancelled.
        /// </summary>
        Action<IDigAction> onStateChanged { get; set; }

        Task<IDigAction> DigTask { get; set; }

        /// <summary>
        /// Cancels the event.
        /// </summary>
        /// <param name="context"></param>
        void Cancel(IBotContext context);
    }
}